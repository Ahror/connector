namespace Connector.Wpf.ViewModels
{
    public interface ICandleViewModel : IBaseViewModel
    {
        string Section { get; set; }
        string TimeFrame { get; set; }
    }
}