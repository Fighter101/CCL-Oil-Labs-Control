using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL_Oil_Labs_Control.Model
{
    public partial class Record
    {
        public Record exists()
        {
            var model = DatabaseEntities.Initiate();
            return (from record in model.Records
                    where record.ImportNo == this.ImportNo ||
                    record.ImportDate == this.ImportDate
                    select record).ToList().FirstOrDefault();

        }
    }
}
