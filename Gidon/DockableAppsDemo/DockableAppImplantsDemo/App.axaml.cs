using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using NP.Avalonia.Gidon;
using NP.DependencyInjection.Interfaces;
using NP.Gidon.Messages;
using NP.Grpc.CommonRelayInterfaces;
using NP.IoCy;
using NP.Protobuf;
using System;

namespace DockableAppImplantsDemo
{
    public class App : Application
    {
        // IoC Container
        private static IDependencyInjectionContainer<Enum> IoCContainer { get; }

        // IRelayServer (provided so that we could shut it down when the program shuts down)
        private static IRelayServer TheRelayServer { get; }

        // IRelayClient used for getting WindowHandles from the python windows
        // started in different processes
        private static IRelayClient TheRelayClient { get; }

        // Window handle matcher - matches the window handle with the unique
        // window host id
        public static WindowHandleMatcher TheWindowHandleMatcher { get; }

        static App()
        {
            // create the container builder
            IContainerBuilderWithMultiCells<Enum> containerBuilder = new ContainerBuilder<Enum>();

            // register a multicell that can container several different Enum values
            // corresponding to the various topics of the RelayServer.
            // Here we use only one topic - WindowInfoTopic the allows to publish and subscribe
            // object of WindowInfo type (contained within NP.Gidon.Message package) that 
            // provide the WindowHandle (of type long) and UniqueWindowHostId (or type string)
            containerBuilder.RegisterMultiCell(typeof(Enum), IoCKeys.Topics);

            // provides an object for determining Grpc server host and port 
            // (in our simple case they are hardcoded to "localhost" and 5051 correspondingly)
            containerBuilder.RegisterType<IGrpcConfig, GrpcConfig>();

            // provides the topics MultiCell (only one topic WindowInfoTopic - in our case)
            containerBuilder.RegisterAttributedStaticFactoryMethodsFromClass(typeof(MessagesTopicsGetter));

            // picks up the RelayServer and RelayClient implementations as plugins from Plugins/Services folder
            containerBuilder.RegisterPluginsFromSubFolders("Plugins/Services");

            // builds the IoC Container
            IoCContainer = containerBuilder.Build();

            // gets a reference to the Relay Server from the container
            TheRelayServer = IoCContainer.Resolve<IRelayServer>();

            // gets a reference to the RelayClient from the container
            TheRelayClient = IoCContainer.Resolve<IRelayClient>();

            // gets the WindowHandleMatcher - an object that observes the RelayServer from WindowInfo objects
            // and fires events matching the UniqueWindowHostId and the WindowHandle every time 
            // such objects arrive
            TheWindowHandleMatcher = new WindowHandleMatcher(TheRelayClient);
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
                desktop.ShutdownMode = Avalonia.Controls.ShutdownMode.OnMainWindowClose;
                desktop.ShutdownRequested += Desktop_ShutdownRequested;
            }

            base.OnFrameworkInitializationCompleted();
        }

        private void Desktop_ShutdownRequested(object? sender, ShutdownRequestedEventArgs e)
        {
            // Call shutdown on the relay server to free up some possible system
            // resources before the program shuts down. 
            TheRelayServer.Shutdown();
        }
    }
}
