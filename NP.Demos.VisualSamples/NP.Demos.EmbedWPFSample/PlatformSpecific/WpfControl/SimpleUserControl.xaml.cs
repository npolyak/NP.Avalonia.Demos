using System;
using System.Windows.Controls;
using System.Windows.Forms.Integration;
using System.Windows.Interop;

namespace WpfControl
{
    /// <summary>
    /// Interaction logic for SimpleUserControl.xaml
    /// </summary>
    public partial class SimpleUserControl : UserControl
    {
        public SimpleUserControl()
        {
            InitializeComponent();
        }

        public static IntPtr GetElementHost()
        {
            ElementHost host = 
                new ElementHost() { Child = new SimpleUserControl() };

            return host.Handle;
        }
    }
}
