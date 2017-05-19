using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.ObjectModel;

namespace CCL_Oil_Labs_Control.Model
{
    public partial class Company
    {

        public static ObservableCollection<Company> getCompanies()
        {
            var model = DatabaseEntities.Initiate();
            ((from company in model.Companies select company)).Load();
            return model.Companies.Local;
        }

        public static ObservableCollection<Company> getCompanies(int companyType)
        {
            DatabaseEntities.clearEntity<Company>();
            var model = DatabaseEntities.Initiate();
            (from company in model.Companies where company.Type == companyType select company).Load();
            return model.Companies.Local;
        }
        public static ObservableCollection<Company> getCompaniesByID(int companyID)
        {
            var model = DatabaseEntities.Initiate();
            (from company in model.Companies
                             where company.ID == companyID
                             select company).Load();
            return model.Companies.Local;
        }
        public static ObservableCollection<Company> getCompanies(String companyName)
        {
            var model = DatabaseEntities.Initiate();
                (from company in model.Companies
                 where company.Name == companyName
                 select company).Load();
            return model.Companies.Local;
        }

    }
}
