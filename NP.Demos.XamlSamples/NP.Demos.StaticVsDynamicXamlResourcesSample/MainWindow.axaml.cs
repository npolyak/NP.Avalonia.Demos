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
            var statusBrush = this.FindResource("StatusBrush");
            this.Resources["StatusBrush"] = new SolidColorBrush(Colors.Red);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
