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
    class CodesRegAnlMenuViewModel : BindableBase, IConfirmNavigationRequest
    {
        public CodesRegAnlMenuViewModel(GlobalNavigateCommand globalNavigateCommand)
        {
            this.globalNavigateCommand = globalNavigateCommand;
        }

        private GlobalNavigateCommand _globalNavigateCommand;
        public GlobalNavigateCommand globalNavigateCommand
        {
            get { return _globalNavigateCommand; }
            set { SetProperty(ref _globalNavigateCommand, value); }
        }


        private IList<AnalysisType> _analysisTypes = AnalysisType.getAnalysisTypes();
        public IList<AnalysisType> analysisTypes
        {
            get { return _analysisTypes; }
            set { SetProperty(ref _analysisTypes, value); }
        }

        private ObservableCollection<Analysis> _analysis = new ObservableCollection<Analysis>(Analysis.getAnalysis());
        public ObservableCollection<Analysis> analysis
        {
            get { return _analysis; }
            set { SetProperty(ref _analysis, value); }
        }

        private bool _canNavigateBack = true;
        public bool canNavigateBack
        {
            get { return _canNavigateBack; }
            set { SetProperty(ref _canNavigateBack, value); }
        }

        private int _currentSelectedRow;
        public int currentSelectedRow
        {
            get { return _currentSelectedRow; }
            set
            {
                canNavigateBack = !Utils.Utils.isThereEmpty<Analysis>(analysis, analysis => string.IsNullOrWhiteSpace(analysis.Name));
                SetProperty(ref _currentSelectedRow, value);
            }
        }
        //o => analysis.ElementAt(currentSelectedRow).Type = (o as AnalysisType).ID
        private DelegateCommand<object[]> _comboBoxSelectionChangedCommand;
        public DelegateCommand<object[]> comboBoxSelectionChangedCommand =>
            _comboBoxSelectionChangedCommand ?? (_comboBoxSelectionChangedCommand = new DelegateCommand<object[]>(o => analysis.ElementAt(currentSelectedRow).Type = (o[0] as AnalysisType).ID  , o => true));

        private DelegateCommand _deleteCommand;
        public DelegateCommand deleteCommand =>
            _deleteCommand ?? (_deleteCommand = new DelegateCommand(() => analysis.RemoveAt(currentSelectedRow), () => currentSelectedRow >= 0));

        private DelegateCommand<object> _cellSelectionChangedCommand;
        public DelegateCommand<object> cellSelectionChangedCommand =>
            _cellSelectionChangedCommand ?? (_cellSelectionChangedCommand = new DelegateCommand<object>(
                delegate (object removedCells)
                {
                    if (removedCells != null && (removedCells as IList<DataGridCellInfo>).Count > 0 && ((removedCells as IList<DataGridCellInfo>).FirstOrDefault().Item) is Analysis)
                    {
                        if (string.IsNullOrWhiteSpace((((removedCells as IList<DataGridCellInfo>).FirstOrDefault().Item) as Analysis).Name))
                        {
                            MessageBox.Show("لا يمكن ترك خانة فارغة");
                        }
                    }
                }
                , e => true));

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            continuationCallback(canNavigateBack);
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

