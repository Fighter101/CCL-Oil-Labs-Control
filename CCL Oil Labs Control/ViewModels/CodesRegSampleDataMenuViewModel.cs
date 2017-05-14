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
using CCL_Oil_Labs_Control.Events;
using Prism.Events;

namespace CCL_Oil_Labs_Control.ViewModels
{
    public class CodesRegSampleDataMenuViewModel:BindableBase, IConfirmNavigationRequest
    {
        public CodesRegSampleDataMenuViewModel (GlobalNavigateCommand globalNavigateCommand , IEventAggregator eventAggregator)
        {
            this.globalNavigateCommand = globalNavigateCommand;
            currentRecord = new Record();
            this.eventAggregator = eventAggregator;
        }

        private IEventAggregator _eventAggregator;
        public IEventAggregator eventAggregator
        {
            get { return _eventAggregator; }
            set { SetProperty(ref _eventAggregator, value); }
        }
        public Record currentRecord { get; set; }

        private GlobalNavigateCommand _globalNavigateCommand;
        public GlobalNavigateCommand globalNavigateCommand
        {
            get { return _globalNavigateCommand; }
            set { SetProperty(ref _globalNavigateCommand, value); }
        }

        private DateTime _importCheckDate;
        public DateTime importCheckDate
        {
            get { return _importCheckDate; }
            set
            {
                SetProperty(ref _importCheckDate, value);
                currentRecord = currentRecord == null ? new Record(): currentRecord;
                currentRecord.ImportNo = -1;
                currentRecord.ImportDate = _importCheckDate;
                currentRecord = currentRecord.exists();
                if (currentRecord != null)
                {
                    this.importDate = currentRecord.ImportDate;
                    this.importNumber = (int)currentRecord.ImportNo ;
                    this.exportDate = (DateTime)currentRecord.ExportDate;
                    this.exportNumber = (int)currentRecord.ExportNo;
                    this.companyTypeSelectedID = (int)currentRecord.CompanyType;
                    this.selectedCompanyID = (int)currentRecord.Company;
                    this.selectedOilTypeID = (int)currentRecord.OilType;
                    this.selectedStationID = (int)currentRecord.Station;
                    this.selectedAnalysisType = (int)currentRecord.OilAnalysisType;
                    this.selectedLab = (int)currentRecord.Lab;
                    this.recommendations = currentRecord.Recommendations;
                    this.results = currentRecord.Results;
                    this.price = (double)currentRecord.Cost;

                }

            }
        }

        private DateTime _importDate;
        public DateTime importDate
        {
            get { return _importDate; }
            set { SetProperty(ref _importDate, value); }
        }

        private DateTime _exportDate;
        public DateTime exportDate
        {
            get { return _exportDate; }
            set { SetProperty(ref _exportDate, value); }
        }

        private int _importCheckNumber;
        public int importCheckNumber
        {
            get { return _importCheckNumber; }
            set
            {
                SetProperty(ref _importCheckNumber, value);
                currentRecord = currentRecord == null ? new Record() : currentRecord;
                currentRecord.ImportNo = importCheckNumber;
                currentRecord.ImportDate = DateTime.MinValue;
                currentRecord = currentRecord.exists();
                if (currentRecord != null)
                {
                    this.importDate = currentRecord.ImportDate;
                    this.importNumber = (int)currentRecord.ImportNo;
                    this.exportDate = (DateTime)currentRecord.ExportDate;
                    this.exportNumber = (int)currentRecord.ExportNo;
                    this.companyTypeSelectedID = (int)currentRecord.CompanyType;
                    this.selectedCompanyID = (int)currentRecord.Company;
                    this.selectedOilTypeID = (int)currentRecord.OilType;
                    this.selectedStationID = (int)currentRecord.Station;
                    this.selectedAnalysisType = (int)currentRecord.OilAnalysisType;
                    this.selectedLab = (int)currentRecord.Lab;
                    this.recommendations = currentRecord.Recommendations;
                    this.results = currentRecord.Results;
                    this.price = (double)currentRecord.Cost;

                }
            }
        }

        private int _importNumber;
        public int importNumber
        {
            get { return _importNumber; }
            set { SetProperty(ref _importNumber, value); }
        }

        private int _exportNumber;
        public int exportNumber
        {
            get { return _exportNumber; }
            set { SetProperty(ref _exportNumber, value); }
        }

        private IList<CompanyType> _companyTypes = CompanyType.getCompanyTypes();
        public IList<CompanyType> companyTypes
        {
            get { return _companyTypes; }
            set { SetProperty(ref _companyTypes, value); }
        }

        private int _companyTypeSelectedID;
        public int companyTypeSelectedID
        {
            get { return _companyTypeSelectedID; }
            set
            {
                SetProperty(ref _companyTypeSelectedID, value);
                station = Station.getStations(selectedCompanyID, companyTypeSelectedID);
            }
        }

        private IList<Company> _companies = Company.getCompanies();
        public IList<Company> companies
        {
            get { return _companies; }
            set { SetProperty(ref _companies, value); }
        }

        private int _selectedCompanyID;
        public int selectedCompanyID
        {
            get { return _selectedCompanyID; }
            set
            {
                SetProperty(ref _selectedCompanyID, value);
                station = Station.getStations(selectedCompanyID, companyTypeSelectedID);
            }
        }

        private IList<Station> _station;
        public IList<Station> station
        {
            get { return _station; }
            set { SetProperty(ref _station, value); }
        }

        private int _selectedStationID;
        public int selectedStationID
        {
            get { return _selectedStationID; }
            set { SetProperty(ref _selectedStationID, value); }
        }


        private IList<OilType> _oilTypes = OilType.getOilTypes();
        public IList<OilType> oilTypes
        {
            get { return _oilTypes; }
            set { SetProperty(ref _oilTypes, value); }
        }

        private int _selectedOilTypeID;
        public int selectedOilTypeID
        {
            get { return _selectedOilTypeID; }
            set { SetProperty(ref _selectedOilTypeID, value); }
        }

        private IList<OilAnalysisType> _analysisTypes = OilAnalysisType.getAnalysis();
        public IList<OilAnalysisType> analysisTypes
        {
            get { return _analysisTypes; }
            set { SetProperty(ref _analysisTypes, value); }
        }

        private int _selectedAnalysisType;
        public int selectedAnalysisType
        {
            get { return _selectedAnalysisType; }
            set { SetProperty(ref _selectedAnalysisType, value); }
        }

        private IList<Lab> _labs = Lab.getLabs();
        public IList<Lab> labs
        {
            get { return _labs; }
            set { SetProperty(ref _labs, value); }
        }

        private int _selectedLab;
        public int selectedLab
        {
            get { return _selectedLab; }
            set { SetProperty(ref _selectedLab, value); }
        }
        private string _results;
        public string results
        {
            get { return _results; }
            set { SetProperty(ref _results, value); }
        }

        private string _recommendations;
        public string recommendations
        {
            get { return _recommendations; }
            set { SetProperty(ref _recommendations, value); }
        }

        private double _price;
        public double price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            eventAggregator.GetEvent<RecordedEvent>().Publish(currentRecord);
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
        }
    }
}
