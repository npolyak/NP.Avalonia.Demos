using NP.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace NP.Demos.LargeDemoForShow
{
    public class CreateTradeVM : VMBase
    {
        public IEnumerable<StockViewModel>? Stocks { get; set; }

        #region SelectedStock Property
        private StockViewModel? _selectedStock;
        public StockViewModel? SelectedStock
        {
            get
            {
                return this._selectedStock;
            }
            set
            {
                if (this._selectedStock == value)
                {
                    return;
                }

                this._selectedStock = value;
                this.OnPropertyChanged(nameof(SelectedStock));
                this.OnPropertyChanged(nameof(HasSelectedStock));
            }
        }
        #endregion SelectedStock Property

        public bool HasSelectedStock => SelectedStock != null;
    }
}
