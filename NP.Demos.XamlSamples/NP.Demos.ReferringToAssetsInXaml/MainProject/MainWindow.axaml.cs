using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;

namespace NP.Demos.ReferringToAssetsInXaml
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            var assetsLoader = AvaloniaLocator.Current.GetService<IAssetLoader>();

            Image linuxIconImage2 = this.FindControl<Image>("LinuxIconImage2");
            linuxIconImage2.Source = 
                new Bitmap
                (
                    assetsLoader.Open(
                        new Uri("/Assets/LinuxIcon.jpg", UriKind.Absolute)));

            Image avaloniaIconImage2 = this.FindControl<Image>("AvaloniaIconImage2");
            avaloniaIconImage2.Source =
                new Bitmap
                (
                    assetsLoader.Open(
                        new Uri("avares://Dependency1Proj/Assets/avalonia-32.png")));
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
