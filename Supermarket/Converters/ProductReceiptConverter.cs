using Supermarket.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Navigation;

namespace Supermarket.Converters
{
    public class ProductReceiptConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if(values!=null && values.Length==2 && values[0] is Supermarket.Models.EntityLayer.Stock stock && values[1] is string quantityStr && !string.IsNullOrEmpty(quantityStr) && int.TryParse(quantityStr, out int quantity))
            {
                decimal subtotal = stock.SellingPrice * quantity;
                ProductReceipt productReceipt= new ProductReceipt
                {
                    Product = stock.Product,
                    Quantity = quantity,
                    Subtotal = subtotal,
                };
                return new Tuple<ProductReceipt,int>(productReceipt,stock.StockID);
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
