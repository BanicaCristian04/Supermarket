using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.DataAccessLayer;
using Supermarket.Models.EntityLayer;
using Supermarket.ViewModels.Commands;
using Supermarket.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Security;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
namespace Supermarket.ViewModels
{
    public class LoginVM : BasePropertyChanged
    {
        readonly UserBLL userBLL;

        private ICommand loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                    loginCommand = new RelayCommand<object>(ExecuteLoginCommand, CanExecuteLoginCommand);
                return loginCommand;
            }
        }
    
        public ICommand ShowPasswordCommand {  get; set; }
    
        public LoginVM()
        {
            userBLL = new UserBLL();
        }

        private void ExecuteLoginCommand(object t)
        {
            if(t is User user )
            {
                user=userBLL.AuthenticateUser(user);
                if (user != null)
                {
                    switch (user.UserType)
                    {
                        case UserTypeEnum.Administrator:
                            AdminWindow adminWindow = new AdminWindow();
                            adminWindow.Show();

                            Application.Current.MainWindow.Close();
                            break;
                        case UserTypeEnum.Cashier:
                            CashierWindow cashierWindow = new CashierWindow(user);
                            cashierWindow.Show();
                            Application.Current.MainWindow.Close();
                            break;

                    }
                }
                else
                {
                MessageBox.Show("Datele utilizatorului sunt gresite.Incercati inca o data", "Avertizare", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            }
        }
        private bool CanExecuteLoginCommand(object obj)
        {
            return obj is User user && user != null;            
        }
    }
}
