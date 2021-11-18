# Examples demonstrating Theming and Localization capabilities of NP.Avalonia.Visual package

The examples are described in detail in [Theming and Localization functionality for Multiplaform Avalonia UI Framework](https://www.codeproject.com/Articles/5317972/Theming-and-Localization-functionality-for-Multipl)
article.

These capabilities were inspired by a great localization and theming package for WPF created by [Tomer Shamam](https://www.linkedin.com/in/tomershamam/?originalSubdomain=il).
The code for his package is now published with his kind permission at [WPFLocalizationPackage](https://github.com/npolyak/WPFLocalizationPackage)

The functionality of my package is different - unlike Tomer, I am using a DynamicResource Avalonia extension and not a custom markup extension. 
Also my functionality allows switching themes and localization along so to say multiple coordinates - e.g. one can switch between different languages along one coordinate
and between Dark and Light color themes along the other. Any combinations of a language and a color theme is allowed. 

Here are several images of a complex multiplatform Demo application (similar to Tomer's WPF demo) showing what one can achieve using 
the new Avalonia Theming and Localization functionalty:
![AdvancedDemoEnglishDark](https://user-images.githubusercontent.com/2833722/142480092-6d8fdfde-2674-4b7e-a67e-dbb1c645668a.png)
![AdvancedDemoHebrewLight](https://user-images.githubusercontent.com/2833722/142480093-a071b7b3-1556-46da-96b2-92a9f696caa9.png)
![AdvancedDemoRussianDark](https://user-images.githubusercontent.com/2833722/142480096-fe9975e1-0d62-4550-b889-14237fb1ab36.png)
