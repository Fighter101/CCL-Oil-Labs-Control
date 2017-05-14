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
            (from company in model.Companies select company).Load();
            return model.Companies.Local;
        }

        public static IList<Company> getCompanies(int companyType)
        {
            var model = DatabaseEntities.Initiate();
            (from company in model.Companies where company.Type == companyType select company).Load();
            return model.Companies.Local;
        }
        public static IList<Company> getCompaniesByID(int companyID)
        {
            List<Company> companiesList;
            using (var model = DatabaseEntities.Initiate())
            {
                companiesList = (from company in model.Companies
                                 where company.ID == companyID
                                 select company).ToList();
            }
            return companiesList;
        }
        public static IList<Company> getCompanies(String companyName)
        {
            List<Company> companiesList;
            using (var model = DatabaseEntities.Initiate())
            {
                companiesList = (from company in model.Companies
                                 where company.Name == companyName
                                 select company).ToList();
            }
            return companiesList;
        }

    }
}
