using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.DataAccessLayer;
using Supermarket.Models.EntityLayer;
using Supermarket.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    public class UserTotalAmountVM:BasePropertyChanged
    {


        UserBLL userBLL=new UserBLL();

        public ObservableCollection<User> CashierList
        {
            get => userBLL.UsersList;
            set => userBLL.UsersList = value;
        }
        private ObservableCollection<DailyTransaction> dailyTransactions;

        public ObservableCollection<DailyTransaction> DailyTransactions
        {
            get { return dailyTransactions; }
            set
            {
                dailyTransactions = value;
                NotifyPropertyChanged("DailyTransactions");
            }
        }
        private ICommand totalAmountPerDayCommand;
        public ICommand TotalAmountPerDayCommand
        {
            get
            {
                if (totalAmountPerDayCommand == null)
                    totalAmountPerDayCommand = new RelayCommand<UserDate>(TotalAmountPerDay, TotalAmountPerDayTry);
                return totalAmountPerDayCommand;
            }
        }

        private bool TotalAmountPerDayTry(UserDate parameter)
        {
            return parameter.Cashier != null ;


        }

        private void TotalAmountPerDay(UserDate parameter)
        {
            if(parameter.Date!=null && parameter.Cashier!=null)
                 DailyTransactions= userBLL.GetTotalAmountPerDayUser(parameter.Cashier.UserID, parameter.Date); 

        }

        public UserTotalAmountVM()
        {
            CashierList = new ObservableCollection<User>();
            CashierList = userBLL.GetAllCashiers();
        }

    }
}
