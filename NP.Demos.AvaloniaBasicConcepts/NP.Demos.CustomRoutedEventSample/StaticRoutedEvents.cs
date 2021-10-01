using Avalonia.Interactivity;

namespace NP.Demos.CustomRoutedEventSample
{
    public static class StaticRoutedEvents
    {
        /// <summary>
        /// create the MyCustomRoutedEvent
        /// </summary>
        public static readonly RoutedEvent<RoutedEventArgs> MyCustomRoutedEvent =
            RoutedEvent.Register<object, RoutedEventArgs>
            (
                "MyCustomRouted", 
                RoutingStrategies.Tunnel //| RoutingStrategies.Bubble
            );
    }
}
