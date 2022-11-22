using Avalonia;
using Avalonia.Controls;
using Avalonia.Platform;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace HostingWindowsProcessDemo
{
    public class EmbeddedProcessWindow : NativeControlHost
    {
        public string ProcessPath;
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

        protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
        {
            WinApi.SetParent(ProcessWindowHandle, ((Window) e.Root).PlatformImpl.Handle.Handle);


            long style = WinApi.GetWindowLongPtr(ProcessWindowHandle, -16);

            style &= ~0x00010000;
            style &= ~0x00800000;
            style &= ~0x80000000;
            style &= ~0x00400000;
            style &= ~0x00080000;
            style &= ~0x00020000;
            style &= ~0x00040000;
            style |= 0x40000000; // child

            HandleRef handleRef =
                new HandleRef(null, ProcessWindowHandle);


            WinApi.SetWindowLongPtr(handleRef, -16, (IntPtr)style);

            base.OnAttachedToVisualTree(e);
        }

        private void _p_Exited(object? sender, System.EventArgs e)
        {
           
        }

        protected override IPlatformHandle CreateNativeControlCore(IPlatformHandle parent)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return new PlatformHandle(ProcessWindowHandle, "ProcWinHandle");
            }
            else
            {
                return base.CreateNativeControlCore(parent);
            }

        }
    }
}
