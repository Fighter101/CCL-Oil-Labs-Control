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
using Prism.Regions;
using Microsoft.Practices.Unity;
namespace CCL_Oil_Labs_Control.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IUnityContainer container;
        IRegionManager regionManager;
        public MainWindow(IUnityContainer _container,IRegionManager _regionManger)
        {
            InitializeComponent();
            container = _container;
            regionManager = _regionManger;
            this.Loaded += MainWindowLoaded;
        }
        private void MainWindowLoaded (object sender, RoutedEventArgs e)
        {
            regionManager.Regions["MainRegion"].Add(container.Resolve<EntryMenu>());
        }
    }
}
