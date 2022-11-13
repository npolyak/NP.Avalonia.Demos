using Avalonia.Controls;
using Avalonia.Controls.Platform;
using Avalonia.Platform;
using Avalonia.X11.Interop;
using Gtk;
using LinuxControl;
using System;
using System.Runtime.InteropServices;
using ViewModels;

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
