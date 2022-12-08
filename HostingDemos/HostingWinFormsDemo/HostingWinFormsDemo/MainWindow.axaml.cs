using Avalonia.Controls;
using Avalonia.Layout;

namespace HostingWinFormsDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            EmbedSample embedSample = new EmbedSample();

            embedSample.HorizontalAlignment = HorizontalAlignment.Stretch;
            embedSample.VerticalAlignment = VerticalAlignment.Stretch;

            // connect the EmbedSample
            MyContentControl.Content = new EmbedSample();
        }
    }
}
