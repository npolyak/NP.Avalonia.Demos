﻿using System.Runtime.InteropServices;
using System;

#if !WINDOWS
namespace PolyFills
{
    public static unsafe class GtkHelper
    {
        private const string GdkName = "libgdk-3.so.0";
        private const string GtkName = "libgtk-3.so.0";
        [DllImport(GdkName)]
        public static extern IntPtr gdk_x11_window_get_xid(IntPtr window);

        [DllImport(GtkName)]
        public static extern void gtk_widget_destroy(IntPtr gtkWidget);
    }
}
#endif
