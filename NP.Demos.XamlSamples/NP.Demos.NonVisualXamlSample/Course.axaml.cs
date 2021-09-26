using Avalonia.Markup.Xaml;
using Avalonia.Metadata;

namespace NP.Demos.NonVisualXamlSample
{
    public partial class Course
    {
        public Course()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public int NumberStudents { get; set; }

        [Content]
        public Person? Teacher { get; set; }
    }
}
