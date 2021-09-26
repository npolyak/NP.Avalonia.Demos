using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Styling;
using System;

namespace Dependency2Proj
{
    public class GreenButton : Button, IStyleable
    {
        Type IStyleable.StyleKey => typeof(Button);

        public GreenButton()
        {
            Background = new SolidColorBrush(Colors.Green);
            Width = 30;
            Height = 30;
        }
    }
}
