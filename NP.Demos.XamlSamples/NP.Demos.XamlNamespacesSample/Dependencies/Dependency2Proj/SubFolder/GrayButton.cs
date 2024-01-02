using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Styling;
using System;

namespace Dependency2Proj.SubFolder
{
    public class GrayButton : Button//, IStyleable
    {
        //Type IStyleable.StyleKey => typeof(Button);

        public GrayButton()
        {
            Background = new SolidColorBrush(Colors.Gray);
            Width = 30;
            Height = 30;
        }

        // Use the style for Button
        protected override Type StyleKeyOverride => typeof(Button);
    }
}
