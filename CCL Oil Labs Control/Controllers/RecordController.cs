using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        public static ObservableCollection<Record> getRecords()
        {
            DatabaseEntities.clearEntity<Record>();
            var model = DatabaseEntities.Initiate();
            (from record in model.Records select record).Load();
            return model.Records.Local;
        }

        public void sync()
        {
            DatabaseEntities.clearEntity<Record>();
            var model = DatabaseEntities.Initiate();
            (from record in model.Records
             where record.ImportNo == this.ImportNo ||
             record.ImportDate == this.ImportDate
             select record).Load();
            ObservableCollection<Record> collection = model.Records.Local;
            if (collection.Count > 0)
            {
                if (!collection[0].Equals(this))
                    MessageBox.Show("Can't Change Sample Data once entered");
               
            }
            else collection.Add(this);
            model.SaveChanges();
        }

        public override bool Equals(object obj)
        {
            return this.ID == (obj as Record).ID;
        }
    }
}
