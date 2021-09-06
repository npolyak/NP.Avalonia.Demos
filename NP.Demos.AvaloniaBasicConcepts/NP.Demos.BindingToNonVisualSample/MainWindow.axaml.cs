using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace NP.Demos.BindingToNonVisualSample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            Button removeLastItemButton =
                this.FindControl<Button>("RemoveLastItemButton");

            removeLastItemButton.Click += RemoveLastItemButton_Click;
        }

        private void RemoveLastItemButton_Click(object? sender, RoutedEventArgs e)
        {
            ViewModel viewModel = (ViewModel)this.DataContext!;

            viewModel.Names.RemoveAt(viewModel.Names.Count - 1);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
