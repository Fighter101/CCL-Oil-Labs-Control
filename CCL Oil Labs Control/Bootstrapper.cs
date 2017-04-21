using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Prism.Unity;
using CCL_Oil_Labs_Control.Views;
using Prism.Modularity;
using CCL_Oil_Labs_Control.CompositeCommands;
using CCL_Oil_Labs_Control.ViewModels;
namespace CCL_Oil_Labs_Control 
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
        
          protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            //TODO : Remove Magic String
            Container.RegisterType<IApplicationCommands, FillDataAndNavigateCommand>(new ContainerControlledLifetimeManager());
            Container.RegisterType<EntryMenuViewModel, EntryMenuViewModel>(new ContainerControlledLifetimeManager());
            Container.RegisterTypeForNavigation<EntryMenu>("EntryMenu");
            Container.RegisterTypeForNavigation<Dummy>("Dummy");
        }
    }
}
