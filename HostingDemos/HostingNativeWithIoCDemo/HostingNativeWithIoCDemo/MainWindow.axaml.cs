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

            // create the embedSample control 
            NativeEmbeddingControl embedSample = new NativeEmbeddingControl();

            // create the platform handle from the container. 
            IPlatformHandle? platformHandle = App.Container.Resolve<IPlatformHandle?>("ClickCounterView");

            // assign the embedSample handle to platformHandle
            embedSample.Handle = platformHandle;

            // set the Content of MyContentControl to be embedSample object. 
            MyContentControl.Content = embedSample;
        }
    }
}
