using Avalonia.Controls;
using Avalonia.Platform;
using MyWinFormsControl;
using System.Runtime.InteropServices;

namespace HostingWinFormsDemo
{
    public class EmbedSample : NativeControlHost
    {
        protected override IPlatformHandle CreateNativeControlCore(IPlatformHandle parent)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // on Windows, return the win32 handle to MyControl packed
                // as PlatformHandle object
                MyControl myControl = new MyControl();

                return new PlatformHandle(myControl.Handle, "Hndl");
            }

            // otherwise, return default
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
