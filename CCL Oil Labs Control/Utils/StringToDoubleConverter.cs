using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;
namespace CCL_Oil_Labs_Control.Utils
{
    public class StringToDoubleConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((Double)value == 0)
                return string.Empty;
            else return (value).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrWhiteSpace(value as string))
                return 0;
            else
            {
                Double returnedValue;
                Double.TryParse(value as String, out returnedValue);
                return returnedValue;
            }
        }
        private static StringToDoubleConverter _converter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null)
            {
                _converter = new StringToDoubleConverter();
            }

            return _converter;
        }
    }
}
