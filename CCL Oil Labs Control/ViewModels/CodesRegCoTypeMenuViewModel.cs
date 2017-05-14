using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCL_Oil_Labs_Control.Model;
using CCL_Oil_Labs_Control.CompositeCommands;
using Prism.Commands;
using System.Windows.Controls;
using System.Windows;
using System.Collections.ObjectModel;
using Prism.Regions;

namespace CCL_Oil_Labs_Control.ViewModels
{
    public class CodesRegCoTypeMenuViewModel : BindableBase, IConfirmNavigationRequest
    {
        private int emptyCellsCounter = 0;

        private DataGrid dataGrid;
        private ObservableCollection<CompanyType> _companyTypes = CompanyType.getCompanyTypes();
        public ObservableCollection<CompanyType> companyTypes
        {
            get { return _companyTypes  ; }
            set { SetProperty(ref _companyTypes, value); }
        }
        private GlobalNavigateCommand _globalNavigateCommand;
        public GlobalNavigateCommand globalNavigateCommand
        {
            get { return _globalNavigateCommand; }
            set { SetProperty(ref _globalNavigateCommand, value); }}
        public CodesRegCoTypeMenuViewModel(GlobalNavigateCommand globalNavigateCommand)
        {
            this.globalNavigateCommand = globalNavigateCommand;
        }


        private int _currentSelectedRow;
        public int currentSelectedRow
        {
            get { return _currentSelectedRow; }
            set
            {
                emptyCellsCounter = 0;
                foreach (var company in companyTypes.Where(company => string.IsNullOrWhiteSpace(company.TypeName)))
                {
                    emptyCellsCounter += 1;
                }
                canNavigateBack = emptyCellsCounter == 0;
                SetProperty(ref _currentSelectedRow, value);
            }
        }


        private bool _canNavigateBack = true;
        public bool canNavigateBack
        {
            get { return _canNavigateBack; }
            set { SetProperty(ref _canNavigateBack, value); }
        }  
        

        private DelegateCommand<object> _cellSelectionChangedCommand;
        public DelegateCommand<object> cellSelectionChangedCommand =>
            _cellSelectionChangedCommand ?? (_cellSelectionChangedCommand = new DelegateCommand<object>(
                delegate (object removedCells)
                {
                    if (removedCells!=null && (removedCells as IList<DataGridCellInfo>).Count > 0 && ((removedCells as IList<DataGridCellInfo>).FirstOrDefault().Item) is CompanyType )
                    {
                       if(string.IsNullOrWhiteSpace((((removedCells as IList<DataGridCellInfo>).FirstOrDefault().Item) as CompanyType).TypeName))
                        {
                            MessageBox.Show("لا يمكن ترك خانة فارغة");
                        }      
                    }
                }
                , e => true));


        private DelegateCommand<object> _dataGridLoadedCommand;
        public DelegateCommand<object> dataGridLoadedCommand =>
            _dataGridLoadedCommand ?? (_dataGridLoadedCommand = new DelegateCommand<object>(grid => dataGrid = grid as DataGrid, o => true));



        private DelegateCommand _deleteCommand;
        public DelegateCommand deleteCommand =>
            _deleteCommand ?? (_deleteCommand = new DelegateCommand(delegate { companyTypes.RemoveAt(currentSelectedRow); }, ()=> currentSelectedRow >=0 ));

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
