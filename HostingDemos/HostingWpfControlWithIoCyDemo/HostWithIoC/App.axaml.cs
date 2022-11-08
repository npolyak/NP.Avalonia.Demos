using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using NP.Avalonia.Gidon;
using NP.IoCy;
using System.ComponentModel;

namespace HostWithIoC
{
    public partial class App : Application
    {
        public static PluginManager ThePluginManager { get; } =
            new PluginManager
            (
                "Plugins/Services",
                "Plugins/ViewModelPlugins",
                "Plugins/ViewPlugins");

        public static IoCContainer TheContainer => ThePluginManager.TheContainer;

        public App()
        {
            // inject a type from a statically loaded project NLogAdapter
            //ThePluginManager.InjectType(typeof(NLogWrapper));

            // inject all dynamically loaded assemblies
            ThePluginManager.CompleteConfiguration();
        }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
