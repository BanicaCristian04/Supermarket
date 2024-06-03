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
    public class ProducerProductsReportVM:BasePropertyChanged
    {
        ProducerBLL producerBLL = new ProducerBLL();
        ProductBLL productBLL = new ProductBLL();

        private ObservableCollection<Tuple<Category, ObservableCollection<Product>>> productCategory;

        public ObservableCollection<Tuple<Category, ObservableCollection<Product>>> ProductCategory
        {
            get => productCategory;
            set 
                {
                productCategory = value;
                    NotifyPropertyChanged("ProductCategory"); 
            }
        }
        public ObservableCollection<Producer> ProducersList
        {
            get => producerBLL.ProducerList;
            set => producerBLL.ProducerList = value;
        }
        public ObservableCollection<Product> ProductsList
        {
            get => productBLL.ProductsList;
            set => productBLL.ProductsList = value;
        }
        private ICommand filterProductCommand;
        public ICommand FilterProductCommand
        {
            get
            {
                if(filterProductCommand== null)
                {
                    filterProductCommand = new RelayCommand<Producer>(FilterProductByProducer);
                }
                return filterProductCommand;
            }
        }

        private void FilterProductByProducer(Producer producer)
        {
            if (producer != null)
            {
                productBLL.GetProductsForProducer(producer);
                ProductCategory = new ObservableCollection<Tuple<Category, ObservableCollection<Product>>>();
                foreach (Product product in productBLL.ProductsList)
                {
                bool ok = false;

                    foreach (Tuple < Category,ObservableCollection<Product>> productCategory in ProductCategory)
                    {
                        if (productCategory.Item1.CategoryID==product.Category.CategoryID)
                        {
                            productCategory.Item2.Add(product);
                            ok = true;
                        }
                    }
                    if (!ok)
                    {
                        ObservableCollection<Product> products = new ObservableCollection<Product>();
                        products.Add(product);
                        ProductCategory.Add(Tuple.Create(product.Category, products));
                    }

                }
            }

        }


        public ProducerProductsReportVM()
        {
            ProducersList = producerBLL.GetAllProducers();
            
        }
    }
}
