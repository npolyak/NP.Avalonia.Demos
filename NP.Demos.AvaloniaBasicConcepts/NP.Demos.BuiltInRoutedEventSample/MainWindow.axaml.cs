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
            this.AddHandler
            (
                Control.PointerPressedEvent,
                HandleClickEventOnGrid,
                RoutingStrategies.Bubble | RoutingStrategies.Tunnel);

            Grid rootPanel = this.FindControl<Grid>("RootPanel");

            rootPanel.AddHandler
            (
                Control.PointerPressedEvent, 
                HandleClickEventOnGrid,
                RoutingStrategies.Bubble | RoutingStrategies.Tunnel);

            Border border = this.FindControl<Border>("TheBorder");

            border.AddHandler(
                Control.PointerPressedEvent,
                HandleClickEventOnGrid,
                RoutingStrategies.Bubble | RoutingStrategies.Tunnel
                //,true // uncomment if you want to test that the event still propagates event after being handled
                );
        }

        private void HandleClickEventOnGrid(object? sender, RoutedEventArgs e)
        {
            Control senderControl = (Control) sender!;

            string eventType = e.Route switch
            {
                RoutingStrategies.Bubble => "Bubbling",
                RoutingStrategies.Tunnel => "Tunneling",
                _ => "Direct"
            };

            Debug.WriteLine($"{eventType} Routed Event {e.RoutedEvent!.Name} raised on {senderControl.Name}; Event Source is {(e.Source as Control)!.Name}");

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
