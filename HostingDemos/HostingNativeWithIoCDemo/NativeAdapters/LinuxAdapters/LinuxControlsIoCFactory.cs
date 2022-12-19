using Avalonia.Platform;
using LinuxControls;
using NP.DependencyInjection.Attributes;
using PolyFills;

namespace LinuxAdapters
{
    [HasRegisterMethods]
    public static class LinuxControlsIoCFactory
    {
        [RegisterMethod(typeof(IPlatformHandle),  resolutionKey: "ClickCounterView")]
        public static IPlatformHandle? CreateView()
        {
            // HandleBuilder.BuildObjAndHandle will run the LinuxView 
            // and IPlatformHandle creation code 
            return HandleBuilder.BuildObjAndHandle(() => new LinuxView());
        }
    }
}