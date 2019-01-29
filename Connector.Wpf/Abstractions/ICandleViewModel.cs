namespace Connector.Wpf.Abstractions
{
    /// <summary>
    /// ICandleViewModel interface
    /// </summary>
    public interface ICandleViewModel : IBaseViewModel
    {
        string Section { get; set; }
        string TimeFrame { get; set; }
    }
}