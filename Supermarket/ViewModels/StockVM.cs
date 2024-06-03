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
    public class StockVM:BasePropertyChanged
    {

        ProductBLL productBLL = new ProductBLL();
        StockBLL stockBLL=new StockBLL();
        private bool isUpdatable;
        public bool IsUpdatable
        {
            get { return isUpdatable; }
            set
            {
                isUpdatable = value;
                NotifyPropertyChanged("isUpdatable");
            }
        }
        private ICommand toggleIsUpdatableCommand;
        public ICommand ToggleIsUpdatableCommand { get 
            {
                if (toggleIsUpdatableCommand == null)
                    toggleIsUpdatableCommand = new RelayCommand<Stock>(ToggleIsUpdatable);
                return toggleIsUpdatableCommand;
            } }

        private void ToggleIsUpdatable(Stock obj)
        {
            IsUpdatable =   !IsUpdatable;
        }

        public ObservableCollection<Product> ProductsList
        {
            get => productBLL.ProductsList;
            set => productBLL.ProductsList = value;
        }
        public ObservableCollection<Stock> StocksList
        {
            get => stockBLL.StocksList;
            set=> stockBLL.StocksList = value;
        }
        public StockVM()
        {
            isUpdatable = true;
            StocksList = stockBLL.GetAllStocks();
            foreach(var stock in StocksList)
            {
                stock.Product = productBLL.GetProductByID(stock.Product.ProductID);
            }
            ProductsList = productBLL.GetAllProducts();

        }
       
    }
}
