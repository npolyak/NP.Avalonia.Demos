using Avalonia.Controls;

namespace HostingLinuxControlDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            EmbedSample embedSample = new EmbedSample();

            MyContentControl.Content = embedSample;
        }
    }
}
