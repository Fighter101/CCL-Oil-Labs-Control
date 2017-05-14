using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL_Oil_Labs_Control.Model
{
    public partial class OilAnalysisType
    {
        public static IList<OilAnalysisType> getAnalysis()
        {
            var analysisList = new List<OilAnalysisType>();
            using (var model = DatabaseEntities.Initiate())
            {
                analysisList = (from analysis in model.OilAnalysisTypes
                                select analysis).ToList();
            }
            return analysisList;
        }
    }
}
