﻿using System;
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
    public class CodesRegCoMenuViewModel :BindableBase , IConfirmNavigationRequest
    {
       
        public CodesRegCoMenuViewModel (GlobalNavigateCommand globalNavigateCommand)
        {
            this.globalNavigateCommand = globalNavigateCommand;
        }

        private GlobalNavigateCommand _globalNavigateCommand;
        public GlobalNavigateCommand globalNavigateCommand
        {
            get { return _globalNavigateCommand; }
            set { SetProperty(ref _globalNavigateCommand, value); }
        }

        private IList<CompanyType> _companyTypes = CompanyType.getCompanyTypes();
        public IList<CompanyType> companyTypes
        {
            get { return _companyTypes; }
            set { SetProperty(ref _companyTypes, value); }
        }

        private ObservableCollection<Company> _companies = Company.getCompanies();
        public ObservableCollection<Company> companies
        {
            get { return _companies; }
            set { SetProperty(ref _companies, value); }
        }
        private bool _canNavigateBack = true;
        public bool canNavigateBack
        {
            get { return _canNavigateBack; }
            set { SetProperty(ref _canNavigateBack, value); }
        }

        private int _currentSelectedRow ;
        public int currentSelectedRow
        {
            get { return _currentSelectedRow; }
            set
            {
                canNavigateBack= !Utils.Utils.isThereEmpty<Company>(companies, company => string.IsNullOrWhiteSpace(company.Name));
                SetProperty(ref _currentSelectedRow, value);
            }
        }


        private DelegateCommand<object[]> _comboBoxSelectionChangedCommand;
        public DelegateCommand<object[]> comboBoxSelectionChangedCommand =>
            _comboBoxSelectionChangedCommand ?? (_comboBoxSelectionChangedCommand = new DelegateCommand<object[]>(
                delegate(object[] o)
                {
                    if(currentSelectedRow == companies.Count)
                    {
                        //What the duck am i doing here ?
                        var newCompany = new Company();
                        newCompany.Type = 1;
                        //Because Types in the DB start from zero--> am gonna kill that dev
                        companies.Add(newCompany);
                        currentSelectedRow--;
                    }
                    if (o is object[] && (o as object[]).Count() > 0 && o[0] is CompanyType && (o[0] as CompanyType).ID !=0)
                    {
                        companies.ElementAt(currentSelectedRow).Type = (o[0] as CompanyType).ID;
                        companies.ElementAt(currentSelectedRow).CompanyType = (o[0] as CompanyType);
                    }
                }
                , o => currentSelectedRow >= 0)).ObservesProperty(()=>currentSelectedRow);

        private DelegateCommand _deleteCommand;
        public DelegateCommand deleteCommand =>
            _deleteCommand ?? (_deleteCommand = new DelegateCommand(() => companies.RemoveAt(currentSelectedRow), () => currentSelectedRow >= 0 && currentSelectedRow < companies.Count()));

        private DelegateCommand<object> _cellSelectionChangedCommand;
        public DelegateCommand<object> cellSelectionChangedCommand =>
            _cellSelectionChangedCommand ?? (_cellSelectionChangedCommand = new DelegateCommand<object>(
                delegate (object removedCells)
                {
                    if (removedCells != null && (removedCells as IList<DataGridCellInfo>).Count > 0 && ((removedCells as IList<DataGridCellInfo>).FirstOrDefault().Item) is Company)
                    {
                        if (string.IsNullOrWhiteSpace((((removedCells as IList<DataGridCellInfo>).FirstOrDefault().Item) as Company).Name))
                        {
                            MessageBox.Show("لا يمكن ترك خانة فارغة");
                        }
                    }
                }
                , e => true));

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            continuationCallback(!Utils.Utils.isThereEmpty<Company>(companies, company => string.IsNullOrWhiteSpace(company.Name)));
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
            try
            {
                DatabaseEntities.Initiate().SaveChanges();
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("You don't want to change this, I know better :P");
            }
        }
    }
}
    