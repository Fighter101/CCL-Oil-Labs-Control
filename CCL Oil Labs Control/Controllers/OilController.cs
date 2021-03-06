﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL_Oil_Labs_Control.Model

{
    public partial class Oil
    {
        public static ObservableCollection<Oil> getEquipment()
        {
            DatabaseEntities.clearEntity<Oil>();
            var model = DatabaseEntities.Initiate();
            (from equipment in model.Oils select equipment).Load();
            return model.Oils.Local;
        }
        public static Oil getEquipment(int id)
        {
            var model = DatabaseEntities.Initiate();
            (from equipment in model.Oils where equipment.ID == id select equipment).Load();
            return model.Oils.Local.Single(equipment => equipment.ID == id);
        }
    }
}
