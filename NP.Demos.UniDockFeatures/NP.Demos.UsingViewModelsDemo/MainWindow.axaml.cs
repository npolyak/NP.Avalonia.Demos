using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using NP.Avalonia.UniDockService;
using System.Collections.ObjectModel;
using System.Linq;

namespace NP.Demos.UsingViewModelsDemo
{
    public partial class MainWindow : Window
    {
        public IUniDockService _uniDockService;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            _uniDockService = (IUniDockService) this.FindResource("TheDockManager")!;

            _uniDockService.DockItemsViewModels = 
                new ObservableCollection<DockItemViewModelBase>();

            Button addTabButton = this.FindControl<Button>("AddTabButton");

            addTabButton.Click += AddTabButton_Click;

            Button saveButton = this.FindControl<Button>("SaveButton");
            saveButton.Click += SaveButton_Click;

            Button restoreButton = this.FindControl<Button>("RestoreButton");
            restoreButton.Click += RestoreButton_Click;
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

            // select the first tab.
            _uniDockService.DockItemsViewModels?.FirstOrDefault()?.Select();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
