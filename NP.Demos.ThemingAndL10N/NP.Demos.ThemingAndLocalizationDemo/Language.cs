namespace NP.Demos.ThemingAndLocalizationDemo
{
    public enum Language
    {
        English,
        Hebrew,
        Russian
    }

    public static class LanguageHelper
    {
        public static Language[] Languages { get; } =
        {
            Language.English,
            Language.Hebrew,
            Language.Russian
        };
    }
}
