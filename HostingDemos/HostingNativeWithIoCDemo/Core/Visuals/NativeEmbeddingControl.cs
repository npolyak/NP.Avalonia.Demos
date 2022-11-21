using Avalonia;
using Avalonia.Controls;
using Avalonia.Platform;

namespace Visuals
{
    public class NativeEmbeddingControl : NativeControlHost
    {

        #region Handle Styled Avalonia Property
        public IPlatformHandle? Handle
        {
            get { return GetValue(HandleProperty); }
            set { SetValue(HandleProperty, value); }
        }

        public static readonly StyledProperty<IPlatformHandle?> HandleProperty =
            AvaloniaProperty.Register<NativeEmbeddingControl, IPlatformHandle?>
            (
                nameof(Handle)
            );
        #endregion Handle Styled Avalonia Property


        protected override IPlatformHandle CreateNativeControlCore(IPlatformHandle? parent)
        {
            if (Handle != null)
            {
                return Handle;
            }

            return base.CreateNativeControlCore(parent);
        }

        protected override void DestroyNativeControlCore(IPlatformHandle? handle)
        {
            if (handle != null)
            {
                base.DestroyNativeControlCore(handle);
            }
        }
    }
}
