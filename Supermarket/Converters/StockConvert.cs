﻿using Supermarket.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Supermarket.Converters
{
    public class StockConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] != null && values[1] != null && values[2] != null && values[3] != null)
            {

                //return new Stock()
                //{
                //    Product =(Product)values[0],
                //    Quantity = (int)values[1],
                //    UnitOfMeasure = values[2].ToString(),
                //    SupplyDate = values[3]
                //    Name = values[0].ToString(),
                //    Barcode = values[1].ToString(),
                //    Category = (Category)values[2],
                //    Producer = (Producer)values[3]
                //};
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
