namespace Connector.Wpf.ViewModels
{
    public interface IBaseViewModel : ReactiveUI.IReactiveObject
    {
        bool IsBusy { get; set; }
        string Symbol { get; set; }
    }
}