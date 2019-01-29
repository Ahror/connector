using Connector.Abstractions;
using Connector.Connectors;
using ReactiveUI;
using System.Windows.Input;

namespace Connector.Wpf.ViewModels
{
    public abstract class BaseViewModel : ReactiveObject, IBaseViewModel
    {
        public ICommand SendRequest { get; set; }

        public BaseViewModel()
        {
        }

        bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set { this.RaiseAndSetIfChanged(ref isBusy, value); }
        }

        string symbol;
        public string Symbol
        {
            get => symbol;
            set { this.RaiseAndSetIfChanged(ref symbol, value); }
        }
    }
}
