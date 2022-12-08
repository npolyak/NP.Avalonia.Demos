/// borrowed from Avalonia source repository from Avalonia/Samples/Interop/NativeEmbedSample
using System.Runtime.InteropServices;
using System;

namespace HostingWinFormsDemo
{
    public static unsafe class WinApi
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static unsafe extern bool DestroyWindow(IntPtr hwnd);
    }
}
