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
        public string ProcessPath { get; }
        private Process? _p;

        public IntPtr ProcessWindowHandle { get; private set; }

        public EmbeddedProcessWindow(string processPath)
        {
            ProcessPath = processPath;
        }

        public async Task StartProcess()
        {
            // start the process
            Process p = Process.Start(ProcessPath);

            _p = p;

            _p.Exited += _p_Exited;

            // wait until p.MainWindowHandle is non-zero
            while (true)
            {
                await Task.Delay(200);

                if (p.MainWindowHandle != (IntPtr)0)
                    break;
            }

            // set ProcessWindowHandle to the MainWindowHandle of the process
            ProcessWindowHandle = p.MainWindowHandle;
        }

        protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
        {
            // modify the style of the child window

            // get the old style of the child window
            long style = WinApi.GetWindowLongPtr(ProcessWindowHandle, -16);

            // modify the style of the ChildWindow - remove the embedded window's frame and other attributes of
            // a stand alone window. Add child flag
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

            // set the new style of the schild window
            WinApi.SetWindowLongPtr(handleRef, -16, (IntPtr)style);

            // set the parent of the ProcessWindowHandle to be the main window's handle
            WinApi.SetParent(ProcessWindowHandle, ((Window)e.Root).PlatformImpl.Handle.Handle);

            base.OnAttachedToVisualTree(e);
        }

        protected override IPlatformHandle CreateNativeControlCore(IPlatformHandle parent)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // return the ProcessWindowHandle
                return new PlatformHandle(ProcessWindowHandle, "ProcWinHandle");
            }
            else
            {
                return base.CreateNativeControlCore(parent);
            }
        }

        private void _p_Exited(object? sender, System.EventArgs e)
        {

        }
    }
}
