using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL_Oil_Labs_Control.Model
{
    public partial class OilType
    {

        public static IList<OilType> getOilTypes()
        {
            List<OilType> oilTypes;
            using (var model = new DatabaseEntities())
            {
                oilTypes = (from oilType in model.OilTypes
                            select oilType).ToList();
            }
            return oilTypes;
        }
    }
}
