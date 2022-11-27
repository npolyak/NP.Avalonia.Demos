using Avalonia.Platform;
using NP.Utilities.Attributes;
using PolyFills;
using WpfControls;

namespace WindowsAdapters
{
    [HasFactoryMethods]
    public static class WindowsControlsIoCFactory
    {
        [FactoryMethod(typeof(IPlatformHandle), partKey: "ThePlatformHandle")]
        public static IPlatformHandle? CreateView()
        {
            MyWpfUserControl control = new MyWpfUserControl();

            control.DataContext = new ViewModels.ClickCounterViewModel();

            return HandleBuilder.BuildHandle(control);
        }
    }
}