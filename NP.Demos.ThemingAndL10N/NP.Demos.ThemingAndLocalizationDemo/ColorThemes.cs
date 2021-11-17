namespace NP.Demos.ThemingAndLocalizationDemo
{
    public enum ColorTheme
    {
        Dark,
        Light
    }

    public static class ColorThemesHelper
    {
        public static ColorTheme[] ColorThemes { get; } = 
            {
                ColorTheme.Dark, 
                ColorTheme.Light };
    }
}
