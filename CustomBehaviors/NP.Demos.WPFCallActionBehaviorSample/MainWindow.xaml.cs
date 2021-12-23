using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NP.Demos.WPFCallActionBehaviorSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void MakeWindowBackgroundRed()
        {
            Background = new SolidColorBrush(Colors.Red);
        }

        public void OpenDialog()
        {
            Window dialogWindow =
                new Window()
                {
                    Left = this.Left + 50,
                    Top = this.Top + 50,
                    Owner = this, 
                    Width = 200, 
                    Height = 200 
                };

            dialogWindow.Content = new TextBlock
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Text = "I am a happy dialog!"
            };

            dialogWindow.ShowDialog();
        }
    }
}
