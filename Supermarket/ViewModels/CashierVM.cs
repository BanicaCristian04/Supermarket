using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.EntityLayer;
using Supermarket.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    public class CashierVM:BasePropertyChanged
    {

        private ObservableCollection<Product> searchResults;
        private ObservableCollection<Stock> filteredStocks;
        private ObservableCollection<Tuple<int,ProductReceipt>> currentReceiptItems;
        public User user;
        private User User { 
            get { return user; }
            set { user = value;
                NotifyPropertyChanged("User");
            } 
        }
        public ObservableCollection<Tuple<int,ProductReceipt>> CurrentReceiptItems
        {
            get { return currentReceiptItems;}
            set { currentReceiptItems = value; NotifyPropertyChanged("CurrentReceiptItems"); }
        }

        private decimal totalAmount;
        public decimal TotalAmount
        {
            get { return totalAmount; }
            set
            {
                totalAmount = value;
                NotifyPropertyChanged("TotalAmount");
            }
        }
        
        public ObservableCollection<Stock> FilteredStocks
        {
            get { return filteredStocks; }
            set { filteredStocks = value; NotifyPropertyChanged("FilteredStocks"); }
        }
        private Stock newStock;
        public Stock NewStock
        {
            get => newStock;
            set
            {
                newStock = value;
                NotifyPropertyChanged("NewStock");
            }
        }
        private ICommand filterStocksCommand;
        public ICommand FilterStocksCommand
        {
            get
            {
                if (filterStocksCommand == null)
                    filterStocksCommand = new RelayCommand<Stock>(FilterStocks);
                return filterStocksCommand;
            }
        }
        private ICommand addProductToReceiptCommand;
        public ICommand AddProductToReceiptCommand
        {
            get
            {
                if(addProductToReceiptCommand == null)
                    addProductToReceiptCommand = new RelayCommand<Tuple<ProductReceipt,int>>(AddProductToReceipt);
                return addProductToReceiptCommand;

            }
        }
        private ICommand addReceiptCommand;
        public ICommand AddReceiptCommand
        {
            get
            {
                if (addReceiptCommand == null)
                    addReceiptCommand = new RelayCommand<Receipt>(AddReceipt, CanAddReceipt);
                return addReceiptCommand;
            }
        }

        private bool CanAddReceipt(Receipt receipt)
        {
            return currentReceiptItems.Count > 0;
        }

        private void AddReceipt(Receipt receipt)
        {

            receipt.UserID = (int)User.UserID;
            receipt.TotalAmount = TotalAmount;
            receiptBLL.AddReceipt(receipt);
            foreach (Tuple<int, ProductReceipt> productReceipt in CurrentReceiptItems)
            {
                productReceipt.Item2.Receipt = receipt;
                productReceiptBLL.AddProductReceipt(productReceipt.Item2);
                stockBLL.UpdateStockQuantity(productReceipt.Item1, productReceipt.Item2.Quantity);
            }

            CurrentReceiptItems.Clear();
            TotalAmount = 0;

        }


        private void AddProductToReceipt(Tuple<ProductReceipt,int> productReceipt)
        {
            if(productReceipt != null)
            {
                var stockItem = StocksList.FirstOrDefault(s => s.StockID == productReceipt.Item2);
                if (stockItem.Quantity >= productReceipt.Item1.Quantity)
                {
                    currentReceiptItems.Add(new Tuple<int,ProductReceipt>(productReceipt.Item2,productReceipt.Item1));
                    TotalAmount = TotalAmount + productReceipt.Item1.Subtotal;

                    stockItem.Quantity -= productReceipt.Item1.Quantity;
                    if(stockItem.Quantity==0)
                        FilteredStocks.Remove(stockItem);
                }
                else
                {
                    MessageBox.Show("Cantitatea disponibila in stoc nu este suficienta.", "Avertizare", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            }
            else
                MessageBox.Show("Produsul nu a putut fi adaugat pe bon. Verificati datele!", "Avertizare", MessageBoxButton.OK, MessageBoxImage.Warning);



        }

        private void FilterStocks(Stock newStock)
        {
            FilteredStocks.Clear();
            var filteredStocks = StocksList.Where(stock =>
        (newStock.Product == null || newStock.Product.Name == null || stock.Product.Name.Contains(newStock.Product.Name)) &&
        (newStock.Product == null || newStock.Product.Barcode == null || stock.Product.Barcode.Contains(newStock.Product.Barcode)) &&
        (!newStock.ExpirationDate.HasValue || newStock.ExpirationDate == null || stock.ExpirationDate == newStock.ExpirationDate) &&
        (newStock.Product == null || newStock.Product.Producer == null || stock.Product.Producer.Name.Contains(newStock.Product.Producer.Name)) &&
        (newStock.Product == null || newStock.Product.Category == null || stock.Product.Category.Name.Contains(newStock.Product.Category.Name))
    ).ToList();

            FilteredStocks = new ObservableCollection<Stock>(filteredStocks);
        }

        CategoryBLL categoryBLL = new CategoryBLL();
        ProducerBLL producerBLL=new ProducerBLL();
        ProductBLL productBLL=new ProductBLL();
        StockBLL stockBLL = new StockBLL();
        ReceiptBLL receiptBLL = new ReceiptBLL();
        ProductReceiptBLL productReceiptBLL = new ProductReceiptBLL();
        public ObservableCollection<Stock> StocksList
        {
            get => stockBLL.StocksList;
            set => stockBLL.StocksList = value;
        }
        public ObservableCollection<Category> CategoryList
        {
            get => categoryBLL.CategoryList;
            set { categoryBLL.CategoryList = value; NotifyPropertyChanged("CategoryList"); }
        }

        public ObservableCollection<Producer> ProducerList
        {
            get => producerBLL.ProducerList;
            set => producerBLL.ProducerList = value;
        }
        public ObservableCollection<Product> ProductsList
        {
            get => productBLL.ProductsList;
            set => productBLL.ProductsList = value;
        }

        public CashierVM(User user)
        {
            User = user;
            currentReceiptItems = new ObservableCollection<Tuple<int,ProductReceipt>>();
            StocksList = stockBLL.GetAllStocks();
            FilteredStocks=new ObservableCollection<Stock>(StocksList);
            newStock = new Stock();
            foreach (var stock in StocksList)
            {
                stock.Product = productBLL.GetProductByID(stock.Product.ProductID);
            }
            CategoryList = categoryBLL.GetAllCategories();
            ProducerList = producerBLL.GetAllProducers();
            ProductsList= productBLL.GetAllProducts();
           
        }
       
    }
}
