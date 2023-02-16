using System;
using Avalonia;
using System.Reflection;
using Avalonia.Controls;
using Avalonia.Platform;

namespace WinHostingApp
{
    public class EmbeddedHost : NativeControlHost
    {
        IntPtr _winHandle;

        public EmbeddedHost(IntPtr winHandle)
        {
            _winHandle = winHandle;
        }


        protected override IPlatformHandle CreateNativeControlCore(IPlatformHandle parent)
        {
            return new PlatformHandle(_winHandle, "Xid");
        }
    }
}
