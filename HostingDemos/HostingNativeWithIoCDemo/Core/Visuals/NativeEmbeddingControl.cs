﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Platform;
using PolyFills;

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
                // if handle property is not null, return it
                return Handle;
            }
         
            return base.CreateNativeControlCore(parent!);
        }

        protected override void DestroyNativeControlCore(IPlatformHandle? handle)
        {
            // call extension method HandleBuilder.DestroyHandle() of PolyFill project
            handle.DestroyHandle();
        }
    }
}
