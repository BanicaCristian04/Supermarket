using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Supermarket.Converters
{
    public class ValidationQuantity : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int result;
            if (int.TryParse((value ?? "").ToString(), out result))
            {
                return ValidationResult.ValidResult;
            }
            else
            {
                return new ValidationResult(false, "Vă rugăm să introduceți un număr întreg.");
            }
        }
    }
}
