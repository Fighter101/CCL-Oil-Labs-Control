using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using CCL_Oil_Labs_Control.CompositeCommands;
namespace CCL_Oil_Labs_Control.ViewModels
{
    public class CodesAddingMenuViewModel : BindableBase
    {

        private IGLobalNavigateCommand _globalNavigateCommand;
        public IGLobalNavigateCommand globalNavigateCommand
        {
            get { return _globalNavigateCommand; }
            set { SetProperty(ref _globalNavigateCommand, value); }
        }
        public CodesAddingMenuViewModel(GlobalNavigateCommand globalNavigateCommand)
        {
            this.globalNavigateCommand = globalNavigateCommand;
        }
    }

}
