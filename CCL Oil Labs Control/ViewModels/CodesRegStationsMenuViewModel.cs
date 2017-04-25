using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCL_Oil_Labs_Control.Model;
using CCL_Oil_Labs_Control.CompositeCommands;
using Prism.Mvvm;
using Prism.Commands;
using System.Windows;
using System.Security;
using System.Windows.Controls;

namespace CCL_Oil_Labs_Control.ViewModels
{
    class CodesRegStationsMenuViewModel : BindableBase
    {
        private IGLobalNavigateCommand _globalNavigateCommand;
        public IGLobalNavigateCommand globalNavigateCommand
        {
            get { return _globalNavigateCommand; }
            set { SetProperty(ref _globalNavigateCommand, value); }
        }
    }
}
