using Avalonia.Controls;
using Avalonia.Platform;
using System.Runtime.InteropServices;
using WpfControlToHost;
using System.Windows.Forms.Integration;

namespace HostingWinFormsDemo
{
    public class EmbedSample : NativeControlHost
    {
        protected override IPlatformHandle CreateNativeControlCore(IPlatformHandle parent)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                MyWpfUserControl myControl = new MyWpfUserControl();

                ElementHost elementHost = new ElementHost();

                elementHost.Child = myControl;

                return new PlatformHandle(elementHost.Handle, "Hndl");
            }
            return base.CreateNativeControlCore(parent);
        }
    }
}
