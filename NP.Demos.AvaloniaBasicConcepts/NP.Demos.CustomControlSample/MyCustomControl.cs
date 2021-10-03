using Avalonia;
using Avalonia.Controls.Primitives;
using System;

namespace NP.Demos.CustomControlSample
{
    public class MyCustomControl : TemplatedControl
    {
        #region NewValue Styled Avalonia Property
        public string? NewValue
        {
            get { return GetValue(NewValueProperty); }
            set { SetValue(NewValueProperty, value); }
        }

        public static readonly StyledProperty<string?> NewValueProperty =
            AvaloniaProperty.Register<MyCustomControl, string?>
            (
                nameof(NewValue)
            );
        #endregion NewValue Styled Avalonia Property


        #region SavedValue Styled Avalonia Property
        public string? SavedValue
        {
            get { return GetValue(SavedValueProperty); }
            set { SetValue(SavedValueProperty, value); }
        }

        public static readonly StyledProperty<string?> SavedValueProperty =
            AvaloniaProperty.Register<MyCustomControl, string?>
            (
                nameof(SavedValue)
            );
        #endregion SavedValue Styled Avalonia Property


        #region CanSave Direct Avalonia Property
        private bool _canSave = default;

        public static readonly DirectProperty<MyCustomControl, bool> CanSaveProperty =
            AvaloniaProperty.RegisterDirect<MyCustomControl, bool>
            (
                nameof(CanSave),
                o => o.CanSave
            );

        public bool CanSave
        {
            get => _canSave;
            private set
            {
                SetAndRaise(CanSaveProperty, ref _canSave, value);
            }
        }

        #endregion CanSave Direct Avalonia Property

        private void SetCanSave(object? obj)
        {
            CanSave = SavedValue != NewValue;
        }

        public MyCustomControl()
        {
            this.GetObservable(NewValueProperty).Subscribe(SetCanSave);
            this.GetObservable(SavedValueProperty).Subscribe(SetCanSave);
        }

        public void Save()
        {
            SavedValue = NewValue;
        }

        public void Cancel()
        {
            NewValue = SavedValue;
        }
    }
}
