using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.EntityLayer
{
    public class ProductReceipt : BasePropertyChanged
    {

        private int? productReceiptID;
        public int? ProductReceiptID
        {
            get
            {
                return productReceiptID;
            }
            set
            {
                productReceiptID = value;
                NotifyPropertyChanged("StockID");
            }
        }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                NotifyPropertyChanged("Quantity");
            }
        }
        private decimal subtotal;
        public decimal Subtotal
        {
            get { return subtotal; }
            set {
                subtotal = value;
                NotifyPropertyChanged("Subtotal");
            }
        }
        private Product product;
        public Product Product
        {
            get { return product; }
            set
            {
                product = value;
                NotifyPropertyChanged("Product");
            }
        }
        private Receipt receipt;
        public Receipt Receipt
        {
            get { return receipt; }
            set
            {
                receipt = value;
                NotifyPropertyChanged("Receipt");
            }
        }
    }

}
