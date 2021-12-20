using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using NP.Avalonia.Visuals.Controls;

namespace NP.Demos.AutoGridSamples
{
    public partial class MainWindow : CustomWindow
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            Button changeLayoutButton = 
                this.FindControl<Button>("ChangeLayoutButton");

            changeLayoutButton.Click += ChangeLayoutButton_Click;
        }

        private void ChangeLayoutButton_Click(object? sender, global::Avalonia.Interactivity.RoutedEventArgs e)
        {
            Button button3 = this.FindControl<Button>("Button3");

            if (AutoGrid.GetRow(button3) == 2)
            {
                AutoGrid.SetRow(button3, -2);
                AutoGrid.SetColumn(button3, -2);
            }
            else
            {
                AutoGrid.SetRow(button3, 2);
                AutoGrid.SetColumn(button3, 1);
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
