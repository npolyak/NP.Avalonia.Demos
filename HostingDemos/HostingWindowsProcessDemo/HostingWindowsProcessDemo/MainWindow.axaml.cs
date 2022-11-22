using Avalonia.Controls;

namespace HostingWindowsProcessDemo
{
    public partial class MainWindow : Window
    {
        public const string ProcessPath = @"AppsToHost\WpfApp\WpfApp.exe";

        public MainWindow()
        {
            InitializeComponent();

            this.Opened += MainWindow_Opened;
        }

        private async void MainWindow_Opened(object? sender, System.EventArgs e)
        {
            var embeddedProcessWindow = new EmbeddedProcessWindow(ProcessPath);

            await embeddedProcessWindow.StartProcess();

            this.Content = embeddedProcessWindow;
        }
    }
}
