using Autofac;
using Connector.Wpf.ViewModels;
using System.Windows;
namespace Connector.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IContainer Container { get; private set; }
        public App()
        {
            var container = new ContainerBuilder();
            container.RegisterType<CandleViewModel>().As<ICandleViewModel>().InstancePerLifetimeScope();
            container.RegisterType<TradeViewModel>().As<ITradeViewModel>().InstancePerLifetimeScope();
            Container = container.Build();
        }
    }
}
