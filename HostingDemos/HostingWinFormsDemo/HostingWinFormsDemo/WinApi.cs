﻿using System.Runtime.InteropServices;
using System;

namespace HostingWinFormsDemo
{
    public static unsafe class WinApi
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool DestroyWindow(IntPtr hwnd);
    }
}
