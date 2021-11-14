using NP.Avalonia.UniDockService;
using NP.Utilities;
using System.Collections.ObjectModel;
using System.Linq;

namespace NP.Demos.LargeDemoForShow
{
    public class TestViewModel : VMBase
    {        
        private static StockViewModel IBM =
            new StockViewModel
            {
                Symbol = "IBM",
                Description = "Internation Business Machines",
                Ask = 51,
                Bid = 49
            };

        private static StockViewModel MSFT =
            new StockViewModel
            {
                Symbol = "MSFT",
                Description = "Microsoft",
                Ask = 101,
                Bid = 99
            };

        private static StockViewModel GOOGL =
            new StockViewModel
            {
                Symbol = "GOOGL",
                Description = "Google",
                Ask = 1000,
                Bid = 999
            };

        private static StockViewModel AAPL =
            new StockViewModel
            {
                Symbol = "AAPL",
                Description = "Apple Inc",
                Ask = 500,
                Bid = 499
            };


        private static StockViewModel DELL =
            new StockViewModel
            {
                Symbol = "DELL",
                Description = "Dell Technologies",
                Ask = 150,
                Bid = 149
            };

        private static StockViewModel TESLA =
            new StockViewModel
            {
                Symbol = "TSLA",
                Description = "Tesla Inc",
                Ask = 1050,
                Bid = 1049
            };

        private static StockViewModel[] Stocks { get; } =
        {
            IBM,
            MSFT,
            GOOGL,
            AAPL,
            DELL,
            TESLA
        };

        public CreateTradeVM CreateTradeViewModel { get; } = new CreateTradeVM() { Stocks = Stocks };

        // non-visual interface to the DockManager
        private IUniDockService? _uniDockService;
        public IUniDockService? UniDockService
        {
            get => _uniDockService;
            set
            {
                if (_uniDockService == value)
                    return;

                _uniDockService = value;

                if ((_uniDockService != null) && (_uniDockService.DockItemsViewModels == null))
                {
                    _uniDockService.DockItemsViewModels = new ObservableCollection<DockItemViewModelBase>();
                }
            }
        }

        int _orderNumber = 0;
        public void AddOrder()
        {
            var stock = Stocks[_orderNumber % Stocks.Length];
            OrderViewModel orderVM = new OrderViewModel
            {
                Symbol = stock.Symbol,
                MarketPrice = (stock.Ask + stock.Bid) / 2m,
                NumberShares = (_orderNumber + 1) * 1000
            };


            var newTabVm = new OrderDockItemViewModel
            {
                DockId = "Order" + _orderNumber + 1,
                DefaultDockGroupId = "Orders",
                DefaultDockOrderInGroup = _orderNumber,
                HeaderContentTemplateResourceKey = "OrderHeaderDataTemplate",
                ContentTemplateResourceKey = "OrderDataTemplate",
                IsPredefined = false,
                TheVM = orderVM
            };

            _uniDockService?.DockItemsViewModels?.Add(newTabVm);

            _orderNumber++;
        }

        private int _stockNumber = 0;
        public void AddStock()
        {
            var stock = Stocks[_stockNumber % Stocks.Length];
            int tabNumber = _stockNumber + 1;
            _uniDockService?.DockItemsViewModels?.Add
            (
                new StockDockItemViewModel
                {
                    DockId = $"{stock.Symbol}_{tabNumber}",
                    TheVM = stock,
                    DefaultDockGroupId = "Stocks",
                    DefaultDockOrderInGroup = _stockNumber,
                    HeaderContentTemplateResourceKey = "StockHeaderDataTemplate",
                    ContentTemplateResourceKey = "StockDataTemplate",
                    IsSelected = true,
                    IsActive = true,
                    IsPredefined = false
                });

            _stockNumber++;
        }

        private const string DockSerializationFileName = "DockSerialization.xml";
        private const string VMSerializationFileName = "DockVMSerialization.xml";


        public void Save()
        {
            // save the layout
            _uniDockService?.SaveToFile(DockSerializationFileName);

            // save the view models
            _uniDockService?.SaveViewModelsToFile(VMSerializationFileName);
        }

        public void Restore()
        {
            if (_uniDockService == null)
            {
                return;
            }

            _uniDockService.DockItemsViewModels = null!;

            // restore the layout
            _uniDockService.RestoreFromFile(DockSerializationFileName);

            // restore the view models
            _uniDockService.RestoreViewModelsFromFile
            (
                VMSerializationFileName,
                typeof(StockDockItemViewModel),
                typeof(OrderDockItemViewModel));

            // select the first tab.
            _uniDockService.DockItemsViewModels?.FirstOrDefault()?.Select();

            _stockNumber = 
                _uniDockService?.DockItemsViewModels?.OfType<StockDockItemViewModel>()?.Count() ?? 0;
            _orderNumber = 
                _uniDockService?.DockItemsViewModels?.OfType<OrderDockItemViewModel>()?.Count() ?? 0;

        }
    }
}
