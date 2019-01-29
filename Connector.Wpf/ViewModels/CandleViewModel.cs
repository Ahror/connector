using Connector.Connectors;
using Connector.Model;
using Connector.Wpf.Abstractions;
using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Connector.Wpf.ViewModels
{
    /// <summary>
    /// Candle view model
    /// </summary>
    public class CandleViewModel : BaseViewModel, ICandleViewModel
    {
        string timeFrame = "1m";
        public string TimeFrame { get => timeFrame; set { this.RaiseAndSetIfChanged(ref timeFrame, value); } }

        string section = "hist";
        public string Section
        {
            get => section;
            set { this.RaiseAndSetIfChanged(ref section, value); }
        }

        private CandleConnector candleConnector;

        public CandleConnector CandleConnector
        {
            get
            {
                if (candleConnector == null) candleConnector = new CandleConnector();
                return candleConnector;
            }
        }

        ObservableCollection<Candle> candles = new ObservableCollection<Candle>();
        public ObservableCollection<Candle> Candles { get => candles; set { this.RaiseAndSetIfChanged(ref candles, value); } }

        public CandleViewModel()
        {
            SendRequest = ReactiveCommand.CreateFromTask(async () =>
            {
                IsBusy = true;
                ICollection<Candle> result = await CandleConnector.GetRestEntitiesAsync($"v2/candles/trade:{TimeFrame}:{Symbol}/{Section}");
                Candles = new ObservableCollection<Candle>(result);
                IsBusy = false;

            }, this.WhenAny(x => x.Symbol, y => y.Section, z => z.TimeFrame, (x, y, z) => !string.IsNullOrEmpty(x.Value) && !string.IsNullOrEmpty(y.Value) && !string.IsNullOrEmpty(z.Value)));
        }
    }
}
