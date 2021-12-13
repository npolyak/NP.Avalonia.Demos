using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using NP.Avalonia.Visuals.Controls;

namespace NP.Demos.CustomWindowResizeBug
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            Border b = this.FindControl<Border>("Right");

            b.PointerPressed += B_PointerPressed;
        }

        private void B_PointerPressed(object? sender, PointerPressedEventArgs e)
        {
            PlatformImpl?.BeginResizeDrag(WindowEdge.East, e);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
