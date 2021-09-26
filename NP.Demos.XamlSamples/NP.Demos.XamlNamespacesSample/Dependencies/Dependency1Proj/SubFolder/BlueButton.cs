using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Styling;
using System;

namespace Dependency1Proj.SubFolder
{
    public class BlueButton : Button, IStyleable
    {
        Type IStyleable.StyleKey => typeof(Button);

        public BlueButton()
        {
            Background = new SolidColorBrush(Colors.Blue);
            Width = 30;
            Height = 30;
        }
    }
}
