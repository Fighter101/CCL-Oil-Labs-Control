using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.Entity;

namespace CCL_Oil_Labs_Control.Model
{
    public partial class Analysis
    {
        public static IList<Analysis> getAnalysis()
        {
            var analysisList = new List<Analysis>();
            using (var model = DatabaseEntities.Initiate())
            {
                analysisList = (from analysis in model.Analyses
                                select analysis).ToList();
            }
            return analysisList;
        }
                

        
    }
}
