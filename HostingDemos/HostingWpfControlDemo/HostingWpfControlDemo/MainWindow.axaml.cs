using Avalonia.Controls;

namespace HostingWinFormsDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            RootPanel.Children.Add(new EmbedSample());
        }
    }
}
