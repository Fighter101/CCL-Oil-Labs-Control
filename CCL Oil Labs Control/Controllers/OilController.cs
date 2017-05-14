using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL_Oil_Labs_Control.Model

{
    public partial class Oil
    {
        public static IList<Oil> getEquipment()
        {
            List<Oil> equipmentList;
            using (var model = DatabaseEntities.Initiate())
            {
                equipmentList = (from equipment in model.Oils
                                 select equipment).ToList();
            }
            return equipmentList;
        }
    }
}
