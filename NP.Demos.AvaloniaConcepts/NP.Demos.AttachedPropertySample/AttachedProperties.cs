using Avalonia;
using Avalonia.Controls;

namespace NP.Demos.AttachedPropertySample
{
    public static class AttachedProperties
    {
        #region RectangleStrokeThickness Attached Avalonia Property

        // Attached Property Getter
        public static double GetRectangleStrokeThickness(AvaloniaObject obj)
        {
            return obj.GetValue(RectangleStrokeThicknessProperty);
        }

        // Attached Property Setter
        public static void SetRectangleStrokeThickness(AvaloniaObject obj, double value)
        {
            obj.SetValue(RectangleStrokeThicknessProperty, value);
        }

        // Static field that of AttachedProperty<double> type. This field contains the
        // Attached Propertie's hashtable, the default value and the rest of the required 
        // functionality
        public static readonly AttachedProperty<double> RectangleStrokeThicknessProperty =
            AvaloniaProperty.RegisterAttached<object, Control, double>
            (
                "RectangleStrokeThickness", // property name
                3.0 // property default value
            );

        #endregion RectangleStrokeThickness Attached Avalonia Property
    }
}
