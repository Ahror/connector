using Connector.Connectors;
using Connector.Model;
using Connector.Wpf.Abstractions;
using Connector.Wpf.Abstractions.ViewModels;
using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Connector.Wpf.ViewModels
{
    /// <summary>
    /// Trade view model
    /// </summary>
    public class TradeViewModel : BaseViewModel, ITradeViewModel
    {
        private TradeConnector tradeConnector;

        public TradeConnector TradeConnector
        {
            get
            {
                if (tradeConnector == null)
                    tradeConnector = new TradeConnector();

                return tradeConnector;
            }
        }

        ObservableCollection<Trade> trades = new ObservableCollection<Trade>();
        public ObservableCollection<Trade> Trades
        {
            get => trades;
            set { this.RaiseAndSetIfChanged(ref trades, value); }
        }

        public TradeViewModel()
        {
            SendRequest = ReactiveCommand.CreateFromTask(async () =>
            {
                IsBusy = true;
                ICollection<Trade> result = await TradeConnector.GetRestEntitiesAsync($"v2/trades/{Symbol}/hist");
                Trades = new ObservableCollection<Trade>(result);
                IsBusy = false;

            }, this.WhenAny(x => x.Symbol, x => !string.IsNullOrEmpty(x.Value)));
        }
    }
}
