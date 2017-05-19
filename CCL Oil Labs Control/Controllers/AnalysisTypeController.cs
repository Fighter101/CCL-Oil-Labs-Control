using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL_Oil_Labs_Control.Model
{
    public partial class AnalysisType
    {

        public static ObservableCollection<AnalysisType> getAnalysisTypes()
        {
            DatabaseEntities.clearEntity<AnalysisType>();
            var model = DatabaseEntities.Initiate();
            (from analysisType in model.AnalysisTypes select analysisType).Load();
            return model.AnalysisTypes.Local;
        }
    }
}
