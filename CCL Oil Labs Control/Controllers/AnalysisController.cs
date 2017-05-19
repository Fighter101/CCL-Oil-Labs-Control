using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.Entity;
using System.Collections.ObjectModel;

namespace CCL_Oil_Labs_Control.Model
{
    public partial class Analysis
    {
        public static ObservableCollection<Analysis> getAnalysis()
        {
            var model = DatabaseEntities.Initiate();
            ((from analysis in model.Analyses select analysis)).Load();
            return model.Analyses.Local;
        }
                

        
    }
}
