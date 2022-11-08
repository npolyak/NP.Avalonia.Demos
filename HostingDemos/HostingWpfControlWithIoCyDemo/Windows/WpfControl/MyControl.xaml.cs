using NP.Utilities.Attributes;
using System.Windows.Controls;

namespace WpfControl
{
    /// <summary>
    /// Interaction logic for MyControl.xaml
    /// </summary>
    [Implements(typeof(object), partKey:"WpfPlugin")]
    public partial class MyControl : UserControl
    {
        public MyControl()
        {
            InitializeComponent();
        }
    }
}
