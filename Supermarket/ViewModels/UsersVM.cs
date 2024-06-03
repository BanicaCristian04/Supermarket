using Supermarket.Models.BusinessLogicLayer;
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
    public class UsersVM : BasePropertyChanged
    {
        UserBLL userBLL = new UserBLL();
        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                    addCommand = new RelayCommand<User>(userBLL.AddUser, CanAdd);
                return addCommand;
            }
        }

        private bool CanAdd(User obj)
        {
            return obj != null && !UsersList.Any(u=> u.Username==obj.Username && u.Password==obj.Password);
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                    updateCommand = new RelayCommand<User>(userBLL.UpdateUser);
                return updateCommand;
            }
        }

       

        private ICommand deleteCommand;
       
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                    deleteCommand = new RelayCommand<User>(userBLL.DeleteUser);
                return deleteCommand;
            }
        }

        private bool CanExecuteDeleteCommand(object user)
        {
            return user != null;
        }

        private bool CanExecuteAddCommand(User user)
        {
            return user != null;
        }
        private bool CanExecuteUpdateCommand(User user)
        {
            return user != null;
        }

        public UserTypeEnum[] UserTypes => Enum.GetValues(typeof(UserTypeEnum)) as UserTypeEnum[];

        public ObservableCollection<User> UsersList { get=>userBLL.UsersList;
            set=>userBLL.UsersList=value; }
        
        public UsersVM()
        {
            UsersList = userBLL.GetAllUsers();
        }

    }
}
