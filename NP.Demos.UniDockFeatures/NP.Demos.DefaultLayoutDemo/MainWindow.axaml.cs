using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using NP.Avalonia.UniDock;

namespace NP.Demos.DefaultLayoutDemo
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
            _dockManager = (DockManager)this.FindResource("TheDockManager")!;

            _dockManager.RestoreFromFile("DefaultLayout.xml");
        }


        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
