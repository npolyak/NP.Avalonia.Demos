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
                MyControl myControl = new MyControl();

                return new PlatformHandle(myControl.Handle, "Hndl");
            }
            return base.CreateNativeControlCore(parent);
        }
    }
}
