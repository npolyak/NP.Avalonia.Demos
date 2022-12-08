using System.Windows.Controls;

namespace WpfControl
{
    /// <summary>
    /// Interaction logic for MyWpfUserControl.xaml
    /// </summary>
    public partial class MyWpfUserControl : UserControl
    {
        public MyWpfUserControl()
        {
            InitializeComponent();

            DataContext = new ClickCounterViewModel();
        }
    }
}
