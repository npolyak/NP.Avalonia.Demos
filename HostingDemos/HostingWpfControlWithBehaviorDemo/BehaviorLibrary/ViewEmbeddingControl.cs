﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Metadata;
using Avalonia.Platform;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms.Integration;

namespace BehaviorLibrary
{
    public class ViewEmbeddingControl : NativeControlHost
    {
        #region NativeObject Styled Avalonia Property
        [Content]
        public object? NativeObject
        {
            get { return GetValue(NativeObjectProperty); }
            set { SetValue(NativeObjectProperty, value); }
        }

        public static readonly StyledProperty<object?> NativeObjectProperty =
            AvaloniaProperty.Register<ViewEmbeddingControl, object?>
            (
                nameof(NativeObject)
            );
        #endregion NativeObject Styled Avalonia Property

        private System.Windows.Forms.Control? _host;


        #region Handle Styled Avalonia Property
        public IPlatformHandle? Handle
        {
            get { return GetValue(HandleProperty); }
            set { SetValue(HandleProperty, value); }
        }

        public static readonly StyledProperty<IPlatformHandle?> HandleProperty =
            AvaloniaProperty.Register<ViewEmbeddingControl, IPlatformHandle?>
            (
                nameof(Handle)
            );
        #endregion Handle Styled Avalonia Property


        public ViewEmbeddingControl()
        {
            this.GetObservable(NativeObjectProperty).Subscribe(OnNativeObjectChanged);
        }

        private void OnNativeObjectChanged(object? newNativeObj)
        {
            if (Handle != null)
            {
                DestroyNativeControlCore(Handle);
                Handle = null;
            }

            if (newNativeObj is System.Windows.Forms.Control winFormsControl)
            {
                _host = winFormsControl;
            }
            else if (newNativeObj is System.Windows.FrameworkElement el)
            {
                _host = new ElementHost { Child = el };
            }

            if (_host != null)
            {
                Handle = new PlatformHandle(_host.Handle, "Ctrl");
            }
        }

        protected override IPlatformHandle CreateNativeControlCore(IPlatformHandle parent)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return Handle;  
            }

            return base.CreateNativeControlCore(parent);
        }

        protected override void DestroyNativeControlCore(IPlatformHandle control)
        {
            base.DestroyNativeControlCore(control);
        }
    }
}
