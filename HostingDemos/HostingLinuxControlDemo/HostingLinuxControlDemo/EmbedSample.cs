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
        private IntPtr? Handle { get; set; }

        protected override IPlatformHandle CreateNativeControlCore(IPlatformHandle parent)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {

                return GtkInteropHelper.RunOnGlibThread(() =>
                {
                    LinuxView linuxView = new LinuxView();

                    Handle = linuxView.Window.Handle;

                    IntPtr xid = GtkApi.gdk_x11_window_get_xid(Handle.Value);

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
                    if (Handle != null)
                    {
                        GtkApi.gtk_widget_destroy(Handle.Value);
                    }
                    return 0;
                }).Wait();

                return;
            }

            base.DestroyNativeControlCore(control);
        }
    }
}
