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
using CCL_Oil_Labs_Control.Utils;

namespace CCL_Oil_Labs_Control.ViewModels
{
    class ChemicalElectricalAnalysisViewModel : BindableBase, IConfirmNavigationRequest
    {

        private ChemElecAnlSetter chemElecAnlSetter;
        public ChemicalElectricalAnalysisViewModel(GlobalNavigateCommand globalNavigateCommand)
        {
            this.globalNavigateCommand = globalNavigateCommand;
            chemElecAnlSetter = new ChemElecAnlSetter();
            expirments = chemElecAnlSetter.expirments;
        }

        private GlobalNavigateCommand _globalNavigateCommand;
        public GlobalNavigateCommand globalNavigateCommand
        {
            get { return _globalNavigateCommand; }
            set { SetProperty(ref _globalNavigateCommand, value); }
        }

        private IList<Expirments> _expirments ;
        public IList<Expirments> expirments
        {
            get { return _expirments; }
            set { SetProperty(ref _expirments, value); }
        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            continuationCallback(true);
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
