using Avalonia.Controls;
using Avalonia.Platform;
using System.Runtime.InteropServices;

#if WINDOWS
using System.Windows.Forms.Integration;
using ViewModels;
using WpfControl;
#endif 

namespace HostingWinFormsDemo
{
    public class EmbedSample : NativeControlHost
    {
        protected override IPlatformHandle CreateNativeControlCore(IPlatformHandle parent)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
#if WINDOWS
                MyWpfUserControl control = new MyWpfUserControl();
                control.DataContext = new ClickCounterViewModel();

                ElementHost host = new ElementHost{ Child = control };

                return new PlatformHandle(host.Handle, "Ctrl");
#endif
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
#if !WINDOWS
                return LinuxControl.LinuxView.Create();
#endif
            }

            return base.CreateNativeControlCore(parent);
        }
    }
}
