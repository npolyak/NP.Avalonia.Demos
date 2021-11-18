using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using NP.Avalonia.Visuals.Behaviors;
using NP.Avalonia.Visuals.ThemingAndL10N;

namespace NP.Demos.SimpleThemingAndL10NSample
{
    public partial class MainWindow : Window
    {
        private ThemeLoader _colorThemeLoader;
        private ThemeLoader _languageThemeLoader;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            // find the theme loader by name
            _colorThemeLoader =
                Application.Current.Resources.GetThemeLoader("ColorThemeLoader")!;
            _languageThemeLoader =
                Application.Current.Resources.GetThemeLoader("LanguageLoader")!;

            Button lightButton = this.FindControl<Button>("LightButton");
            lightButton.Click += LightButton_Click;

            Button darkButton = this.FindControl<Button>("DarkButton");
            darkButton.Click += DarkButton_Click;

            Button englishButton = this.FindControl<Button>("EnglishButton");
            englishButton.Click += EnglishButton_Click;

            Button hebrewButton = this.FindControl<Button>("HebrewButton");
            hebrewButton.Click += HebrewButton_Click;
        }

        private void LightButton_Click(object? sender, RoutedEventArgs e)
        {
            // set the theme to Light
            _colorThemeLoader.SelectedThemeId = "Light";
        }

        private void DarkButton_Click(object? sender, RoutedEventArgs e)
        {
            // set the theme to Dark
            _colorThemeLoader.SelectedThemeId = "Dark";
        }

        private void EnglishButton_Click(object? sender, RoutedEventArgs e)
        {
            // set language to English
            _languageThemeLoader.SelectedThemeId = "English";
        }

        private void HebrewButton_Click(object? sender, RoutedEventArgs e)
        {
            // set language to Hebrew
            _languageThemeLoader.SelectedThemeId = "Hebrew";
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
