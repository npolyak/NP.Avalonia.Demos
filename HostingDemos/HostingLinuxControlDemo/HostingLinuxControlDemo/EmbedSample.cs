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
                    LinuxView linuxView = new LinuxView();

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
                        GtkApi.gtk_widget_destroy(WidgetHandleToDestroy.Value);
                    }
                    return 0;
                }).Wait();

                return;
            }

            base.DestroyNativeControlCore(control);
        }
    }
}
