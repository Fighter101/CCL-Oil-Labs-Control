using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCL_Oil_Labs_Control.CompositeCommands;
using Prism.Mvvm;
using CCL_Oil_Labs_Control.Model;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Regions;
using CCL_Oil_Labs_Control.Utils;
using System.Windows.Controls;
using System.Windows;
namespace CCL_Oil_Labs_Control.ViewModels
{
    public class CodesRegEquipNamesMenuViewModel : BindableBase,IConfirmNavigationRequest
    {

        public CodesRegEquipNamesMenuViewModel(GlobalNavigateCommand globalNavigateCommand)
        {
            this.globalNavigateCommand = globalNavigateCommand;
        }

        private GlobalNavigateCommand _globalNavigateCommand;
        public GlobalNavigateCommand globalNavigateCommand
        {
            get { return _globalNavigateCommand; }
            set { SetProperty(ref _globalNavigateCommand, value); }
        }

        private ObservableCollection<Oil> _equipments;
        public ObservableCollection<Oil> equipments
        {
            get { return _equipments; }
            set { SetProperty(ref _equipments, value); }
        }

        private IList<OilType> _oilTypes;
        public IList<OilType> oilTypes
        {
            get { return _oilTypes; }
            set { SetProperty(ref _oilTypes, value); }
        }

        private bool _canNavigateBack;
        public bool canNavigateBack
        {
            get { return _canNavigateBack; }
            set { SetProperty(ref _canNavigateBack, value); }
        }

        private int _currentSelectedRow;
        public int currentSelectedRow
        {
            get { return _currentSelectedRow; }
            set
            {
                canNavigateBack = !Utils.Utils.isThereEmpty<Oil>(equipments, equipment => string.IsNullOrWhiteSpace(equipment.Name));
                SetProperty(ref _currentSelectedRow, value);
            }
        }

        private DelegateCommand<object> _comboBoxSelectionChangedCommand;
        public DelegateCommand<object> comboBoxSelectionChangedCommand =>
            _comboBoxSelectionChangedCommand ?? (_comboBoxSelectionChangedCommand = new DelegateCommand<object>(
                delegate(object o)
                {
                    if (currentSelectedRow >= 0)
                        equipments.ElementAt(currentSelectedRow).OilType = (o as OilType);
                }, 
                o=>currentSelectedRow >= 0)).ObservesProperty(() => currentSelectedRow);

        private DelegateCommand _deleteCommand;
        public DelegateCommand deleteCommand =>
            _deleteCommand ?? (_deleteCommand = new DelegateCommand(() => equipments.RemoveAt(currentSelectedRow), () => currentSelectedRow >= 0)).ObservesProperty(()=>currentSelectedRow);

        private DelegateCommand<object> _cellSelectionChangedCommand;
        public DelegateCommand<object> cellSelectionChangedCommand =>
            _cellSelectionChangedCommand ?? (_cellSelectionChangedCommand = new DelegateCommand<object>(
                delegate (object removedCells)
                {
                    if (removedCells != null && (removedCells as IList<DataGridCellInfo>).Count > 0 && ((removedCells as IList<DataGridCellInfo>).FirstOrDefault().Item) is Oil)
                    {
                        if (string.IsNullOrWhiteSpace((((removedCells as IList<DataGridCellInfo>).FirstOrDefault().Item) as Oil).Name))
                        {
                            MessageBox.Show("لا يمكن ترك خانة فارغة");
                        }
                    }
                }
                , e => true));

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            continuationCallback(!Utils.Utils.isThereEmpty<Oil>(equipments, equipment => string.IsNullOrWhiteSpace(equipment.Name)));
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            equipments = new ObservableCollection<Oil>(Oil.getEquipment()); ;
            oilTypes = OilType.getOilTypes();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //TODO code to Save in DB
        }

    }
}
