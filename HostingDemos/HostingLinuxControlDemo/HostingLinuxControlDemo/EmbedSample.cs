using Avalonia.Controls;
using Avalonia.Platform;
using Avalonia.X11.Interop;
using LinuxControl;
using System;
using System.Runtime.InteropServices;

namespace HostingLinuxControlDemo
{
    public class EmbedSample : NativeControlHost
    {
        private IntPtr? WidgetHandleToDestroy { get; set; }

        protected override IPlatformHandle CreateNativeControlCore(IPlatformHandle parent)
        {
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
            return base.CreateNativeControlCore(parent);
        }

        protected override void DestroyNativeControlCore(IPlatformHandle control)
        {
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

            base.DestroyNativeControlCore(control);
        }
    }
}
