using Avalonia;
using Avalonia.Controls;
using Avalonia.Platform;
using Avalonia.X11.Interop;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace HostingLunuxProcessDemo
{
    public class EmbeddedProcessWindow : NativeControlHost
    {
        public string ProcessPath { get; }
        private Process _p;

        public IntPtr ProcessWindowHandle { get; private set; }

        public EmbeddedProcessWindow(string processPath)
        {
            ProcessPath = processPath;

        }
        public async Task StartProcess()
        {
            Process p = Process.Start(ProcessPath);

            _p = p;

            _p.Exited += _p_Exited;

            while (true)
            {
                await Task.Delay(200);

                if (p.MainWindowHandle != (IntPtr)0)
                    break;
            }

            ProcessWindowHandle = p.MainWindowHandle;
        }




        protected override IPlatformHandle CreateNativeControlCore(IPlatformHandle parent)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {

                return GtkInteropHelper.RunOnGlibThread(() =>
                {
                    IntPtr xid = GtkApi.gdk_x11_window_get_xid(ProcessWindowHandle);

                    return new PlatformHandle(ProcessWindowHandle, "ProcLinuxHandle");
                }).Result;
            }
            return base.CreateNativeControlCore(parent);
        }

        private void _p_Exited(object? sender, System.EventArgs e)
        {

        }
    }
}
