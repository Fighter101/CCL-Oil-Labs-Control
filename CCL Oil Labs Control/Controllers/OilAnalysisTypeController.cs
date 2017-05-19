using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL_Oil_Labs_Control.Model
{
    public partial class OilAnalysisType
    {
        public static ObservableCollection<OilAnalysisType> getAnalysis()
        {
            var model = DatabaseEntities.Initiate();
            ((from analysis in model.OilAnalysisTypes select analysis)).Load();
            return DatabaseEntities.Initiate().OilAnalysisTypes.Local;
        }
    }
}
