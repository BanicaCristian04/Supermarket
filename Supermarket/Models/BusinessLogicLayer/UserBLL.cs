using Supermarket.Models.DataAccessLayer;
using Supermarket.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.BusinessLogicLayer
{
    public class UserBLL
    {
        public ObservableCollection<User> UsersList {  get; set; }

        private UserDAL userDAL;

        public UserBLL()
        {
            userDAL= new UserDAL();
        }
        public ObservableCollection<User> GetAllUsers()
        { 
            return userDAL.GetAllUsers();
        }
        public void AddUser(User user)
        {
            userDAL.AddUser(user);
            UsersList.Add(user);
        }
        public void UpdateUser(User user)
        {
            userDAL.UpdateUser(user);

        }
        public void DeleteUser(User user)
        {
            userDAL.DeleteUser(user);
            UsersList.Remove(user);
        }

        public User AuthenticateUser(User user)
        {
            return userDAL.AuthenticateUser(user);
        }

        public ObservableCollection<User> GetAllCashiers() 
        {
            return userDAL.GetAllCashiers();
        
        }
        public ObservableCollection<DailyTransaction> GetTotalAmountPerDayUser(int? cashierID,DateTime? date)
        {
            return userDAL.GetTotalAmountPerDayUser(cashierID, date);
        }

    }
}
