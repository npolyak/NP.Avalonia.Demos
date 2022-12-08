using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using NP.Avalonia.UniDock;
using NP.Avalonia.UniDockService;
using NP.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace NP.WebBrowsersInsideUniDock
{
    public partial class MainWindow : Window
    {
        private DockManager _dockManager;


        private const string SerializationFile = "Serialization.xml";
        private const string VMSerializationFile = "VMSerialization.xml";

        int _count = 0;
        public MainWindow()
        {
            InitializeComponent();
            _dockManager = (DockManager)this.FindResource("TheDockManager")!;

            _dockManager.DockItemsViewModels = new ObservableCollection<DockItemViewModelBase>();
            //_dockManager.DockItemsViewModels =
            //    (
            //        new DockItemViewModelBase[]
            //        {
            //            new DockItemViewModelBase
            //            {
            //                DockId = "1",
            //                DefaultDockGroupId = "DocumentGroup",
            //                Header = "Tab 1",
            //                Content = "Hello World",
            //                ContentTemplateResourceKey = "ReloadingDataTemplate",
            //            },
            //            new DockItemViewModelBase
            //            {
            //                DockId = "2",
            //                DefaultDockGroupId = "DocumentGroup",
            //                Header = "Tab 2",
            //                Content = "Hello World",
            //                ContentTemplateResourceKey = "ReloadingDataTemplate",
            //            }
            //        }
            //    ).ToObservableCollection();

            this.FindControl<Button>("AddButton").Click += OnAdd;
            this.FindControl<Button>("SaveButton").Click += OnSave;
            this.FindControl<Button>("RestoreButton").Click += OnRestore;
        }

        private void OnAdd(object? sender, RoutedEventArgs e)
        {
            _count++;
            _dockManager.DockItemsViewModels.Add
            (
                new DockItemViewModelBase
                {
                    DockId = "Browser_" + _count.ToString(),
                    DefaultDockGroupId = "DocumentGroup",
                    DefaultDockOrderInGroup = _count,
                    Header = $"Tab {_count}",
                    Content = "Hello World",
                    ContentTemplateResourceKey = "ReloadingDataTemplate",
                    IsPredefined = false
                }
            );
        }

        private void OnSave(object? sender, RoutedEventArgs e)
        {
            _dockManager.SaveToFile(SerializationFile);

            _dockManager.SaveViewModelsToFile(VMSerializationFile);
        }

        private void OnRestore(object? sender, RoutedEventArgs e)
        {
            _dockManager.DockItemsViewModels = null;
            _dockManager.RestoreFromFile(SerializationFile);

            _dockManager
                .RestoreViewModelsFromFile
                (
                    VMSerializationFile);

            _count = (int)_dockManager.DockItemsViewModels!.Max(vm => vm.DefaultDockOrderInGroup);

            GC.Collect();
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

    }
}
