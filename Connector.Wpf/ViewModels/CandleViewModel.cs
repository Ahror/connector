using ReactiveUI;

namespace Connector.Wpf.ViewModels
{
    public class CandleViewModel : BaseViewModel, ICandleViewModel
    {
        string timeFrame;
        public string TimeFrame { get => timeFrame; set { this.RaiseAndSetIfChanged(ref timeFrame, value); } }

        string section;
        public string Section
        {
            get => section;
            set { this.RaiseAndSetIfChanged(ref section, value); }
        }
    }
}
