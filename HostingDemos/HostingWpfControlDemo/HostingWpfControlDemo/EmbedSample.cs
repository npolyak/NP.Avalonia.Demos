using Avalonia.Controls;
using Avalonia.Platform;
using System.Runtime.InteropServices;
using WpfControl;
using System.Windows.Forms.Integration;

namespace HostingWinFormsDemo
{
    public class EmbedSample : NativeControlHost
    {
        protected override IPlatformHandle CreateNativeControlCore(IPlatformHandle parent)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // create the WPF view
                MyWpfUserControl myControl = new MyWpfUserControl();

                // use ElementHost to produce a win32 Handle for embedding
                ElementHost elementHost = new ElementHost();

                elementHost.Child = myControl;

                return new PlatformHandle(elementHost.Handle, "Hndl");
            }
            return base.CreateNativeControlCore(parent);
        }

        protected override void DestroyNativeControlCore(IPlatformHandle control)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // destroy the win32 window
                WinApi.DestroyWindow(control.Handle);

                return;
            }

            base.DestroyNativeControlCore(control);
        }
    }
}
