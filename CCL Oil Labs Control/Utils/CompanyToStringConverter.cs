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
    class CompanyToStringConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int company = (int)value;
            return Company.getCompaniesByID(company).FirstOrDefault().Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string companyName = value.ToString();
            return Company.getCompanies(companyName).FirstOrDefault().ID;
        }
        private static CompanyToStringConverter converter;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return converter == null ? converter = new CompanyToStringConverter() : converter;
        }
    }
}
