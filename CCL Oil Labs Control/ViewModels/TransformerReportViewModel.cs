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
    public class TransformerReportViewModel : BindableBase
    {
        private GlobalNavigateCommand _globalNavigateCommand;
        public GlobalNavigateCommand globalNavigateCommand
        {
            get { return _globalNavigateCommand; }
            set { SetProperty(ref _globalNavigateCommand, value); }
        }
        public TransformerReportViewModel(GlobalNavigateCommand globalNavigateCommand)
        {
            this.globalNavigateCommand = globalNavigateCommand;
        }

        private ObservableCollection<Transformer> _transformers = Transformer.getResults();
        public ObservableCollection<Transformer> transformers
        {
            get { return _transformers; }
            set { SetProperty(ref _transformers, value); }
        }
    }
}
