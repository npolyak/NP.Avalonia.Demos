using Avalonia.Controls;
using Interfaces;

namespace HostWithIoC
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            IEmbedder viewEmbedder = App.TheContainer.Resolve<IEmbedder>("EmbeddingView");

            if (viewEmbedder != null)
            {
                object wpfView = App.TheContainer.Resolve<object>("WpfPlugin");

                viewEmbedder.NativeObject = wpfView;

                this.Content = viewEmbedder;
            }
        }
    }
}
