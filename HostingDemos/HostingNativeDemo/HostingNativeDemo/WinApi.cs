using System;
using System.Runtime.InteropServices;

namespace HostingNativeDemo
{
#if WINDOWS
    public static unsafe class WinApi
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static unsafe extern bool DestroyWindow(IntPtr hwnd);
    }
#endif
}
