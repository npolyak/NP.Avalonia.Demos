using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using NP.Avalonia.Visuals.Controls;

namespace NP.Demos.CustomWindowChangingButtonsSample
{
    public partial class MainWindow : CustomWindow
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }


        #region CanEditContent Styled Avalonia Property
        public bool CanEditContent
        {
            get { return GetValue(CanEditContentProperty); }
            set { SetValue(CanEditContentProperty, value); }
        }

        public static readonly StyledProperty<bool> CanEditContentProperty =
            AvaloniaProperty.Register<MainWindow, bool>
            (
                nameof(CanEditContent),
                true
            );
        #endregion CanEditContent Styled Avalonia Property

    }
}
