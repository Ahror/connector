using Autofac;
using Connector.Wpf.ViewModels;
using System.Windows.Controls;

namespace Connector.Wpf.Controls
{
    /// <summary>
    /// Interaction logic for TradeControl.xaml
    /// </summary>
    public partial class TradeControl : UserControl
    {
        public TradeControl()
        {
            InitializeComponent();
            DataContext = App.Container.Resolve<ITradeViewModel>();
        }
    }
}
