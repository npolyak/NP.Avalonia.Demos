using Avalonia.Controls;

namespace HostingWinFormsDemo
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
