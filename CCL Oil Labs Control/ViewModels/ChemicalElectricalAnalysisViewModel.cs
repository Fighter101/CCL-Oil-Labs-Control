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
using System.Diagnostics;

namespace CCL_Oil_Labs_Control.ViewModels
{
    class ChemicalElectricalAnalysisViewModel : BindableBase, IConfirmNavigationRequest
    {

        private ChemElecAnlSetter chemElecAnlSetter;
        public ChemicalElectricalAnalysisViewModel(GlobalNavigateCommand globalNavigateCommand ,IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.eventAggregator.GetEvent<RecordedEvent>().Subscribe(delegate (Record record)
            {
                currentRecord = record;
            }
            ,ThreadOption.PublisherThread,true);
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

            selectedEquipment.Add(1);
            transformerPotentials = new List<string>();
            transformerPotentials.Add(string.Empty);
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

        private IList<int> _selectedEquipment = new List<int>();
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
        private Oil _selectedEquipmentItem;
        public Oil selectedEquipmentItem
        {
            get { return _selectedEquipmentItem; }
            set { SetProperty(ref _selectedEquipmentItem, value); }
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
                selectedEquipmentItem = Oil.getEquipment(selectedEquipmentID);
                
                

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
        private ObservableCollection<Transformer> _storedResults;
        public ObservableCollection<Transformer> storedResutls
        {
            get { return _storedResults; }
            set { SetProperty(ref _storedResults, value); }
        }

        private DelegateCommand _dataGridLoadedCommand;
        public DelegateCommand dataGridLoadedCommand =>
            _dataGridLoadedCommand ?? (_dataGridLoadedCommand = new DelegateCommand(delegate { getOldResults(); }, ()=>true));
        public void OnNavigatedTo(NavigationContext navigationContext)
        {


        }
        private void getOldResults()
        {
            storedResutls = Transformer.getResults(currentRecord.ID);
            var counter = 0;
            foreach (var result in storedResutls)
            {
                if (counter == allResults.Count)
                {
                    var tmpCollection = new ObservableCollection<ResultWrapper>();
                    allResults.Add(new ObservableCollection<ResultWrapper>());
                }

                syncResults(result, allResults[counter++]);
                selectedEquipment.Add((int)result.Oil);
                transformerPotentials.Add(String.Empty);
            }
       
            numSamples = storedResutls.Count();
            if (numSamples > 0)
            {
                selectedEquipmentID = (int)storedResutls[0].Oil;
                selectedEquipmentItem = Oil.getEquipment(selectedEquipmentID);
            }
        }
        private void syncResults(Transformer oldResult, ObservableCollection<ResultWrapper> newResult)
        {
            if (newResult.Count > 0)
            {
                newResult[0] = new ResultWrapper((double)oldResult.SG);
                newResult[1] = new ResultWrapper((double)oldResult.COL);
                newResult[2] = new ResultWrapper((double)oldResult.IMP);

                newResult[3] = new ResultWrapper((double)oldResult.WA);
                newResult[4] = new ResultWrapper((double)oldResult.IPI);
                newResult[5] = new ResultWrapper((double)oldResult.KV);
                newResult[6] = new ResultWrapper((double)oldResult.PF);
                newResult[7] = new ResultWrapper((double)oldResult.ST);
                newResult[8] = new ResultWrapper((double)oldResult.KI);
                newResult[9] = new ResultWrapper((double)oldResult.FL);
                newResult[10] = new ResultWrapper((double)oldResult.CO);
            }
            else
            {
                newResult.Add(new ResultWrapper((double)oldResult.SG));
                newResult.Add(new ResultWrapper((double)oldResult.COL));
                newResult.Add(new ResultWrapper((double)oldResult.IMP));
                newResult.Add(new ResultWrapper((double)oldResult.IPI));
                newResult.Add(new ResultWrapper((double)oldResult.WA));
                newResult.Add(new ResultWrapper((double)oldResult.KV));
                newResult.Add(new ResultWrapper((double)oldResult.PF));
                newResult.Add(new ResultWrapper((double)oldResult.ST));
                newResult.Add(new ResultWrapper((double)oldResult.KI));
                newResult.Add(new ResultWrapper((double)oldResult.FL));
                newResult.Add(new ResultWrapper((double)oldResult.CO));
            }


        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            var counter = 0;
            foreach (var newResult in allResults)
            {
                if(counter == storedResutls.Count())
                {
                    Transformer tempResult = new Transformer();
                    sycnResultsBack(tempResult, newResult);
                    tempResult.Oil = selectedEquipment[counter];
                    tempResult.PaperID = currentRecord.ID;
                    tempResult.KF = transformerPotentials[counter];
                    storedResutls.Add(tempResult);
                    counter++;
                }
                else
                {
                    sycnResultsBack(storedResutls[counter++], newResult);
                }
            }
            DatabaseEntities.Initiate().SaveChanges();
        }

        private void sycnResultsBack(Transformer oldResult , ObservableCollection<ResultWrapper> newResult)
        {
            oldResult.SG = newResult[0].result;
            oldResult.COL = newResult[1].result;
            oldResult.IMP = newResult[2].result;
            oldResult.WA = newResult[3].result;
            oldResult.IPI = newResult[4].result;
            oldResult.KV = newResult[5].result;
            oldResult.PF = newResult[6].result;
            oldResult.ST = newResult[7].result;
            oldResult.KI = newResult[8].result;
            oldResult.FL = newResult[9].result;
            oldResult.CO = newResult[10].result;
        }
    }
}
