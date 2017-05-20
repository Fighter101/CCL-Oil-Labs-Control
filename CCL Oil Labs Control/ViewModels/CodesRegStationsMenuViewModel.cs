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
using System.Collections.ObjectModel;
using Prism.Regions;

namespace CCL_Oil_Labs_Control.ViewModels
{
    public class CodesRegStationsMenuViewModel : BindableBase, IConfirmNavigationRequest
    {

        public CodesRegStationsMenuViewModel(GlobalNavigateCommand globalNavigateCommand)
        {
            this.globalNavigateCommand = globalNavigateCommand;
        }
        private IGLobalNavigateCommand _globalNavigateCommand;
        public IGLobalNavigateCommand globalNavigateCommand
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

        private int _selectedCompanyType;
        public int selectedCompanyType
        {
            get { return _selectedCompanyType; }
            set { SetProperty(ref _selectedCompanyType, value); }
        }

        private IList<Company> _companies = Company.getCompanies(2);
        public IList<Company> companies
        {
            get { return _companies; }
            set { SetProperty(ref _companies, value); }
        }

        private int _selectedCompany;
        public int selectedCompany
        {
            get { return _selectedCompany; }
            set { SetProperty(ref _selectedCompany, value); }
        }

        private ObservableCollection<Station> _stations;
        public ObservableCollection<Station> stations
        {
            get { return _stations; }
            set { SetProperty(ref _stations, value); }
        }




        private DelegateCommand _companyTypeComboBoxSelectionChangedCommand;
        public DelegateCommand companyTypeComboBoxSelectionChangedCommand =>
            _companyTypeComboBoxSelectionChangedCommand ?? (_companyTypeComboBoxSelectionChangedCommand = new DelegateCommand(
                delegate
            {
                companies = Company.getCompanies(selectedCompanyType);
                
            }, () => true));

        private string _stationName;
        public string stationName
        {
            get { return _stationName; }
            set
            {
                SetProperty(ref _stationName, value);
                stations = (Station.getStations(selectedCompany, selectedCompanyType));
                var returnedStation = Station.getStations(selectedCompany, selectedCompanyType, stationName);
                if(returnedStation?.Count == 0 )
                {
                    var addedStation = new Station();
                    addedStation.CompanyName = selectedCompany;
                    addedStation.CompanyType = selectedCompanyType;
                    addedStation.Name = stationName;
                    stations.Add(addedStation);
                    DatabaseEntities.Initiate().SaveChanges();
                }
                else
                {
                    stations = returnedStation;
                }
            }
        }

        private int _currentSelectedRow;
        public int currentSelectedRow
        {
            get { return _currentSelectedRow; }
            set { SetProperty(ref _currentSelectedRow, value); }
        }

        private DelegateCommand _okButtonCommand;
        public DelegateCommand okButtonCommand =>
            _okButtonCommand ?? (_okButtonCommand = new DelegateCommand(() => stations = Station.getStations(selectedCompany,selectedCompanyType), ()=>selectedCompany!=0 && selectedCompanyType!=0)).ObservesProperty(()=>selectedCompany).ObservesProperty(()=>selectedCompanyType);

        private DelegateCommand _deleteCommand;
        public DelegateCommand deleteCommand =>
            _deleteCommand ?? (_deleteCommand = new DelegateCommand(()=>stations.RemoveAt(currentSelectedRow), ()=>currentSelectedRow >=0)).ObservesProperty(()=>currentSelectedRow);

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            continuationCallback (true);
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
