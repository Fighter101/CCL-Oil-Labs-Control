using CCL_Oil_Labs_Control.CompositeCommands;
using CCL_Oil_Labs_Control.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CCL_Oil_Labs_Control.ViewModels
{
    public class recordReportViewModel : BindableBase
    {
        private GlobalNavigateCommand _globalNavigateCommand;
        public GlobalNavigateCommand globalNavigateCommand
        {
            get { return _globalNavigateCommand; }
            set { SetProperty(ref _globalNavigateCommand, value); }
        }
        public recordReportViewModel(GlobalNavigateCommand glovalNavigateCommand)
        {
            this.globalNavigateCommand = globalNavigateCommand;
            records = Record.getRecords();
            currentRecord = records[index++];
            constructString();
        }
        public void constructString()
        {
            recordReport = String.Empty;
            recordReport += "Import Date : " + currentRecord.ImportDate.ToShortDateString()+"\n";
            recordReport += "Export Date : " + ((currentRecord.ExportDate)).ToString() + "\n";
            recordReport += "Station Name : " + Station.getSation((int)currentRecord.Station).Name + "\n";
            recordReport += "Results : " + currentRecord.Results + "\n";
            recordReport += "Recommendations : " + currentRecord.Recommendations + "\n";
        }
        private int index = 0;
        public Record currentRecord { get; set; }
        private ObservableCollection<Record> _records;
        public ObservableCollection<Record> records
        {
            get { return _records; }
            set { SetProperty(ref _records, value); }
        }

        private string _recordReport;
        public string recordReport
        {
            get { return _recordReport; }
            set { SetProperty(ref _recordReport, value); }
        }
        private DelegateCommand _nextButtonCommand;
        public DelegateCommand nextButtonCommand =>
            _nextButtonCommand ?? (_nextButtonCommand = new DelegateCommand(delegate 
            {
                currentRecord = records[++index];
                constructString();
            }, ()=> true));
    }
}
