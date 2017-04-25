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
            using (var model = new DatabaseEntities())
            {
                companiesList = (from company in model.Companies
                                 select company).ToList();
            }
            return companiesList;
        }
    }
}
