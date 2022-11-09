using Avalonia.Platform;
using Avalonia;
using System.Reflection.Metadata;
using Avalonia.Controls;

namespace WinVisuals
{
    public class NativeHostingControl : NativeControlHost
    {
        #region Handle Styled Avalonia Property
        public IPlatformHandle? Handle
        {
            get { return GetValue(HandleProperty); }
            internal set { SetValue(HandleProperty, value); }
        }

        public static readonly StyledProperty<IPlatformHandle?> HandleProperty =
            AvaloniaProperty.Register<NativeHostingControl, IPlatformHandle?>
            (
                nameof(Handle)
            );
        #endregion Handle Styled Avalonia Property

        protected override IPlatformHandle CreateNativeControlCore(IPlatformHandle parent)
        {
            if (Handle != null)
            {
                return Handle;
            }

            return base.CreateNativeControlCore(parent);
        }

        protected override void DestroyNativeControlCore(IPlatformHandle control)
        {
            base.DestroyNativeControlCore(control);
        }

        internal void DestroyNativeControlHandle()
        {
            if (Handle != null)
            {
                DestroyNativeControlCore(Handle);
                Handle = null;
            }
        }
    }
}