using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using NP.Avalonia.Visuals.Controls;

namespace NP.Demos.CustomWindowSamples
{
    public partial class MainWindow : CustomWindow
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
