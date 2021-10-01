using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Diagnostics;

namespace NP.Demos.CustomRoutedEventSample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            // add event handler for the Window
            this.AddHandler
            (
                StaticRoutedEvents.MyCustomRoutedEvent, //routed event
                HandleCustomEvent, // event handler
                RoutingStrategies.Bubble | RoutingStrategies.Tunnel // routing strategy filter
            );

            Grid rootPanel = this.FindControl<Grid>("TheRootPanel");

            // add event handler for the Grid
            rootPanel.AddHandler
            (
                StaticRoutedEvents.MyCustomRoutedEvent, 
                HandleCustomEvent,
                RoutingStrategies.Bubble | RoutingStrategies.Tunnel);

            Border border = this.FindControl<Border>("TheBorder");

            // add event handler for the Blue Border in the middle
            border.AddHandler(
                StaticRoutedEvents.MyCustomRoutedEvent,
                HandleCustomEvent,
                RoutingStrategies.Bubble | RoutingStrategies.Tunnel
                );

            // we add the handler to pointer pressed event in order
            // to raise MyCustomRoutedEvent from it.
            border.PointerPressed += Border_PointerPressed;
        }


        /// PointerPressed handler that raises MyCustomRoutedEvent
        private void Border_PointerPressed(object? sender, PointerPressedEventArgs e)
        {
            Control control = (Control)sender!;

            // Raising MyCustomRoutedEvent
            control.RaiseEvent(new RoutedEventArgs(StaticRoutedEvents.MyCustomRoutedEvent));
        }

        private void HandleCustomEvent(object? sender, RoutedEventArgs e)
        {
            Control senderControl = (Control) sender!;

            string eventTypeStr = e.Route switch
            {
                RoutingStrategies.Bubble => "Bubbling",
                RoutingStrategies.Tunnel => "Tunneling",
                _ => "Direct"
            };

            Debug.WriteLine($"{eventTypeStr} Routed Event {e.RoutedEvent!.Name} raised on {senderControl.Name}; Event Source is {(e.Source as Control)!.Name}");
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
