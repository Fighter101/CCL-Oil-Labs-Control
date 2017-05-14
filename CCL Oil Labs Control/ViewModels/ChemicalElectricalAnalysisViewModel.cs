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
using CCL_Oil_Labs_Control.Utils;
using CCL_Oil_Labs_Control.Events;
using Prism.Events;

namespace CCL_Oil_Labs_Control.ViewModels
{
    class ChemicalElectricalAnalysisViewModel : BindableBase, IConfirmNavigationRequest
    {

        private ChemElecAnlSetter chemElecAnlSetter;
        public ChemicalElectricalAnalysisViewModel(GlobalNavigateCommand globalNavigateCommand ,IEventAggregator eventAggregator)
        {
            this.globalNavigateCommand = globalNavigateCommand;
            chemElecAnlSetter = new ChemElecAnlSetter();
            expirments = chemElecAnlSetter.expirments;
            results = new ObservableCollection<ResultWrapper>();
            foreach (var expirment in expirments)
            {
                results.Add(new ResultWrapper(0.0));
            }
            allResults = new List<ObservableCollection<ResultWrapper>>();
            allResults.Add(results);
            selectedEquipment = new List<int>();
            selectedEquipment.Add(1);
            transformerPotentials = new List<string>();
            transformerPotentials.Add(string.Empty);
            this.eventAggregator = eventAggregator;
            this.eventAggregator.GetEvent<RecordedEvent>().Subscribe(record => currentRecord = record);
        }
        private Record _currentRecord;
        public Record currentRecord
        {
            get { return _currentRecord; }
            set { SetProperty(ref _currentRecord, value); }
        }
        private IEventAggregator _eventAggregator;
        public IEventAggregator eventAggregator
        {
            get { return _eventAggregator; }
            set { SetProperty(ref _eventAggregator, value); }
        }
        private GlobalNavigateCommand _globalNavigateCommand;
        public GlobalNavigateCommand globalNavigateCommand
        {
            get { return _globalNavigateCommand; }
            set { SetProperty(ref _globalNavigateCommand, value); }
        }

        private IList<Expirments> _expirments ;
        public IList<Expirments> expirments
        {
            get { return _expirments; }
            set { SetProperty(ref _expirments, value); }
        }
        private IList<String> _transfomerPotentials;
        public IList<String> transformerPotentials
        {
            get { return _transfomerPotentials; }
            set { SetProperty(ref _transfomerPotentials, value); }
        }

        private IList<int> _selectedEquipment;
        public IList<int> selectedEquipment
        {
            get { return _selectedEquipment; }
            set { SetProperty(ref _selectedEquipment, value); }
        }
        private int _currentSampleIndex;
        public int currentSampleIndex
        {
            get { return _currentSampleIndex; }
            set { SetProperty(ref _currentSampleIndex, value); }
        }
        private List<ObservableCollection<ResultWrapper>> allResults { get; set; }

        private ObservableCollection<ResultWrapper> _results;
        public ObservableCollection<ResultWrapper> results
        {
            get { return _results; }
            set { SetProperty(ref _results, value); }
        }

        private int _currentSelectedRow;
        public int currentSelectedRow
        {
            get { return _currentSelectedRow; }
            set { SetProperty(ref _currentSelectedRow, value); }
        }
        private int _numSamples;
        public int numSamples
        {
            get { return _numSamples; }
            set { SetProperty(ref _numSamples, value); }
        }

        private DelegateCommand _previousCommand;
        public DelegateCommand previousCommand =>
            _previousCommand ?? (_previousCommand = new DelegateCommand(delegate
            {
                if (currentSampleIndex > 0)
                {
                    currentSampleIndex -= 1;
                    results = allResults[currentSampleIndex];
                    selectedEquipmentID = selectedEquipment[currentSampleIndex];
                    transformerPotential = transformerPotentials[currentSampleIndex];
                }
            }, () => currentSampleIndex > 0)).ObservesProperty(()=>currentSampleIndex);


        private DelegateCommand _nextCommand;
        public DelegateCommand nextCommand =>
            _nextCommand ?? (_nextCommand = new DelegateCommand(delegate ()
            {
                if (currentSampleIndex == allResults.Count - 1)
                {
                    allResults.Add(new ObservableCollection<ResultWrapper>());
                    foreach (var expirment in expirments)
                    {
                        allResults[currentSampleIndex+1].Add(new ResultWrapper(0.0));
                    }
                    numSamples += 1;
                    selectedEquipment.Add(1);
                    transformerPotentials.Add(string.Empty);
                }
                currentSampleIndex += 1;
                results = allResults[currentSampleIndex];
                transformerPotential = transformerPotentials[currentSampleIndex];
                selectedEquipmentID = selectedEquipment[currentSampleIndex];
                

            }, ()=>true));

        private string _transformerPotential;
        public string transformerPotential
        {
            get { return _transformerPotential; }
            set
            {
                SetProperty(ref _transformerPotential, value);
                transformerPotentials[currentSampleIndex] = transformerPotential;
            }
        }

        private IList<Oil> _equipment = Oil.getEquipment();
        public IList<Oil> equipment
        {
            get { return _equipment; }
            set { SetProperty(ref _equipment, value); }
        }
        private int _selectedEquipmentID = 1;
        public int selectedEquipmentID
        {
            get { return _selectedEquipmentID; }
            set
            {
                SetProperty(ref _selectedEquipmentID, value);
                selectedEquipment[currentSampleIndex] = selectedEquipmentID;
            }
        }
        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
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
            //TODO merge the record with all results
            //TODO code to Save in DB
        }
    }
}
