using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL_Oil_Labs_Control.Model
{
    public partial class AnalysisType
    {

        public static IList<AnalysisType> getAnalysisTypes()
        {
            var analysisTypesList = new List<AnalysisType>();
            using (var model = new DatabaseEntities())
            {
                analysisTypesList = (from analysisType in model.AnalysisTypes
                                     select analysisType).ToList();
            }
            return analysisTypesList;
        }
    }
}
