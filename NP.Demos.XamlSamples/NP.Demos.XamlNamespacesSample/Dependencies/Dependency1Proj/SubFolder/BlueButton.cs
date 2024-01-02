using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Styling;
using System;

namespace Dependency1Proj.SubFolder
{
    public class BlueButton : Button
    {
        public BlueButton()
        {
            Background = new SolidColorBrush(Colors.Blue);
            Width = 30;
            Height = 30;
        }

        // Use the style for Button
        protected override Type StyleKeyOverride => typeof(Button);
    }
}
