using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL_Oil_Labs_Control.Model
{
    public partial class Transformer
    {

        public static ObservableCollection<Transformer> getResults(int id)
        {
            DatabaseEntities.clearEntity<Transformer>();
            var model = DatabaseEntities.Initiate();
            (from result in model.Transformers where result.PaperID == id select result).Load();
            return model.Transformers.Local;
        }

        public static ObservableCollection<Transformer> getResults()
        {
            DatabaseEntities.clearEntity<Transformer>();
            var model = DatabaseEntities.Initiate();
            (from result in model.Transformers select result).Load();
            return model.Transformers.Local;
        }
    }
}
