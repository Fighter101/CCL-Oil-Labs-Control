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
        public static ObservableCollection<CompanyType> getCompanyTypes()
        {
            var model = DatabaseEntities.Initiate();
                (from company in model.CompanyTypes select company).Load();
                return model.CompanyTypes.Local;
           
        }
        public static IList<CompanyType> getCompanyTypes(int companyType)
        {
            var model = DatabaseEntities.Initiate();
            (from company in model.CompanyTypes where company.ID == companyType select company).Load();
            return model.CompanyTypes.Local;
        }

        public static IList<CompanyType> getCompanyTypes(string companyTypeName)
        {
            var model = DatabaseEntities.Initiate();
            (from company in model.CompanyTypes where company.TypeName == companyTypeName select company).Load();
            return model.CompanyTypes.Local;
        }


    }
}
