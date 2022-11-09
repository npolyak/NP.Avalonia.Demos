using Avalonia.Controls;
using Interfaces;

namespace HostWithIoC
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            object wpfView = App.TheContainer.Resolve<object>("WpfPlugin");
            NativeEmbedder.WindowsNativeObject = wpfView;


            //if (viewEmbedder != null)
            //{
            //    object wpfView = App.TheContainer.Resolve<object>("WpfPlugin");

            //    viewEmbedder.NativeObject = wpfView;

            //    this.Content = viewEmbedder;
            //}
        }
    }
}
