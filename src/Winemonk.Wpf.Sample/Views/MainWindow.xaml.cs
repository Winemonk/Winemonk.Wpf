using Prism.Ioc;
using Prism.Regions;
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
using System.Windows.Shapes;

namespace Winemonk.Wpf.Sample.Views
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private IContainerProvider _containerProvider;
        private IRegionManager _regionManager;

        public MainWindow(IContainerProvider containerProvider, IRegionManager regionManager)
        {
            _containerProvider = containerProvider;
            _regionManager = regionManager;
            InitializeComponent();
            this.Loaded += (s, e) => InitalizeRegions();
        }

        private void InitalizeRegions()
        {
            _regionManager.RegisterViewWithRegion("TitleRegion", typeof(TitleView));
            _regionManager.RegisterViewWithRegion("SideRegion", typeof(SideView));
            _regionManager.RegisterViewWithRegion("TopRegion", typeof(TopView));
        }
    }
}
