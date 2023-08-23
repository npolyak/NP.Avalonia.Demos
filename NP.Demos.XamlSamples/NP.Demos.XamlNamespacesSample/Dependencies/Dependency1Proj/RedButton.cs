using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Styling;
using System;

namespace Dependency1Proj
{
    public class RedButton : Button//, IStyleable
    {
        //Type IStyleable.StyleKey => typeof(Button);

        public RedButton()
        {
            Background = new SolidColorBrush(Colors.Red);
            Width = 30;
            Height = 30;
        }

        // Use the style for Button
        protected override Type StyleKeyOverride => typeof(Button);
    }
}
