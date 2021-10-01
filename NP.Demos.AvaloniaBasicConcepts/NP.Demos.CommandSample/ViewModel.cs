using System.ComponentModel;

namespace NP.Demos.CommandSample
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }


        #region Status Property
        private bool _status;
        public bool Status
        {
            get
            {
                return this._status;
            }
            set
            {
                if (this._status == value)
                {
                    return;
                }

                this._status = value;
                this.OnPropertyChanged(nameof(Status));
            }
        }
        #endregion Status Property

        public void ToggleStatus()
        {
            Status = !Status;
        }


        #region CanToggleStatus Property
        private bool _canToggleStatus = true;
        public bool CanToggleStatus
        {
            get
            {
                return this._canToggleStatus;
            }
            set
            {
                if (this._canToggleStatus == value)
                {
                    return;
                }

                this._canToggleStatus = value;
                this.OnPropertyChanged(nameof(CanToggleStatus));
            }
        }
        #endregion CanToggleStatus Property

        public void SetStatus(bool status)
        {
            Status = status;
        }
    }
}
