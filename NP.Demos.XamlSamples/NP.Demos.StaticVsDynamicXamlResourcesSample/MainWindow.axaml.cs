using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace NP.Demos.StaticVsDynamicXamlResourcesSample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            Button button = this.FindControl<Button>("ChangeStatusButton");

            button.Click += Button_Click;
        }

        private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            // getting a Window resource by its name
            var statusBrush = this.FindResource("StatusBrush");

            // setting the window resource to a new value
            this.Resources["StatusBrush"] = 
                             new SolidColorBrush(Colors.Red);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
