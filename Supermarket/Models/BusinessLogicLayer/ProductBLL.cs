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
    public class ProductBLL
    {

        public ObservableCollection<Product> ProductsList { get; set; }

        private ProductDAL productDAL;

        public ProductBLL()
        {
            productDAL = new ProductDAL();
            ProductsList = new ObservableCollection<Product>();
        }
        public ObservableCollection<Product> GetAllProducts()
        {
            return productDAL.GetAllProducts();
        }
        public void AddProduct(Product product)
        {
            productDAL.AddProduct(product);
            ProductsList.Add(product);
        }
        public Product GetProductByID(int? id)
        {
                return productDAL.GetProductByID(id);
        }
        public void GetProductsForProducer(Producer producer)
        {
            if(ProductsList.Count > 0) 
            {
                ProductsList.Clear();

            }
            var products=productDAL.GetProductsByProducer(producer);
            foreach (var product in products)
            {
                ProductsList.Add(product);
            }
        }
    }
}
