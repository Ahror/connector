﻿namespace Connector.Wpf.Abstractions
{
    /// <summary>
    /// IBaseViewModel interface
    /// </summary>
    public interface IBaseViewModel : ReactiveUI.IReactiveObject
    {
        bool IsBusy { get; set; }
        string Symbol { get; set; }
    }
}