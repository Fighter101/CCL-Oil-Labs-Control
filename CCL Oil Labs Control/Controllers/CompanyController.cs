using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL_Oil_Labs_Control.Model
{
    public partial class Company
    {

        public static IList<Company> getCompanies()
        {
            List<Company> companiesList;
            using (var model = DatabaseEntities.Initiate())
            {
                companiesList = (from company in model.Companies
                                 select company).ToList();
            }
            return companiesList;
        }

        public static IList<Company> getCompanies(int companyType)
        {
            List<Company> companiesList;
            using (var model = DatabaseEntities.Initiate())
            {
                companiesList = (from company in model.Companies
                                 where company.Type == companyType
                                 select company).ToList();
            }
            return companiesList;
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
