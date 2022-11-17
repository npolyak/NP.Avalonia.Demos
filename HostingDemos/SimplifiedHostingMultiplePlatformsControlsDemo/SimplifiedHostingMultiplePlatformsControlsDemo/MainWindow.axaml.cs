using Avalonia.Controls;
using PolyFills;

#if WINDOWS
using WpfControl;
#else 
using LinuxControl;
#endif

namespace HostingWinFormsDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            NativeEmbeddingControl embedSample = new NativeEmbeddingControl();

#if WINDOWS
            MyWpfUserControl control = new MyWpfUserControl();

            control.DataContext = new ViewModels.ClickCounterViewModel();

            embedSample.Handle = HandleBuilder.BuildHandle(control);
#else // Linux
            embedSample.Handle = HandleBuilder.BuildObjAndHandle(() => new LinuxView());
#endif

            MyContentControl.Content = embedSample;
        }
    }
}
