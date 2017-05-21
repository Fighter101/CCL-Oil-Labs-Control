using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL_Oil_Labs_Control.Model
{
    public partial class Lab
    {
        public static IList<Lab> getLabs()
        {
            DatabaseEntities.clearEntity<Lab>();
            var model = DatabaseEntities.Initiate();
            (from lab in model.Labs select lab).Load();
            return DatabaseEntities.Initiate().Labs.Local;
        }
    }
}
