using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Supermarket.Models.EntityLayer
{
    public class Stock:BasePropertyChanged
    {

        private int stockID;
        public int StockID
        {
            get
            {
                return stockID;
            }
            set
            {
                stockID = value;
                NotifyPropertyChanged("StockID");
            }
        }
        private int quantity;
        public int Quantity
        {
            get { return quantity;}
            set { quantity = value;
                NotifyPropertyChanged("Quantity");
            }
        }
        private Product product;
        public Product Product
        {
            get { return product; }
            set {product=value;
                NotifyPropertyChanged("Product");
            }
        }
        private string unitOfMeasure;
        public string UnitOfMeasure
        {
            get { return unitOfMeasure;}
            set { unitOfMeasure = value;
                NotifyPropertyChanged("UnitOfMeasure");
            }
        }
        private DateTime? supplyDate;
        public DateTime? SupplyDate
        {
            get { return supplyDate; }
            set { supplyDate = value;NotifyPropertyChanged("SupplyDate"); }
        }
        private DateTime? expirationDate;
        public DateTime? ExpirationDate
        {
            get { return expirationDate; }
            set { expirationDate = value; NotifyPropertyChanged("ExpirationDate"); }
        }
        private decimal purchasePrice;
        public decimal PurchasePrice
        {
            get { return purchasePrice; }
            set { purchasePrice = value; NotifyPropertyChanged("PurchasePrice"); }
        }
        private decimal sellingPrice;
        public decimal SellingPrice
        {
            get { return sellingPrice; }
            set { sellingPrice = value;NotifyPropertyChanged("SellingPrice"); }
        }
       public Stock()
        {
            this.product = new Product();

        }
    }
}
