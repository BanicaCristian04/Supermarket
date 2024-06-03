using Supermarket.Models.EntityLayer;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Supermarket.Converters
{
    class UserConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values.Length > 2)
            {
                if (values[0] != null && values[1] != null && values[2] != null)
                {
                    return new User()
                    {
                        Username = values[0].ToString(),
                        Password = values[1].ToString(),
                        UserType = (UserTypeEnum)Enum.Parse(typeof(UserTypeEnum), values[2].ToString())
                    };
                }
                return null;
            }
            else
            {
                if (!string.IsNullOrEmpty(values[0].ToString()) && !string.IsNullOrEmpty(values[1].ToString()))
                {
                    return new User()
                    {
                        Username = values[0].ToString(),
                        Password = values[1].ToString()

                    };
                }

            }

            return null;


        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            //if (value is User user)
            //{
            //    return new object[] { user.Username, user.Password, user.UserType, user.UserID };
            //}
            //return null;
            throw new NotImplementedException();

        }
    }
}
