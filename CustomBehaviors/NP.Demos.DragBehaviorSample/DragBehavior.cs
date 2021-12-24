using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.VisualTree;
using System;
using System.Linq;

namespace NP.Demos.DragBehaviorSample
{
    public class DragBehavior
    {
        #region IsSet Attached Avalonia Property
        public static bool GetIsSet(IControl obj)
        {
            return obj.GetValue(IsSetProperty);
        }

        public static void SetIsSet(IControl obj, bool value)
        {
            obj.SetValue(IsSetProperty, value);
        }

        public static readonly AttachedProperty<bool> IsSetProperty =
            AvaloniaProperty.RegisterAttached<DragBehavior, IControl, bool>
            (
                "IsSet"
            );
        #endregion IsSet Attached Avalonia Property


        #region StartPointerLocation Attached Avalonia Property
        private static Point GetStartPointerLocation(IControl obj)
        {
            return obj.GetValue(StartPointerLocationProperty);
        }

        private static void SetStartPointerLocation(IControl obj, Point value)
        {
            obj.SetValue(StartPointerLocationProperty, value);
        }

        private static readonly AttachedProperty<Point> StartPointerLocationProperty =
            AvaloniaProperty.RegisterAttached<DragBehavior, IControl, Point>
            (
                "StartPointerLocation"
            );
        #endregion StartPointerLocation Attached Avalonia Property


        #region StartControlPosition Attached Avalonia Property
        private static Point GetStartControlPosition(IControl obj)
        {
            return obj.GetValue(StartControlPositionProperty);
        }

        private static void SetStartControlPosition(IControl obj, Point value)
        {
            obj.SetValue(StartControlPositionProperty, value);
        }

        private static readonly AttachedProperty<Point> StartControlPositionProperty =
            AvaloniaProperty.RegisterAttached<DragBehavior, IControl, Point>
            (
                "StartControlPosition"
            );
        #endregion StartControlPosition Attached Avalonia Property


        static DragBehavior()
        {
            IsSetProperty.Changed.Subscribe(OnIsSetChanged);
        }

        private static void OnIsSetChanged(AvaloniaPropertyChangedEventArgs<bool> args)
        {
            IControl control = (IControl) args.Sender;

            if (args.NewValue.Value == true)
            {
                control.RenderTransform = new TranslateTransform();
                control.PointerPressed += Control_PointerPressed;
            }
            else
            {
                control.RenderTransform = null;
                control.PointerPressed -= Control_PointerPressed;
            }
        }

        private static Window GetWindow(IControl control)
        {
            return control.GetVisualAncestors().OfType<Window>().FirstOrDefault()!;
        }

        public static Point GetCurrentPointerPositionInWindow(IControl control, PointerEventArgs e)
        {
            return e.GetPosition(GetWindow(control));
        }

        private static void Control_PointerPressed(object? sender, PointerPressedEventArgs e)
        {
            IControl control = (IControl)sender!;
            e.Pointer.Capture(control);

            Window w = GetWindow(control);

            Point currentPointerPositionInWindow = GetCurrentPointerPositionInWindow(control, e);
            
            SetStartPointerLocation(control, currentPointerPositionInWindow);

            Point startControlPosition = 
                new Point
                (
                    (control.RenderTransform as TranslateTransform)!.X,
                    (control.RenderTransform as TranslateTransform)!.Y);

            SetStartControlPosition(control, startControlPosition);

            control.PointerMoved += Control_PointerMoved;
            control.PointerReleased += Control_PointerReleased;
        }

        private static void Control_PointerReleased(object? sender, PointerReleasedEventArgs e)
        {
            IControl control = (IControl)sender!;

            e.Pointer.Capture(null);

            ShiftControl(control, e);
            control.PointerMoved -= Control_PointerMoved;
            control.PointerReleased -= Control_PointerReleased;
        }

        private static void Control_PointerMoved(object? sender, PointerEventArgs e)
        {
            IControl control = (IControl)sender!;
            ShiftControl(control, e);
        }

        private static void ShiftControl(IControl control, PointerEventArgs e)
        {
            Point currentPointerPosition = GetCurrentPointerPositionInWindow(control, e);

            Point startPointerPosition = GetStartPointerLocation(control);

            Point diff = currentPointerPosition - startPointerPosition;

            Point startControlPosition = GetStartControlPosition(control);

            Point shift = diff + startControlPosition;

            (control.RenderTransform as TranslateTransform).X = shift.X;
            (control.RenderTransform as TranslateTransform).Y = shift.Y;
        }
    }
}
