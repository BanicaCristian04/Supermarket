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
    public class ProductVM : BasePropertyChanged
    {
        ProductBLL productBLL = new ProductBLL();
        CategoryBLL categoryBLL = new CategoryBLL();
        ProducerBLL producerBLL = new ProducerBLL();

        public ObservableCollection<Product> ProductsList
        {
            get => productBLL.ProductsList;
            set => productBLL.ProductsList = value;
        }
        public ObservableCollection<Category> CategoryList
        {
            get => categoryBLL.CategoryList;
            set  {categoryBLL.CategoryList = value; NotifyPropertyChanged("CategoryList");}
        }

        public ObservableCollection<Producer> ProducerList
        {
            get => producerBLL.ProducerList;
            set => producerBLL.ProducerList = value;
        }
       

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                    addCommand = new RelayCommand<Product>(productBLL.AddProduct);
                return addCommand;
            }
        }
        public ProductVM()
        {
            ProductsList = productBLL.GetAllProducts();
            CategoryList= categoryBLL.GetAllCategories();
            ProducerList = producerBLL.GetAllProducers();
        }
    }
}
