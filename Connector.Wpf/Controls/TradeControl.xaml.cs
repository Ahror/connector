﻿using Autofac;
using Connector.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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