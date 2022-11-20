using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using NP.IoCy;
using System.IO;

namespace HostingWinFormsDemo
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public static IoCContainer Container { get; } = new IoCContainer();

        public override void OnFrameworkInitializationCompleted()
        {
            Container.InjectPluginsFromSubFolders($"Plugins{Path.DirectorySeparatorChar}Views");

            Container.CompleteConfiguration();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.ShutdownMode = Avalonia.Controls.ShutdownMode.OnMainWindowClose;
                desktop.MainWindow = new MainWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
