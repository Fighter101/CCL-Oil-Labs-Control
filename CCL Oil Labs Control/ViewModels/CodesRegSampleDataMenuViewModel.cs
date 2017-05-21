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
            this.eventAggregator = eventAggregator;
        }

        private IEventAggregator _eventAggregator;
        public IEventAggregator eventAggregator
        {
            get { return _eventAggregator; }
            set { SetProperty(ref _eventAggregator, value); }
        }
        private Record _currentRecord;
        private Record currentRecord { get
            {
                if (_currentRecord == null)
                {
                    _currentRecord = new Record();
                }
                return _currentRecord;
            }
            set
            {
                if (value == null)
                    nulledCurrentRecord = true;
                SetProperty(ref _currentRecord , value);
                
            }
        }
        private bool nulledCurrentRecord = false;

        private GlobalNavigateCommand _globalNavigateCommand;
        public GlobalNavigateCommand globalNavigateCommand
        {
            get { return _globalNavigateCommand; }
            set { SetProperty(ref _globalNavigateCommand, value); }
        }
        private void clearData()
        {
            this.importDate = DateTime.Now;
            this.importNumber = 0;
            this.exportDate = DateTime.Now;
            this.exportNumber = 0;
            this.companyTypeSelectedID = 0;
            this.selectedCompanyID = 0;
            this.selectedOilTypeID = 0;
            this.actualStationID = 0;
            this.selectedStationID = 0;
            this.selectedAnalysisType = 0;
            this.selectedLab = 0;
            this.recommendations = "";
            this.results = "";
            this.price = 0;
        }
        private void checkForRecord(int importNum , DateTime importDate)
        {
            currentRecord.ImportDate = importDate;
            currentRecord.ImportNo = importNum;
             currentRecord = currentRecord.exists();
                if (!nulledCurrentRecord)
                {
                    this.importDate = currentRecord.ImportDate;
                    this.importNumber = (int)currentRecord.ImportNo ;
                    this.exportDate = (DateTime)currentRecord.ExportDate;
                    this.exportNumber = (int)currentRecord.ExportNo;
                    this.companyTypeSelectedID = (int)currentRecord.CompanyType;
                    this.selectedCompanyID = (int)currentRecord.Company;
                    this.selectedOilTypeID = (int)currentRecord.OilType;
                    this.actualStationID = (int)currentRecord.Station;
                    this.selectedAnalysisType = (int)currentRecord.OilAnalysisType;
                    this.selectedLab = (int)currentRecord.Lab;
                    this.recommendations = currentRecord.Recommendations;
                    this.results = currentRecord.Results;
                    this.price = (double)currentRecord.Cost;
                }
                else
                {
                    //clearData();
                }
            nulledCurrentRecord = false;
        }
        private DateTime _importCheckDate;
        public DateTime importCheckDate
        {
            get { return _importCheckDate; }
            set
            {
                SetProperty(ref _importCheckDate, value);
                checkForRecord(-1, importCheckDate);
               

            }
        }

        private DateTime _importDate;
        public DateTime importDate
        {
            get { return _importDate; }
            set
            {
                SetProperty(ref _importDate, value);
                currentRecord.ImportDate = this.importDate;
            }
        }

        private DateTime _exportDate;
        public DateTime exportDate
        {
            get { return _exportDate; }
            set
            {
                SetProperty(ref _exportDate, value);
                currentRecord.ExportDate = this.exportDate;
            }
        }

        private int _importCheckNumber;
        public int importCheckNumber
        {
            get { return _importCheckNumber; }
            set
            {
                SetProperty(ref _importCheckNumber, value);
                checkForRecord(importCheckNumber, DateTime.Now);
            }
        }

        private int _importNumber;
        public int importNumber
        {
            get { return _importNumber; }
            set
            {
                SetProperty(ref _importNumber, value);
                currentRecord.ImportNo = this._importNumber;
            }
        }

        private int _exportNumber;
        public int exportNumber
        {
            get { return _exportNumber; }
            set
            {
                SetProperty(ref _exportNumber, value);
                currentRecord.ExportNo = this._exportNumber;
            }
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
                _companies = Company.getCompanies(companyTypeSelectedID);

                currentRecord.CompanyType = _companyTypeSelectedID;
            }
        }

        private IList<Company> _companies = Company.getCompanies();
        public IList<Company> companies
        {
            get { return _companies; }
            set
            {
                SetProperty(ref _companies, value);
            }
        }

        private int _selectedCompanyID;
        public int selectedCompanyID
        {
            get { return _selectedCompanyID; }
            set
            {
                SetProperty(ref _selectedCompanyID, value);
                station = Station.getStations(selectedCompanyID, companyTypeSelectedID);
                currentRecord.Company = _selectedCompanyID;
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
            set
            {
                SetProperty(ref _selectedStationID, value);
               currentRecord.Station = selectedStationID;
            }
        }
        private int _actualStationID;
        public int actualStationID
        {
            get { return _actualStationID; }
            set
            {
                SetProperty(ref _actualStationID, value);
                currentStation = Station.getSation(_actualStationID);
            }
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
            set
            {
                SetProperty(ref _selectedOilTypeID, value);
                currentRecord.OilType = _selectedOilTypeID;
            }
        }

        private IList<OilAnalysisType> _analysisTypes = OilAnalysisType.getAnalysis();
        public IList<OilAnalysisType> analysisTypes
        {
            get { return _analysisTypes; }
            set
            {
                SetProperty(ref _analysisTypes, value);
            }
        }

        private int _selectedAnalysisType;
        public int selectedAnalysisType
        {
            get { return _selectedAnalysisType; }
            set
            {
                SetProperty(ref _selectedAnalysisType, value);
                currentRecord.OilAnalysisType = _selectedAnalysisType;
            }
        }

        private IList<Lab> _labs = Lab.getLabs();
        public IList<Lab> labs
        {
            get { return _labs; }
            set { SetProperty(ref _labs, value); }
        }

        private int ? _selectedLab;
        public int ? selectedLab
        {
            get { return _selectedLab; }
            set
            {
                SetProperty(ref _selectedLab, value);
                currentRecord.Lab = _selectedLab;
            }
        }
        private string _results;
        public string results
        {
            get { return _results; }
            set
            {
                SetProperty(ref _results, value);
                currentRecord.Results = _results;
            }
        }

        private string _recommendations;
        public string recommendations
        {
            get { return _recommendations; }
            set
            {
                SetProperty(ref _recommendations, value);
                currentRecord.Recommendations = _recommendations;
            }
        }
        private Station _currentStation;
        public Station currentStation
        {
            get { return _currentStation; }
            set { SetProperty(ref _currentStation, value); }
        }
        private double _price;
        public double price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }

        private DelegateCommand _printingCommand;
        public DelegateCommand printingCommand =>
            _printingCommand ?? (_printingCommand = new DelegateCommand(print, canPrint));

        private void print()
        {

            Utils.pdfCreator.createPDF(currentStation.Name, currentRecord.ImportDate, DateTime.Today, Transformer.getResults(), "Normal");
        }
        private bool canPrint()
        {
            return true;
        }
        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
           
            continuationCallback(true);
            eventAggregator.GetEvent<RecordedEvent>().Publish(currentRecord);
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
            currentRecord.sync();
           // eventAggregator.GetEvent<RecordedEvent>().Publish(currentRecord);
        }
    }
}
