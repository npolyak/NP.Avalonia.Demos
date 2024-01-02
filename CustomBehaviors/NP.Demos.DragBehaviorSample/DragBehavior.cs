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
        public static bool GetIsSet(Control obj)
        {
            return obj.GetValue(IsSetProperty);
        }

        public static void SetIsSet(Control obj, bool value)
        {
            obj.SetValue(IsSetProperty, value);
        }

        public static readonly AttachedProperty<bool> IsSetProperty =
            AvaloniaProperty.RegisterAttached<DragBehavior, Control, bool>
            (
                "IsSet"
            );
        #endregion IsSet Attached Avalonia Property

        private static Point GetShift(Control control)
        {
            TranslateTransform translateTransform = (TranslateTransform) control.RenderTransform!;
            return new Point(translateTransform.X, translateTransform.Y);
        }

        private static void SetShift(Control control, Point shift)
        {
            TranslateTransform translateTransform = (TranslateTransform)control.RenderTransform!;

            translateTransform.X = shift.X;
            translateTransform.Y = shift.Y;
        }

        #region InitialPointerLocation Attached Avalonia Property
        private static Point GetInitialPointerLocation(Control obj)
        {
            return obj.GetValue(InitialPointerLocationProperty);
        }

        private static void SetInitialPointerLocation(Control obj, Point value)
        {
            obj.SetValue(InitialPointerLocationProperty, value);
        }

        private static readonly AttachedProperty<Point> InitialPointerLocationProperty =
            AvaloniaProperty.RegisterAttached<DragBehavior, Control, Point>
            (
                "InitialPointerLocation"
            );
        #endregion InitialPointerLocation Attached Avalonia Property


        #region InitialDragShift Attached Avalonia Property
        public static Point GetInitialDragShift(Control obj)
        {
            return obj.GetValue(InitialDragShiftProperty);
        }

        public static void SetInitialDragShift(Control obj, Point value)
        {
            obj.SetValue(InitialDragShiftProperty, value);
        }

        public static readonly AttachedProperty<Point> InitialDragShiftProperty =
            AvaloniaProperty.RegisterAttached<DragBehavior, Control, Point>
            (
                "InitialDragShift"
            );
        #endregion InitialDragShift Attached Avalonia Property

        static DragBehavior()
        {
            IsSetProperty.Changed.Subscribe(OnIsSetChanged);
        }

        // set the PointerPressed handler when 
        private static void OnIsSetChanged(AvaloniaPropertyChangedEventArgs<bool> args)
        {
            Control control = (Control) args.Sender;

            if (args.NewValue.Value == true)
            {
                // connect the pointer pressed event handler
                control.RenderTransform = new TranslateTransform();
                control.PointerPressed += Control_PointerPressed;
            }
            else
            {
                // disconnect the pointer pressed event handler
                control.RenderTransform = null;
                control.PointerPressed -= Control_PointerPressed;
            }
        }

        private static Window GetWindow(Control control)
        {
            return control.GetVisualAncestors().OfType<Window>().FirstOrDefault()!;
        }

        public static Point GetCurrentPointerPositionInWindow(Control control, PointerEventArgs e)
        {
            return e.GetPosition(GetWindow(control));
        }

        // start drag by pressing the point on draggable control
        private static void Control_PointerPressed(object? sender, PointerPressedEventArgs e)
        {
            Control control = (Control)sender!;

            // capture the pointer on the control
            // meaning - the mouse pointer will be producing the
            // pointer events on the control
            // even if it is not directly above the control
            e.Pointer.Capture(control);

            // calculate the drag-initial pointer position within the window
            Point currentPointerPositionInWindow = GetCurrentPointerPositionInWindow(control, e);
            
            // record the drag-initial pointer position within the window
            SetInitialPointerLocation(control, currentPointerPositionInWindow);

            Point startControlPosition = GetShift(control);

            // record the drag-initial shift of the control
            SetInitialDragShift(control, startControlPosition);

            // add handler to do the shift and 
            // other processing on PointerMoved
            // and PointerReleased events. 
            control.PointerMoved += Control_PointerMoved;
            control.PointerReleased += Control_PointerReleased;
        }

        // update the shift when pointer is moved
        private static void Control_PointerMoved(object? sender, PointerEventArgs e)
        {
            Control control = (Control)sender!;
            // Shift control to the current position
            ShiftControl(control, e);
        }


        // Drag operation ends when the pointer is released. 
        private static void Control_PointerReleased(object? sender, PointerReleasedEventArgs e)
        {
            Control control = (Control)sender!;

            // release the capture
            e.Pointer.Capture(null);

            ShiftControl(control, e);

            // disconnect the handlers 
            control.PointerMoved -= Control_PointerMoved;
            control.PointerReleased -= Control_PointerReleased;
        }


        // modifies the shift on the control during the drag
        // this essentially moves the control
        private static void ShiftControl(Control control, PointerEventArgs e)
        {
            // get the current pointer location
            Point currentPointerPosition = GetCurrentPointerPositionInWindow(control, e);

            // get the pointer location when Drag operation was started
            Point startPointerPosition = GetInitialPointerLocation(control);

            // diff is how far the pointer shifted
            Point diff = currentPointerPosition - startPointerPosition;

            // get the original shift when the drag operation started
            Point startControlPosition = GetInitialDragShift(control);

            // get the resulting shift as the sum of 
            // pointer shift during the drag and the original shift
            Point shift = diff + startControlPosition;

            // set the shift on the control
            SetShift(control, shift);
        }
    }
}
