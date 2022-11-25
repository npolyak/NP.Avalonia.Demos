using Avalonia.Controls;

namespace HostingNativeDemo
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
