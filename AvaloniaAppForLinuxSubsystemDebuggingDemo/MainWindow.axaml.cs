using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AvaloniaAppForLinuxSubsystemDebuggingDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            TestDebuggingButton.Click += TestDebuggingButton_Click;
        }

        private void TestDebuggingButton_Click(object? sender, RoutedEventArgs e)
        {
           
        }
    }
}
