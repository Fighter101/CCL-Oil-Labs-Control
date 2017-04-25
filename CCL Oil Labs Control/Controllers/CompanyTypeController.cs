using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL_Oil_Labs_Control.Model
{
    public partial class CompanyType
    {
        public static IList<CompanyType> getCompanyTypes()
        {
            List<CompanyType> companyTypes;
            using (var model = new DatabaseEntities())
            {
                companyTypes = (from company in model.CompanyTypes
                                select company).ToList();
            }
            return companyTypes;
        }

    }
}
