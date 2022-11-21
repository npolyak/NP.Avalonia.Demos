using Avalonia.Platform;
using LinuxControls;
using NP.Utilities.Attributes;
using PolyFills;

namespace LinuxAdapters
{
    [HasFactoryMethods]
    public static class LinuxControlsIoCFactory
    {
        [FactoryMethod(typeof(IPlatformHandle), isSingleton: false, partKey: "ThePlatformHandle")]
        public static IPlatformHandle? CreateView()
        {
            return HandleBuilder.BuildObjAndHandle(() => new LinuxView());
        }
    }
}