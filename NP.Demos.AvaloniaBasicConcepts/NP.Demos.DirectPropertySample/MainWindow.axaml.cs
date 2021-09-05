using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;

namespace NP.Demos.DirectPropertySample
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


        #region RectangleStrokeThickness Direct Avalonia Property
        private double _RectangleStrokeThickness = default;

        public static readonly DirectProperty<MainWindow, double> RectangleStrokeThicknessProperty =
            AvaloniaProperty.RegisterDirect<MainWindow, double>
            (
                nameof(RectangleStrokeThickness),
                o => o.RectangleStrokeThickness,
                (o, v) => o.RectangleStrokeThickness = v
            );

        public double RectangleStrokeThickness
        {
            get => _RectangleStrokeThickness;
            set
            {
                SetAndRaise(RectangleStrokeThicknessProperty, ref _RectangleStrokeThickness, value);
            }
        }

        #endregion RectangleStrokeThickness Direct Avalonia Property


        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
