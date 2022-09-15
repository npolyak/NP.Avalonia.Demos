using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using NP.Avalonia.UniDockService;
using NP.Concepts.Behaviors;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace NP.Demos.UsingViewModelsDemo
{
    public partial class MainWindow : Window
    {
        // non-visual interface to the DockManager
        public IUniDockService _uniDockService;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            // set the uniDockService interface to contain the reference to the
            // dock manager defined as a resource.
            _uniDockService = (IUniDockService) this.FindResource("TheDockManager")!;

            // set the DockItemsViewModels collection to an observable
            // collection of DockItemViewModelBase items.
            _uniDockService.DockItemsViewModels = 
                new ObservableCollection<DockItemViewModelBase>();

            _uniDockService.DockItemRemovedEvent += _uniDockService_DockItemRemovedEvent;

            _uniDockService.DockItemSelectionChangedEvent += _uniDockService_DockItemSelectionChangedEvent;


            // set the Click handlers on the AddTab, Save and Restore buttons

            Button addTabButton = this.FindControl<Button>("AddTabButton");
            addTabButton.Click += AddTabButton_Click;

            Button saveButton = this.FindControl<Button>("SaveButton");
            saveButton.Click += SaveButton_Click;

            Button restoreButton = this.FindControl<Button>("RestoreButton");
            restoreButton.Click += RestoreButton_Click;
        }

        private void _uniDockService_DockItemSelectionChangedEvent(DockItemViewModelBase itemVm)
        {
            string str = $"{itemVm.DockId} {itemVm.IsSelected}";
            Console.Write(str);
        }

        private void _uniDockService_DockItemRemovedEvent(DockItemViewModelBase removedItemVm)
        {
            string str = $"{removedItemVm.DockId} {removedItemVm.IsSelected}";
            Console.Write(str);
        }

        private void OnItemRemoved(DockItemViewModelBase dockItemVM)
        {
            dockItemVM.PropertyChanged -= DockItemVM_PropertyChanged;
        }

        private void OnItemAdded(DockItemViewModelBase dockItemVM)
        {
            dockItemVM.PropertyChanged += DockItemVM_PropertyChanged;
        }

        private void DockItemVM_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(DockItemViewModelBase.IsSelected))
            {
                DockItemViewModelBase dockItemVM = (DockItemViewModelBase)sender!;
                string str = $"{dockItemVM.DockId} {dockItemVM.IsSelected}";

                Console.Write(str);
            }
        }

        private int _tabNumber = 1;
        private void AddTabButton_Click(object? sender, RoutedEventArgs e)
        {
            string tabStr = $"Tab_{_tabNumber}";
            _uniDockService.DockItemsViewModels.Add
            (
                new DockItemViewModelBase
                {
                    DockId = tabStr,
                    Header = tabStr,
                    Content = $"This is tab {_tabNumber}",
                    DefaultDockGroupId = "Tabs",
                    DefaultDockOrderInGroup = _tabNumber,
                    IsSelected = true,
                    IsActive = true
                });

            _tabNumber++;
        }


        private const string DockSerializationFileName = "DockSerialization.xml";
        private const string VMSerializationFileName = "DockVMSerialization.xml";

        private void SaveButton_Click(object? sender, RoutedEventArgs e)
        {
            // save the layout
            _uniDockService.SaveToFile(DockSerializationFileName);

            // save the view models
            _uniDockService.SaveViewModelsToFile(VMSerializationFileName);
        }

        private void RestoreButton_Click(object? sender, RoutedEventArgs e)
        {
            // clear the view models
            _uniDockService.DockItemsViewModels = null;

            // restore the layout
            _uniDockService.RestoreFromFile(DockSerializationFileName);

            // restore the view models
            _uniDockService.RestoreViewModelsFromFile(VMSerializationFileName);

            _tabNumber = _uniDockService.DockItemsViewModels.Max(vm => GetTabNumber(vm.DockId));

            _tabNumber++;

            // select the first tab.
            _uniDockService.DockItemsViewModels?.FirstOrDefault()?.Select();
        }

        int GetTabNumber(string str)
        {
            return int.Parse(str.Split("_").Last());
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
