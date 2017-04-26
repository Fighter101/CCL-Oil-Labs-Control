using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;
using CCL_Oil_Labs_Control.Model;
namespace CCL_Oil_Labs_Control.Utils
{
    class CompanyTypeToStringConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int companyType = (int)value;
            return CompanyType.getCompanyTypes(companyType).FirstOrDefault().TypeName;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string typeName = value.ToString();
            return CompanyType.getCompanyTypes(typeName).FirstOrDefault().ID;
        }
        private static CompanyTypeToStringConverter converter;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return converter == null ? converter = new CompanyTypeToStringConverter() : converter;
        }
    }
}
