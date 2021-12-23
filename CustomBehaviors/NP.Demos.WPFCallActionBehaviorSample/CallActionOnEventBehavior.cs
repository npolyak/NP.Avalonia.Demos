using System.Windows;
using System.Reflection;

namespace NP.Demos.WPFCallActionBehaviorSample
{
    public static class CallActionOnEventBehavior
    {
        #region TheEvent attached Property
        public static RoutedEvent GetTheEvent(DependencyObject obj)
        {
            return (RoutedEvent)obj.GetValue(TheEventProperty);
        }

        public static void SetTheEvent(DependencyObject obj, RoutedEvent value)
        {
            obj.SetValue(TheEventProperty, value);
        }

        public static readonly DependencyProperty TheEventProperty =
        DependencyProperty.RegisterAttached
        (
            "TheEvent",
            typeof(RoutedEvent),
            typeof(CallActionOnEventBehavior),
            new PropertyMetadata(default(RoutedEvent), OnEventChanged /* callback */)
        );

        private static void OnEventChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // we can only set the behavior on FrameworkElement - almost any visual element
            FrameworkElement el = (FrameworkElement)d;

            RoutedEvent oldRoutedEvent = e.OldValue as RoutedEvent;

            if (oldRoutedEvent != null)
            {
                // remove old event handler from the object (if exists)
                el.RemoveHandler(oldRoutedEvent, (RoutedEventHandler)HandleRoutedEvent);
            }

            RoutedEvent newRoutedEvent = e.NewValue as RoutedEvent;

            if (newRoutedEvent != null)
            {
                // add new event handler to the object
                el.AddHandler(newRoutedEvent, (RoutedEventHandler) HandleRoutedEvent);
            }
        }
        #endregion TheEvent attached Property

        // handle the routed event when happens on the object
        // by calling the method of name 'methodName' onf the
        // TargetObject
        private static void HandleRoutedEvent(object sender, RoutedEventArgs e)
        {
            FrameworkElement el = (FrameworkElement)sender;

            // if TargetObject is not set, use DataContext as the target object
            object targetObject = GetTargetObject(el) ?? el.DataContext;

            string methodName = GetMethodToCall(el);

            // do not do anything
            if (targetObject == null || methodName == null)
            {
                return;
            }

            MethodInfo methodInfo = 
                targetObject.GetType().GetMethod(methodName);

            if (methodInfo == null)
            {
                return;
            }

            // call the method using reflection
            methodInfo.Invoke(targetObject, null);
        }

        #region TargetObject attached Property
        public static object GetTargetObject(DependencyObject obj)
        {
            return (object)obj.GetValue(TargetObjectProperty);
        }

        public static void SetTargetObject(DependencyObject obj, object value)
        {
            obj.SetValue(TargetObjectProperty, value);
        }

        public static readonly DependencyProperty TargetObjectProperty =
        DependencyProperty.RegisterAttached
        (
            "TargetObject",
            typeof(object),
            typeof(CallActionOnEventBehavior),
            new PropertyMetadata(default(object))
        );
        #endregion TargetObject attached Property


        #region MethodToCall attached Property
        public static string GetMethodToCall(DependencyObject obj)
        {
            return (string)obj.GetValue(MethodToCallProperty);
        }

        public static void SetMethodToCall(DependencyObject obj, string value)
        {
            obj.SetValue(MethodToCallProperty, value);
        }

        public static readonly DependencyProperty MethodToCallProperty =
        DependencyProperty.RegisterAttached
        (
            "MethodToCall",
            typeof(string),
            typeof(CallActionOnEventBehavior),
            new PropertyMetadata(default(string))
        );
        #endregion MethodToCall attached Property

    }
}
