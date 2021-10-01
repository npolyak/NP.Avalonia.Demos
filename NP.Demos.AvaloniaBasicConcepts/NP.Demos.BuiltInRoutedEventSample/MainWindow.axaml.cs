using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Diagnostics;

namespace NP.Demos.BuiltInRoutedEventSample
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
                Control.PointerPressedEvent, //routed event
                HandleClickEvent, // event handler
                RoutingStrategies.Bubble | RoutingStrategies.Tunnel // routing strategy filter
                //,true // uncomment if you want to test that the event still propagates event after being handled
            );

            Grid rootPanel = this.FindControl<Grid>("TheRootPanel");

            // add event handler for the Grid
            rootPanel.AddHandler
            (
                Control.PointerPressedEvent, 
                HandleClickEvent,
                RoutingStrategies.Bubble | RoutingStrategies.Tunnel);

            Border border = this.FindControl<Border>("TheBorder");

            // add event handler for the Blue Border in the middle
            border.AddHandler(
                Control.PointerPressedEvent,
                HandleClickEvent,
                RoutingStrategies.Bubble | RoutingStrategies.Tunnel
                );
        }

        private void HandleClickEvent(object? sender, RoutedEventArgs e)
        {
            Control senderControl = (Control) sender!;

            string eventTypeStr = e.Route switch
            {
                RoutingStrategies.Bubble => "Bubbling",
                RoutingStrategies.Tunnel => "Tunneling",
                _ => "Direct"
            };

            Debug.WriteLine($"{eventTypeStr} Routed Event {e.RoutedEvent!.Name} raised on {senderControl.Name}; Event Source is {(e.Source as Control)!.Name}");

            // uncomment if you want to test handling the event
            //if (e.Route == RoutingStrategies.Bubble && senderControl.Name == "TheBorder")
            //{
            //    e.Handled = true;
            //}
        }


        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
