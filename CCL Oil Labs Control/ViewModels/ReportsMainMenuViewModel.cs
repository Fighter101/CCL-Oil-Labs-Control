using System;
using System.Collections.Generic;
using System.Linq;
using CCL_Oil_Labs_Control.CompositeCommands;
using Prism.Mvvm;
using CCL_Oil_Labs_Control.Model;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Regions;
using System.Windows.Controls;
using System.Windows;

namespace CCL_Oil_Labs_Control.ViewModels 
{
    public class ReportsMainMenuViewModel : BindableBase, IConfirmNavigationRequest
    {
        public ReportsMainMenuViewModel(GlobalNavigateCommand globalNavigateCommand)
        {
            this.globalNavigateCommand = globalNavigateCommand;
        }

        private GlobalNavigateCommand _globalNavigateCommand;
        public GlobalNavigateCommand globalNavigateCommand
        {
            get { return _globalNavigateCommand; }
            set { SetProperty(ref _globalNavigateCommand, value); }
        }

        private bool _canNavigateBack = true;
        public bool canNavigateBack
        {
            get { return _canNavigateBack; }
            set { SetProperty(ref _canNavigateBack, value); }
        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //TODO code to Save in DB
        }
    }
}
