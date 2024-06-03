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
    public class ProducerVM : BasePropertyChanged
    {
        ProducerBLL producerBLL = new ProducerBLL();
        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                    addCommand = new RelayCommand<Producer>(producerBLL.AddProducer);
                return addCommand;
            }
        }
        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                    updateCommand = new RelayCommand<Producer>(producerBLL.UpdateProducer);
                return updateCommand;
            }
        }

        private ICommand deleteCommand;

        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                    deleteCommand = new RelayCommand<Producer>(producerBLL.DeleteProducer);
                return deleteCommand;
            }
        }

        //private bool CanExecuteDeleteCommand(object user)
        //{
        //    return user != null;
        //}

        //private bool CanExecuteAddCommand(User user)
        //{
        //    return user != null;
        //}
        //private bool CanExecuteUpdateCommand(User user)
        //{
        //    return user != null;
        //}

        public ObservableCollection<Producer> ProducersList
        {
            get => producerBLL.ProducerList;
            set => producerBLL.ProducerList = value;
        }

        public ProducerVM()
        {
            ProducersList = producerBLL.GetAllProducers();
        }

    }
}
