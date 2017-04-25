﻿using Prism.Mvvm;
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

namespace CCL_Oil_Labs_Control.ViewModels
{
    public class CodesRegCoTypeMenuViewModel :BindableBase
    {

        private IList<CompanyType> _companyTypes;
        public IList<CompanyType> companyTypes
        {
            get { return _companyTypes = CompanyType.getCompanyTypes(); }
            set { SetProperty(ref _companyTypes, value); }
        }
        private IList<string> _dummy;
        public IList<string> dummy
        {
            get { return _dummy = new List<string> { "Hassan", "Bombo" }; }
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


        private DelegateCommand<object> _loadedCommand;
        public DelegateCommand<object> loadedCommand =>
            _loadedCommand ?? (_loadedCommand = new DelegateCommand<object>(delegate (object dataGrid)
            {
                var currentDataGrid = dataGrid as DataGrid;
                (dataGrid as DataGrid).Columns[1].Header = "اسم الشركة";
            }
            , dataGrid => dataGrid is DataGrid && dataGrid != null));
    }
}
