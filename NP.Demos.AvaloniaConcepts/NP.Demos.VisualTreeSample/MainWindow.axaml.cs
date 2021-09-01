using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using System;
using System.Linq;

namespace NP.Demos.VisualAndLogicalTreeSample
{
    public partial class MainWindow : Window
    {
        private Button _button;
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            _button = this.FindControl<Button>("SimpleButton");

            _button.Click += OnButtonClick;
        }

        private void OnButtonClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            IVisual parent = _button.GetVisualParent();

            var visualAncestors = _button.GetVisualAncestors().ToList();

            var visualChildren = _button.GetVisualChildren().ToList();

            var visualDescendants = _button.GetVisualDescendants().ToList();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
