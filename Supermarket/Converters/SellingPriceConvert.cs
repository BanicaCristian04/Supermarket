using Supermarket.Models.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Supermarket.Converters
{
    public class SellingPriceConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           //if(value !=null)
           // {
           //     decimal commercialAddition = ConfigManager.GetCommercialAddition();
           //     if(decimal.TryParse(value.ToString(),out decimal purchasePrice))
           //     {
           //         return purchasePrice * (1 + commercialAddition);
           //     }
           // }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
