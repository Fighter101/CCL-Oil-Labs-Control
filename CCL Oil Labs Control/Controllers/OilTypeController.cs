using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL_Oil_Labs_Control.Model
{
    public partial class OilType
    {

        public static ObservableCollection<OilType> getOilTypes()
        {
            DatabaseEntities.clearEntity<OilType>();
            var model = DatabaseEntities.Initiate();
            (from oilType in model.OilTypes select oilType).Load();
            return model.OilTypes.Local;
        }
    }
}
