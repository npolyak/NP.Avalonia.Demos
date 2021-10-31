using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using NP.Avalonia.Visuals.Behaviors;
using NP.Avalonia.Visuals.Converters;

namespace NP.Demos.DockingToWindowSidesDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            FromControlContainerConverter conv = new FromControlContainerConverter();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
