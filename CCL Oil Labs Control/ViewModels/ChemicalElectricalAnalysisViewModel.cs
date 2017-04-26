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
        public ChemicalElectricalAnalysisViewModel(GlobalNavigateCommand globalNavigateCommand)
        {
            this.globalNavigateCommand = globalNavigateCommand;
        }

        private GlobalNavigateCommand _globalNavigateCommand;
        public GlobalNavigateCommand globalNavigateCommand
        {
            get { return _globalNavigateCommand; }
            set { SetProperty(ref _globalNavigateCommand, value); }
        }

        private IList<String> _experiment = ChemElecAnlSetter.experiment;
        public IList<String> experiment
        {
            get { return _experiment; }
            set { _experiment = value; }
        }

        private IList<String> _unit = ChemElecAnlSetter.unit;
        public IList<String> unit
        {
            get { return _unit; }
            set { _unit = value; }
        }

        private IList<String> _stMethod = ChemElecAnlSetter.stMethod;
        public IList<String> stMethod
        {
            get { return _stMethod; }
            set { _stMethod = value; }
        }

        private ObservableCollection<double> _result = ChemElecAnlSetter.result;
        public ObservableCollection<double> result
        {
            get { return _result; }
            set { _result = value; }
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
