using ReactiveUI;
using System.Windows.Input;

namespace Connector.Wpf.Abstractions
{
    /// <summary>
    /// Base view model for Trade and Candle view models
    /// </summary>
    public abstract class BaseViewModel : ReactiveObject, IBaseViewModel
    {
        /// <summary>
        /// Send request command
        /// </summary>
        public ICommand SendRequest { get; set; }

        bool isBusy;

        /// <summary>
        /// Helper property to use loading while sending a request
        /// </summary>
        public bool IsBusy
        {
            get { return isBusy; }
            set { this.RaiseAndSetIfChanged(ref isBusy, value); }
        }

        string symbol = "tBTCUSD";
        public string Symbol
        {
            get => symbol;
            set { this.RaiseAndSetIfChanged(ref symbol, value); }
        }
    }
}
