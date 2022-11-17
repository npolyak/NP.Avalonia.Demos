using Avalonia.Controls;
using Avalonia.Controls.Platform;
using Avalonia.Platform;
#if WINDOWS
using System.Windows.Forms.Integration;
#else
using Avalonia.X11.Interop;
using Gtk;
#endif

namespace PolyFills
{
    public static class HandleBuilder
    {
#if WINDOWS
        public static IPlatformHandle FormToHandle(this System.Windows.Forms.Control control)
        {
            return new PlatformHandle(control.Handle, "CTRL");   
        }
#endif

#if !WINDOWS
        private static ControlWrapper? CreateHandleImpl(object obj)
        {
            if (obj is Gtk.Window window)
            {
                if (!window.IsVisible)
                {
                    window.Show();
                }
                return new ControlWrapper(window);
            }
            else if (obj is Widget widget)
            {
                if (widget.Window == null || widget.Window.Handle == IntPtr.Zero)
                {
                    Gtk.Window win = new Gtk.Window(WindowType.Toplevel);

                    win.Add(widget);
                    win.Show();
                }

                return new ControlWrapper(widget);
            }

            return null;
        }
#endif

        public static IPlatformHandle? BuildHandle(object obj)
        {
#if WINDOWS
            if (obj is System.Windows.Forms.Control control)
            {
                return control.FormToHandle();
            }
            else if (obj is System.Windows.FrameworkElement el)
            {
                ElementHost elementHost = new ElementHost();
                elementHost.Child = el;

                return elementHost.FormToHandle();
            }
            else
            {
                return null;
            }
#else // Linux
            return GtkInteropHelper.RunOnGlibThread(() =>
            {
                return CreateHandleImpl(obj);
            }).Result;
#endif
        }

        public static IPlatformHandle? BuildObjAndHandle(Func<object> objBuilder)
        {
#if WINDOWS
            object obj = objBuilder();

            return BuildHandle(obj);
#else // Linux
            return GtkInteropHelper.RunOnGlibThread(() =>
            {
                object obj = objBuilder();
                ControlWrapper controlWrapper = CreateHandleImpl(obj);

                return controlWrapper;
            }).Result;
#endif
        }
    }

#if !WINDOWS
    class ControlWrapper : INativeControlHostDestroyableControlHandle
    {
        private readonly IntPtr _widgetHandle;

        public IntPtr Handle { get; }

        private Gdk.Window Window { get; }

        public ControlWrapper(Gtk.Widget widget)
        {
            _widgetHandle = widget.Handle;

            Window = widget.Window;

            Handle = GtkHelper.gdk_x11_window_get_xid(widget.Window.Handle);

            if (!Window.IsVisible)
            {
                Window.Show();
            }
        }

        public string? HandleDescriptor => "XID";

        public void Destroy()
        {
            GtkInteropHelper.RunOnGlibThread(() =>
            {
                GtkHelper.gtk_widget_destroy(_widgetHandle);
                return 0;
            }).Wait();
        }
    }
#endif
}
