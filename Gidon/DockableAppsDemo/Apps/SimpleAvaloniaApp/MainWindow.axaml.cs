using Avalonia;
using Avalonia.Controls;
using Avalonia.X11.Interop;
using NP.Avalonia.Visuals.Controls;
using NP.Avalonia.Visuals.WindowsOnly;
using NP.Gidon.Messages;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SimpleAvaloniaApp
{
    public partial class MainWindow : Window
    {
        #region CurrentProcessId Styled Avalonia Property
        public nint CurrentProcessId
        {
            get { return GetValue(CurrentProcessIdProperty); }
            set { SetValue(CurrentProcessIdProperty, value); }
        }

        public static readonly StyledProperty<nint> CurrentProcessIdProperty =
            AvaloniaProperty.Register<MainWindow, nint>
            (
                nameof(CurrentProcessId)
            );
        #endregion CurrentProcessId Styled Avalonia Property


        #region UniqueWindowHostId Styled Avalonia Property
        public string UniqueWindowHostId
        {
            get { return GetValue(UniqueWindowHostIdProperty); }
            set { SetValue(UniqueWindowHostIdProperty, value); }
        }

        public static readonly StyledProperty<string> UniqueWindowHostIdProperty =
            AvaloniaProperty.Register<MainWindow, string>
            (
                nameof(UniqueWindowHostId)
            );
        #endregion UniqueWindowHostId Styled Avalonia Property


        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(string uniqueWindowId) : this()
        {
            UniqueWindowHostId = uniqueWindowId;

            this.Opened += MainWindow_Opened;
        }

        private void MainWindow_Opened(object? sender, System.EventArgs e)
        {
            CurrentProcessId = Process.GetCurrentProcess().Id;

            nint winHandle = this.GetWinHandle();

            WindowInfo windowInfo = new WindowInfo { WindowHandle = (nint)winHandle, UniqueWindowHostId = this.UniqueWindowHostId };

            App.TheRelayClient.Publish(Topic.WindowInfoTopic, windowInfo);
        }
    }
}
