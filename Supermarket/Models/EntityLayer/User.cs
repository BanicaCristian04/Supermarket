using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.EntityLayer
{
    public class User:BasePropertyChanged
    {
        private int? userID;
        public int? UserID
        {
            get { return userID; }
            set 
            { userID = value;
                NotifyPropertyChanged("UserID");
            }
        }
        private string username;
        public string Username
        {
            get { return username; }
            set { username=value;
                NotifyPropertyChanged("Username");
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password=value;
            NotifyPropertyChanged("Password");}
        }
        private UserTypeEnum userType;
        public UserTypeEnum UserType
        {
            get { return userType;}
            set { userType = value;
                NotifyPropertyChanged("UserType");
            }
        }
    }
}
