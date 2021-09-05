using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace NP.Demos.MultiBindingSample
{
    public partial class MainWindow : Window
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
