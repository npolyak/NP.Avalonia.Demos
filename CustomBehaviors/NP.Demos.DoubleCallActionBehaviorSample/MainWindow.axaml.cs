using Avalonia.Layout;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia;

namespace NP.Demos.DoubleCallActionBehaviorSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }


        private IBrush? _oldBackground = null;
        // Turns window background red
        public void MakeWindowBackgroundRed()
        {
            _oldBackground = Background;
            Background = new SolidColorBrush(Colors.Red);
        }

        public void RestoreBackground()
        {
            Background = _oldBackground;
        }

        // opens a dialog
        public void OpenDialog()
        {
            Window dialogWindow =
                new Window()
                {
                    Position = new PixelPoint(this.Position.X + 50, this.Position.Y + 50),
                    Width = 200,
                    Height = 200
                };

            dialogWindow.Content = new TextBlock
            {

                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Text = "I am a happy dialog!"
            };

            dialogWindow.ShowDialog(this);
        }
    }
}
