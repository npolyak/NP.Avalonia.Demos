using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using NP.Avalonia.UniDock;

namespace NP.Demos.DefaultLayoutSaveDemo
{
    public partial class MainWindow : Window
    {
        private DockManager _dockManager;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            _dockManager = (DockManager) this.FindResource("TheDockManager")!;

            Button _saveLayoutButton =
                this.FindControl<Button>("SaveLayoutButton");

            _saveLayoutButton.Click += _saveLayoutButton_Click;
        }

        private void _saveLayoutButton_Click(object? sender, global::Avalonia.Interactivity.RoutedEventArgs e)
        {
            _dockManager.SaveToFile("DefaultLayout.xml");
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
