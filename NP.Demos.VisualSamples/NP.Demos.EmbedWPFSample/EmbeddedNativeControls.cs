using Avalonia.Controls;
using Avalonia.Platform;

#if WINDOWS
using WpfControl;
#endif

namespace NP.Demos.EmbedWinFormsSample
{
    public class EmbeddedNativeControls : NativeControlHost
    {
        protected override IPlatformHandle CreateNativeControlCore(IPlatformHandle parent)
        {
#if WINDOWS
            return new PlatformHandle(SimpleUserControl.GetElementHost(), "CTRL");
#else
            return base.CreateNativeControlCore(parent);
#endif
        }

        protected override void DestroyNativeControlCore(IPlatformHandle control)
        {
            base.DestroyNativeControlCore(control);
        }
    }
}
