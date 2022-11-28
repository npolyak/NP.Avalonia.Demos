using Avalonia.Platform;
using LinuxControls;
using NP.Utilities.Attributes;
using PolyFills;

namespace LinuxAdapters
{
    [HasFactoryMethods]
    public static class LinuxControlsIoCFactory
    {
        [FactoryMethod(typeof(IPlatformHandle),  partKey: "ClickCounterView")]
        public static IPlatformHandle? CreateView()
        {
            // HandleBuilder.BuildObjAndHandle will run the LinuxView 
            // and IPlatformHandle creation code 
            return HandleBuilder.BuildObjAndHandle(() => new LinuxView());
        }
    }
}