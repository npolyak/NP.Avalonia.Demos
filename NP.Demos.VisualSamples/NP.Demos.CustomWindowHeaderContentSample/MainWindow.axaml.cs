using Avalonia;
using Avalonia.Markup.Xaml;
using NP.Avalonia.Visuals.Controls;

namespace NP.Demos.CustomWindowHeaderContentSample
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
