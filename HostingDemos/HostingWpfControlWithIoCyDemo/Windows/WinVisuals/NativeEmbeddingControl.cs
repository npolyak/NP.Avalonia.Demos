using Avalonia;
using Avalonia.Controls;
using Avalonia.Metadata;
using Avalonia.Platform;
using Avalonia.Styling;
using Interfaces;
using NP.Utilities.Attributes;
using System;
using System.Runtime.InteropServices;
#if WINDOWS
using System.Windows.Forms.Integration;
#endif 

namespace WinVisuals
{
    public class NativeEmbeddingControl : ContentControl, IStyleable
    {
        public Type StyleKey { get; } = typeof(ContentControl);

        private NativeHostingControl _nativeHostingControl = new NativeHostingControl();

        private void OnHandleChanged(IPlatformHandle obj)
        {
            SetContent();
        }

        private void SetContent()
        {
            if (Handle == null)
            {
                Content = DefaultObject;
            }
            else
            {
                Content = _nativeHostingControl;
            }
        }

#region DefaultObject Styled Avalonia Property
        public IAvaloniaObject DefaultObject
        {
            get { return GetValue(DefaultObjectProperty); }
            set { SetValue(DefaultObjectProperty, value); }
        }

        public static readonly StyledProperty<IAvaloniaObject> DefaultObjectProperty =
            AvaloniaProperty.Register<NativeEmbeddingControl, IAvaloniaObject>
            (
                nameof(DefaultObject)
            );
#endregion DefaultObject Styled Avalonia Property

        private void OnDefaultObjChanged(IAvaloniaObject obj)
        {
            SetContent();
        }


#region WindowsNativeObject Styled Avalonia Property
        public object WindowsNativeObject
        {
            get { return GetValue(WindowsNativeObjectProperty); }
            set { SetValue(WindowsNativeObjectProperty, value); }
        }

        public static readonly StyledProperty<object> WindowsNativeObjectProperty =
            AvaloniaProperty.Register<NativeEmbeddingControl, object>
            (
                nameof(WindowsNativeObject)
            );
#endregion WindowsNativeObject Styled Avalonia Property

        public IPlatformHandle? Handle
        {
            get => _nativeHostingControl.Handle;
            set => _nativeHostingControl.Handle = value;
        }


#region NativeObject Styled Avalonia Property
        public object NativeObject
        {
            get { return GetValue(NativeObjectProperty); }
            private set { SetValue(NativeObjectProperty, value); }
        }

        public static readonly StyledProperty<object> NativeObjectProperty =
            AvaloniaProperty.Register<NativeEmbeddingControl, object>
            (
                nameof(NativeObject)
            );
#endregion NativeObject Styled Avalonia Property


        public NativeEmbeddingControl()
        {
            SetContent();
            _nativeHostingControl
                .GetObservable(NativeHostingControl.HandleProperty)
                .Subscribe(OnHandleChanged!);

            this.GetObservable(DefaultObjectProperty)
                .Subscribe(OnDefaultObjChanged);

            this.GetObservable(NativeObjectProperty)
                .Subscribe(OnNativeObjectChanged);

            this.GetObservable(WindowsNativeObjectProperty)
                .Subscribe(OnWindowsNativeObjectChanged);
        }

        private void OnWindowsNativeObjectChanged(object obj)
        {
            this.NativeObject = obj;
        }

        private void OnNativeObjectChanged(object? newNativeObj)
        {
            if (Handle != null)
            {
                _nativeHostingControl.DestroyNativeControlHandle();
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
#if WINDOWS
                System.Windows.Forms.Control? host = null;

                if (newNativeObj is System.Windows.Forms.Control winFormsControl)
                {
                    host = winFormsControl;
                }
                else if (newNativeObj is System.Windows.FrameworkElement el)
                {
                    host = new ElementHost { Child = el };
                }

                if (host != null)
                {
                    Handle = new PlatformHandle(host.Handle, "Ctrl");
                }
#endif
            }
        }
    }
}
