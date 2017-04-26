using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
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
        public static IList<CompanyType> getCompanyTypes(int companyType)
        {
            List<CompanyType> companyTypes;
            using (var model = new DatabaseEntities())
            {
                companyTypes = (from company in model.CompanyTypes
                                where company.ID == companyType
                                select company).ToList();
            }
            return companyTypes;
        }

        public static IList<CompanyType> getCompanyTypes(string companyTypeName)
        {
            List<CompanyType> companyTypes;
            using (var model = new DatabaseEntities())
            {
                companyTypes = (from company in model.CompanyTypes
                                where company.TypeName == companyTypeName
                                select company).ToList();
            }
            return companyTypes;
        }


    }
}
