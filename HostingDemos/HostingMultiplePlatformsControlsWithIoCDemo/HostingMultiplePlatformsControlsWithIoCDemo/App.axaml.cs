using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using NP.IoCy;
using NP.Utilities;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

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

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            //Container.CompleteConfiguration();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }

        private Assembly? CurrentDomain_AssemblyResolve(object? sender, ResolveEventArgs args)
        {
            AssemblyName? name = 
                args.RequestingAssembly
                    .GetReferencedAssemblies()
                    .FirstOrDefault(a => a.FullName == args.Name);

            return name?.FindOrLoadAssembly();
            //return null;
        }
    }
}
