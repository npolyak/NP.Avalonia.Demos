using Avalonia.Controls;
using Avalonia.Platform;
using System.Runtime.InteropServices;

namespace HostingWinFormsDemo
{
    public class EmbedSample : NativeControlHost
    {
        protected override IPlatformHandle CreateNativeControlCore(IPlatformHandle parent)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return LinuxControl.LinuxView.Create();
            }
            return base.CreateNativeControlCore(parent);
        }
    }
}
