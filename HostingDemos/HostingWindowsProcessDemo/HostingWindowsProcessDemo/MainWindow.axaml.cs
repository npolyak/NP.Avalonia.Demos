using Avalonia.Controls;

namespace HostingWindowsProcessDemo
{
    public partial class MainWindow : Window
    {
        // path to WpfApp.exe
        public const string WpfAppProcessPath = @"AppsToHost\WpfApp\WpfApp.exe";

        public MainWindow()
        {
            InitializeComponent();

            // handle Opened event for the window
            this.Opened += MainWindow_Opened;
        }

        private async void MainWindow_Opened(object? sender, System.EventArgs e)
        {
            // create EmbeddedProcessWindow object passing the path to it
            var wpfAppEmbeddedProcessWindow = new EmbeddedProcessWindow(WpfAppProcessPath);

            // start the process and wait for the process'es MainWindowHandle to get populated
            await wpfAppEmbeddedProcessWindow.StartProcess();

            // assign the wpfAppEmbeddedProcessWindow to the 
            // content control in the left half of the MainWindow
            WpfAppPlacementControl.Content = wpfAppEmbeddedProcessWindow;
        }
    }
}
