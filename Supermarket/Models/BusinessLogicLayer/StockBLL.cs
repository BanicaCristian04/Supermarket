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
    public class StockBLL
    {

        public ObservableCollection<Product> ProductsList { get; set; }
        public ObservableCollection<Stock> StocksList { get; set; }




        StockDAL stockDAL;

        public StockBLL()
        {
            stockDAL=new StockDAL();
        }
        public ObservableCollection<Stock> GetAllStocks()
        {
            return stockDAL.GetAllStocks();
        }
        public void UpdateStockQuantity(int stockID, int quantity)
        {
            stockDAL.UpdateStockQuantity(stockID,quantity);
        }

    }
}
