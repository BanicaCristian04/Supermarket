using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels
{
    public class CategoryProductsTotalAmount
    {
        StockBLL stockBLL= new StockBLL();
        ProductBLL productBLL=new ProductBLL();
        private ObservableCollection<CategoryTotalAmount> categoriesTotalAmount;

        public ObservableCollection<CategoryTotalAmount>CategoriesTotalAmount
        {
            get { return categoriesTotalAmount; }
            set
            {
                categoriesTotalAmount = value;
            }
        }

        public ObservableCollection<Stock> StocksList
        {
            get => stockBLL.StocksList;
            set => stockBLL.StocksList = value;
        }
        public CategoryProductsTotalAmount()
        {
            StocksList=stockBLL.GetAllStocks();
            foreach (Stock stock in StocksList)
            {
                Product product = new Product();
                product=productBLL.GetProductByID(stock.Product.ProductID);
                stock.Product=product;
            }
            CategoriesTotalAmount = new ObservableCollection<CategoryTotalAmount>();
                foreach (Stock stock in StocksList)
                {
                    bool found = false;
                    foreach (CategoryTotalAmount categoryTotalAmount in CategoriesTotalAmount)
                    {
                       
                        if (categoryTotalAmount.Category.CategoryID==stock.Product.Category.CategoryID)
                        {
                            categoryTotalAmount.TotalAmount += stock.SellingPrice;
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        CategoryTotalAmount categoryTotalAmount = new CategoryTotalAmount(stock.Product.Category,stock.SellingPrice);
                        CategoriesTotalAmount.Add(categoryTotalAmount);
                    }
                }


        }


    }
}
