using Avalonia.Controls;

namespace HostingWindowsProcessDemo
{
    public partial class MainWindow : Window
    {
        public const string WpfAppProcessPath = @"AppsToHost\WpfApp\WpfApp.exe";


        public MainWindow()
        {
            InitializeComponent();

            this.Opened += MainWindow_Opened;
        }

        private async void MainWindow_Opened(object? sender, System.EventArgs e)
        {
            var wpfAppEmbeddedProcessWindow = new EmbeddedProcessWindow(WpfAppProcessPath);

            await wpfAppEmbeddedProcessWindow.StartProcess();

            WpfAppPlacementControl.Content = wpfAppEmbeddedProcessWindow;

        }
    }
}
