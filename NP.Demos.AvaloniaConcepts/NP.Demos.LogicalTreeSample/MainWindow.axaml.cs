using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.LogicalTree;
using Avalonia.Markup.Xaml;
using System.Linq;

namespace NP.Demos.LogicalTreeSample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            Button clickMeButton = this.FindControl<Button>("ClickMeButton");
            clickMeButton.Click += OnButtonClick;
        }

        private void OnButtonClick(object? sender, RoutedEventArgs e)
        {
            ItemsControl itemsControl = this.FindControl<ItemsControl>("TheItemsControl");

            var logicalParent = itemsControl.GetLogicalParent();
            var logicalAncestors = itemsControl.GetLogicalAncestors().ToList();
            var logicalChildren = itemsControl.GetLogicalChildren().ToList();
            var logicalDescendants = itemsControl.GetLogicalDescendants().ToList();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
