using Autofac;
using Connector.Wpf.ViewModels;
using System.Windows.Controls;

namespace Connector.Wpf.Controls
{
    /// <summary>
    /// Interaction logic for CandleControl.xaml
    /// </summary>
    public partial class CandleControl : UserControl
    {
        public CandleControl()
        {
            InitializeComponent();
            DataContext = App.Container.Resolve<ICandleViewModel>();
        }
    }
}
