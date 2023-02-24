using System;
using System.IO;
using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace WinHostingApp
{
    public partial class MainWindow : Window
    {

        #region WindowHandleStr Styled Avalonia Property
        public string WindowHandleStr
        {
            get { return GetValue(WindowHandleStrProperty); }
            set { SetValue(WindowHandleStrProperty, value); }
        }

        public static readonly StyledProperty<string> WindowHandleStrProperty =
            AvaloniaProperty.Register<MainWindow, string>
            (
                nameof(WindowHandleStr)
            );
        #endregion WindowHandleStr Styled Avalonia Property


        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void Submit()
        {
            IntPtr handle = (IntPtr) nint.Parse(WindowHandleStr);

            Decorator hostingPanel = this.FindControl<Decorator>("HostingPanel");

            hostingPanel.Child = new EmbeddedHost(handle);
        }
    }
}
