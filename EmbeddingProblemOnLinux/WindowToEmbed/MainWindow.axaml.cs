using Avalonia;
using Avalonia.Controls;

namespace WindowToEmbed
{
    public partial class MainWindow : Window
    {

        #region WindowHandle Styled Avalonia Property
        public long WindowHandle
        {
            get { return GetValue(WindowHandleProperty); }
            set { SetValue(WindowHandleProperty, value); }
        }

        public static readonly StyledProperty<long> WindowHandleProperty =
            AvaloniaProperty.Register<MainWindow, long>
            (
                nameof(WindowHandle)
            );
        #endregion WindowHandle Styled Avalonia Property


        public MainWindow()
        {
            InitializeComponent();

            WindowHandle = (long) this.PlatformImpl.Handle.Handle;
        }
    }
}
