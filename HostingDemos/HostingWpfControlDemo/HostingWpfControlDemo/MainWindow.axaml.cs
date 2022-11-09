using Avalonia.Controls;

namespace HostingWinFormsDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MyContentControl.Content = new EmbedSample();
            //RootPanel.Children.Add(new EmbedSample());
        }
    }
}
