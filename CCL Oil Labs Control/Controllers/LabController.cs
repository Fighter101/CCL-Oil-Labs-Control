using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL_Oil_Labs_Control.Model
{
    public partial class Lab
    {
        public static IList<Lab> getLabs()
        {
            var labsList = new List<Lab>();
            using (var model = new DatabaseEntities())
            {
                labsList = (from lab in model.Labs
                            select lab).ToList();
            }
            return labsList;
        }
    }
}
