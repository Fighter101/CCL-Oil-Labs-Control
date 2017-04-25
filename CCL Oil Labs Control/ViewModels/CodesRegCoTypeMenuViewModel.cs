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
    public class CodesRegCoTypeMenuViewModel :BindableBase
    {
        private List<string> choices = new List<string>();
        private IList<CompanyType> _companyTypes;
        public IList<CompanyType> companyTypes
        {
            get { return _companyTypes = CompanyType.getCompanyTypes(); }
            set { SetProperty(ref _companyTypes, value); }
        }
        private ObservableCollection<string> _dummy;
        public ObservableCollection<string> dummy
        {
            get { return _dummy = new ObservableCollection<string> { "Hassan2", "Bombo2" }; }
            set { SetProperty(ref _dummy, value); }
        }
        private GlobalNavigateCommand _globalNavigateCommand;
        public GlobalNavigateCommand globalNavigateCommand
        {
            get { return _globalNavigateCommand; }
            set { SetProperty(ref _globalNavigateCommand, value); }
        }
        public CodesRegCoTypeMenuViewModel(GlobalNavigateCommand globalNavigateCommand)
        {
            this.globalNavigateCommand = globalNavigateCommand;
        }
        private int _currentSelectedRow;
        public int currentSelectedRow
        {
            get { return _currentSelectedRow; }
            set { SetProperty(ref _currentSelectedRow, value); }
        }


        private DelegateCommand<object> _dataGridComboBoxSelectionChangedCommand;
        public DelegateCommand<object> dataGridComboBoxSelectionChangedCommand =>
            _dataGridComboBoxSelectionChangedCommand ?? (_dataGridComboBoxSelectionChangedCommand = new DelegateCommand<object>(
                 delegate (object selectedItem)
                 {
                     choices[currentSelectedRow] = selectedItem.ToString();
                 }
            , p=>true));


    }
}
