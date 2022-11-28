using Avalonia.Platform;
using NP.Utilities.Attributes;
using PolyFills;
using WpfControls;

namespace WindowsAdapters
{
    [HasFactoryMethods]
    public static class WindowsControlsIoCFactory
    {
        [FactoryMethod(typeof(IPlatformHandle), partKey: "ClickCounterView")]
        public static IPlatformHandle? CreateView()
        {
            // create the Windows native WPF control
            MyWpfUserControl control = new MyWpfUserControl();

            // assign its data context to our view model
            control.DataContext = new ViewModels.ClickCounterViewModel();

            // use the method from PolyFill project to create 
            return HandleBuilder.BuildHandle(control);
        }
    }
}