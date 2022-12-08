using System.ComponentModel;

namespace SimpleWpfApp
{
    public class ClickCounterViewModel : INotifyPropertyChanged
    {
        

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        #region NumberClicks Property
        private int _numberClicks;
        public int NumberClicks
        {
            get
            {
                return this._numberClicks;
            }
            private set
            {
                if (this._numberClicks == value)
                {
                    return;
                }

                this._numberClicks = value;
                this.OnPropertyChanged(nameof(NumberClicks));
                this.OnPropertyChanged(nameof(NumberClicksStr));
            }
        }
        #endregion NumberClicks Property


        public string NumberClicksStr =>
            $"Number clicks is {NumberClicks}";

        public void IncreaseNumberClicks()
        {
            NumberClicks++;
        }
    }
}