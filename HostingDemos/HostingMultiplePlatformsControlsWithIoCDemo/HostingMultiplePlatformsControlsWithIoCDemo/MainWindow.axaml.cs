using Avalonia.Controls;
using Avalonia.Platform;
using Visuals;

namespace HostingWinFormsDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            App.Container.CompleteConfiguration();

            NativeEmbeddingControl embedSample = new NativeEmbeddingControl();

            var handle = App.Container.Resolve<IPlatformHandle?>("ThePlatformHandle");

            embedSample.Handle = handle;

            MyContentControl.Content = embedSample;
        }
    }
}
