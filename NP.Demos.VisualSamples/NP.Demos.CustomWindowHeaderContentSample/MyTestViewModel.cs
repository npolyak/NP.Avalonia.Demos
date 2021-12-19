using NP.Utilities;
using System.ComponentModel;

namespace NP.Demos.CustomWindowHeaderContentSample
{
    public class MyTestViewModel : VMBase
    {
        #region Text Property
        private string? _text;
        public string? Text
        {
            get
            {
                return this._text;
            }
            set
            {
                if (this._text == value)
                {
                    return;
                }

                this._text = value;
                this.OnPropertyChanged(nameof(Text));
            }
        }
        #endregion Text Property
    }
}
