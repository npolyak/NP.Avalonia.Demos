using Avalonia.Controls;
using HostingLunuxProcessDemo;

namespace HostingWindowsProcessDemo
{
    public partial class MainWindow : Window
    {
        public const string ProcessPath = @"AppsToHost/LinuxApp/LinuxApp.exe";

        public MainWindow()
        {
            InitializeComponent();

            this.Opened += MainWindow_Opened;
        }

        private async void MainWindow_Opened(object? sender, System.EventArgs e)
        {
            var embeddedProcessWindow = new EmbeddedProcessWindow(ProcessPath);

            await embeddedProcessWindow.StartProcess();

            MyContentControl.Content = embeddedProcessWindow;   

            //WpfWindowPlacementPanel.Children.Add(embeddedProcessWindow);
        }
    }
}
