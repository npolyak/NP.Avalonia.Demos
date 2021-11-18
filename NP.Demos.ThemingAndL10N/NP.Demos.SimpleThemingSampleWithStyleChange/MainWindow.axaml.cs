using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using NP.Avalonia.Visuals.Behaviors;
using NP.Avalonia.Visuals.ThemingAndL10N;

namespace NP.Demos.SimpleThemingSample
{
    public partial class MainWindow : Window
    {
        private ThemeLoader _themeLoader;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            // find the theme loader by name
            _themeLoader =
                Application.Current.Resources.GetThemeLoader("ColorThemeLoader")!;

            // set the handler for lightButton's click event
            Button lightButton = this.FindControl<Button>("LightButton");
            lightButton.Click += LightButton_Click;

            // set the handler for darkButton's click event
            Button darkButton = this.FindControl<Button>("DarkButton");
            darkButton.Click += DarkButton_Click;

        }

        private void LightButton_Click(object? sender, global::Avalonia.Interactivity.RoutedEventArgs e)
        {
            // set the theme to Light
            _themeLoader.SelectedThemeId = "Light";
        }

        private void DarkButton_Click(object? sender, global::Avalonia.Interactivity.RoutedEventArgs e)
        {
            // set the theme to Dark
            _themeLoader.SelectedThemeId = "Dark";
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
