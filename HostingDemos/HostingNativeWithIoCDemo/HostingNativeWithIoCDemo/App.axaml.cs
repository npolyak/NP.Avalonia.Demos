using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using NP.IoCy;
using NP.DependencyInjection.Interfaces;
using System.IO;

namespace HostingWinFormsDemo
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public static IDependencyInjectionContainer? Container { get; private set; }

        public override void OnFrameworkInitializationCompleted()
        {
            var containerBuilder = new ContainerBuilder();

            // Assembly injection
            containerBuilder.RegisterPluginsFromSubFolders($"Plugins{Path.DirectorySeparatorChar}Views");

            // container creation
            Container = containerBuilder.Build();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.ShutdownMode = Avalonia.Controls.ShutdownMode.OnMainWindowClose;
                desktop.MainWindow = new MainWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
