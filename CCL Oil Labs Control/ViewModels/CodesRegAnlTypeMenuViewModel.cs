using System;
using System.Collections.Generic;
using Prism.Mvvm;
using System.Linq;
using CCL_Oil_Labs_Control.Model;
using CCL_Oil_Labs_Control.CompositeCommands;
using Prism.Commands;
using System.Windows.Controls;
using System.Windows;
using System.Collections.ObjectModel;
using Prism.Regions;

namespace CCL_Oil_Labs_Control.ViewModels
{
    public class CodesRegAnlTypeMenuViewModel : BindableBase, IConfirmNavigationRequest
    {
        public CodesRegAnlTypeMenuViewModel(GlobalNavigateCommand globalNavigateCommand)
        {
            this.globalNavigateCommand = globalNavigateCommand;
        }

        private GlobalNavigateCommand _globalNavigateCommand;
        public GlobalNavigateCommand globalNavigateCommand
        {
            get { return _globalNavigateCommand; }
            set { SetProperty(ref _globalNavigateCommand, value); }
        }

        private ObservableCollection<OilType> _oilTypes = OilType.getOilTypes();
        public ObservableCollection<OilType> oilTypes
        {
            get { return _oilTypes; }
            set { SetProperty(ref _oilTypes, value); }
        }

        private int _currentSelectedRow;
        public int currentSelectedRow
        {
            get { return _currentSelectedRow; }
            set
            {
                canNavigateBack = !Utils.Utils.isThereEmpty<OilType>(oilTypes, oilType => string.IsNullOrWhiteSpace(oilType.TypeName));
                SetProperty(ref _currentSelectedRow, value);
            }
        }

        private DelegateCommand<object> _cellSelectionChangedCommand;
        public DelegateCommand<object> cellSelectionChangedCommand =>
            _cellSelectionChangedCommand ?? (_cellSelectionChangedCommand = new DelegateCommand<object>(
                delegate (object removedCells)
                {
                    if (removedCells != null && (removedCells as IList<DataGridCellInfo>).Count > 0 && ((removedCells as IList<DataGridCellInfo>).FirstOrDefault().Item) is OilType)
                    {
                        if (string.IsNullOrWhiteSpace((((removedCells as IList<DataGridCellInfo>).FirstOrDefault().Item) as OilType).TypeName))
                        {
                            MessageBox.Show("لا يمكن ترك خانة فارغة");
                        }
                    }
                }
                , e => true));

        private bool _canNavigateBack = true;
        public bool canNavigateBack
        {
            get { return _canNavigateBack; }
            set { SetProperty(ref _canNavigateBack, value); }
        }

        private DelegateCommand _deleteCommand;
        public DelegateCommand deleteCommand =>
            _deleteCommand ?? (_deleteCommand = new DelegateCommand(delegate { oilTypes.RemoveAt(currentSelectedRow); }, () => currentSelectedRow >= 0));

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
            DatabaseEntities.Initiate().SaveChanges();
        }
    }
}
