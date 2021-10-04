using System.ComponentModel;

namespace NP.Demos.ContentPresenterSample
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }


        #region SavedValue Property
        private string? _savedValue;
        public string? SavedValue
        {
            get
            {
                return this._savedValue;
            }
            private set
            {
                if (this._savedValue == value)
                {
                    return;
                }

                this._savedValue = value;
                this.OnPropertyChanged(nameof(SavedValue));
                this.OnPropertyChanged(nameof(CanSave));
            }
        }
        #endregion SavedValue Property


        #region NewValue Property
        private string? _newValue;
        public string? NewValue
        {
            get
            {
                return this._newValue;
            }
            set
            {
                if (this._newValue == value)
                {
                    return;
                }

                this._newValue = value;
                this.OnPropertyChanged(nameof(NewValue));
                this.OnPropertyChanged(nameof(CanSave));
            }
        }
        #endregion NewValue Property

        public bool CanSave => NewValue != SavedValue;

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
