using System.Runtime.InteropServices;
using System;

namespace HostingNativeDemo
{
// Only compile the class when WINDOWS is not defined.
#if !WINDOWS
    public static unsafe class GtkApi
    {
        private const string GdkName = "libgdk-3.so.0";
        private const string GtkName = "libgtk-3.so.0";
        [DllImport(GdkName)]
        // return the X11 handle for the linux window
        public static extern IntPtr gdk_x11_window_get_xid(IntPtr window);

        [DllImport(GtkName)]
        // destroys the gtk window or widget
        public static extern void gtk_widget_destroy(IntPtr gtkWidget);
    }
#endif
}
