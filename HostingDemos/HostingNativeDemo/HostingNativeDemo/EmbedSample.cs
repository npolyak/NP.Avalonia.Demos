using Avalonia.Controls;
using Avalonia.Platform;
using System;
using System.Runtime.InteropServices;

#if WINDOWS
using System.Windows.Forms.Integration;
using ViewModels;
using WpfControl;
#else
using LinuxControl;
using Avalonia.X11.Interop;
#endif 

namespace HostingNativeDemo
{
    public class EmbedSample : NativeControlHost
    {
#if !WINDOWS
        private IntPtr? WidgetHandleToDestroy { get; set; }
#endif

        protected override IPlatformHandle CreateNativeControlCore(IPlatformHandle parent)
        {
#if WINDOWS
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {

                MyWpfUserControl control = new MyWpfUserControl();
                control.DataContext = new ClickCounterViewModel();

                ElementHost host = new ElementHost{ Child = control };

                return new PlatformHandle(host.Handle, "Ctrl");

            }
#else
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return GtkInteropHelper.RunOnGlibThread(() =>
                {
                    // create the linux view
                    LinuxView linuxView = new LinuxView();

                    // store the widget handle for the window to destroy at the end
                    WidgetHandleToDestroy = linuxView.Handle;

                    // get Xid from Gdk window
                    IntPtr xid = GtkApi.gdk_x11_window_get_xid(linuxView.Window.Handle);

                    return new PlatformHandle(xid, "Xid");
                }).Result;

            }
#endif

            return base.CreateNativeControlCore(parent);
        }

        protected override void DestroyNativeControlCore(IPlatformHandle control)
        {
#if WINDOWS
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // destroy the win32 window
                WinApi.DestroyWindow(control.Handle);

                return;
            }
#else
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                GtkInteropHelper.RunOnGlibThread(() =>
                {
                    if (WidgetHandleToDestroy != null)
                    {
                        // destroy the widget handle of the window
                        GtkApi.gtk_widget_destroy(WidgetHandleToDestroy.Value);
                        WidgetHandleToDestroy = null;
                    }
                    return 0;
                }).Wait();

                return;
            }
#endif

            base.DestroyNativeControlCore(control);
        }
    }
}
