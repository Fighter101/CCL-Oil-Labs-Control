using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using CCL_Oil_Labs_Control.Views;
using CCL_Oil_Labs_Control.CompositeCommands;
namespace CCL_Oil_Labs_Control.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        public DelegateCommand<string> navigateCommand { get; set; }

        public MainWindowViewModel(IRegionManager _regionManager, IApplicationCommands appCommand, IGLobalNavigateCommand globalCommand, AddingCodesNavigateCommand addingCodesNavigateCommand)
        {
            regionManager = _regionManager;
            applicationCommand = appCommand;
            navigateCommand = new DelegateCommand<string>(navigate);
            appCommand.fillDataAndNavigateCommand.RegisterCommand(navigateCommand);
            this.globalNavigateCommand = globalCommand;
            globalNavigateCommand.globalNavigateCommand.RegisterCommand(navigateCommand);
            addingCodesNavigateCommand.addingCodesNavigateCommand.RegisterCommand(navigateCommand);
        }

        private void navigate(string URI)
        {
            regionManager.RequestNavigate("MainRegion", URI);
        }
        private IApplicationCommands _applicationCommand;
        private IGLobalNavigateCommand _globalNavigateCommand;
        public IApplicationCommands applicationCommand
        {
            get { return _applicationCommand; }
            set { SetProperty(ref _applicationCommand, value); }
        }
        public IGLobalNavigateCommand globalNavigateCommand
        {
            get { return _globalNavigateCommand; }
            set { SetProperty(ref _globalNavigateCommand, value); }
        }
    }
}
