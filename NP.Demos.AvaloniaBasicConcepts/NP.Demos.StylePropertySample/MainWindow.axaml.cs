using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;

namespace NP.Demos.StylePropertySample
{
    public partial class MainWindow : Window
    {
        // to stop change notification dispose of this subscription token
        private IDisposable _changeNotificationSubscriptionToken;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            //subscribe
            _changeNotificationSubscriptionToken =
                   RectangleStrokeThicknessProperty
                       .Changed
                       .Subscribe(OnRectangleStrokeThicknessChanged);
        }

        // this method is called when the Style property changes
        private void OnRectangleStrokeThicknessChanged(AvaloniaPropertyChangedEventArgs<double> changeParams)
        {
            // if the object on which this Style property changes
            // is not this very window, do not do anything
            if (changeParams.Sender != this)
            {
                return;
            }

            // check the old and new values of the Style property. 
            double oldValue = changeParams.OldValue.Value;

            double newValue = changeParams.NewValue.Value;
        }


        #region RectangleStrokeThickness Styled Avalonia Property
        public double RectangleStrokeThickness
        {
            // getter 
            get { return GetValue(RectangleStrokeThicknessProperty); }

            // setter
            set { SetValue(RectangleStrokeThicknessProperty, value); }
        }

        // the static field that contains the hashtable mapping the 
        // object of type MainWindow into double and also containing the 
        // information about the default value
        public static readonly StyledProperty<double> RectangleStrokeThicknessProperty =
            AvaloniaProperty.Register<MainWindow, double>
            (
                nameof(RectangleStrokeThickness)
            );
        #endregion RectangleStrokeThickness Styled Avalonia Property


        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
