using Avalonia.Platform;
using NP.DependencyInjection.Attributes;
using PolyFills;
using WpfControls;

namespace WindowsAdapters
{
    [HasRegisterMethods]
    public static class WindowsControlsIoCFactory
    {
        [RegisterMethod(typeof(IPlatformHandle), resolutionKey: "ClickCounterView")]
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