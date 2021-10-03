using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Windows.Input;

namespace NP.Demos.DifferentVisualsForCustomControlSample
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
