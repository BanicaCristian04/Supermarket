using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.EntityLayer
{
    public class Product:BasePropertyChanged
    {
        private int? productID;
        public int? ProductID
        {
            get { return productID; }
            set
            {
                productID = value;
                NotifyPropertyChanged("ProductID");
            }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }
        private string barcode;
        public string Barcode
        {
            get { return barcode; }
            set
            {
                barcode = value;
                NotifyPropertyChanged("Barcode");
            }
        }
        private Category category;
        public Category Category
        {
            get { return category; }
            set
            {
                category = value;
                NotifyPropertyChanged("Category");
            }
        }
        private Producer producer;
        public Producer Producer
        {
            get { return producer; }
            set
            {
                producer = value;
                NotifyPropertyChanged("Producer");
            }
        }


    }
}
