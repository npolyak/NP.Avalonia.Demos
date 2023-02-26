using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using NP.DependencyInjection.Interfaces;
using NP.Gidon.Messages;
using NP.Grpc.CommonRelayInterfaces;
using NP.Grpc.RelayClient;
using NP.GrpcConfig;
using NP.IoCy;
using System;

namespace SimpleAvaloniaApp
{
    public partial class App : Application
    {
        internal static IDependencyInjectionContainer<Enum> IoCContainer { get; }

        internal static IRelayClient TheRelayClient { get; }

        static App()
        {
            IContainerBuilderWithMultiCells<Enum> containerBuilder =
                new ContainerBuilder<Enum>();

#if DEBUG
            containerBuilder.RegisterSingletonType<IGrpcConfig, GrpcConfig>();
            containerBuilder.RegisterSingletonType<IRelayClient, RelayClient>();

            containerBuilder.RegisterAttributedStaticFactoryMethodsFromClass(typeof(MessagesTopicsGetter));
#else
            containerBuilder.RegisterPluginsFromSubFolders("Plugins/Services");
#endif
            IoCContainer = containerBuilder.Build();

            TheRelayClient = IoCContainer.Resolve<IRelayClient>();
        }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow(desktop.Args[0]);
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
