using Supermarket.Models.DataAccessLayer;
using Supermarket.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.BusinessLogicLayer
{
    public class ProductReceiptBLL
    {

        private readonly ProductReceiptDAL productReceiptDAL = new ProductReceiptDAL();

        public void AddProductReceipt(ProductReceipt productReceipt)
        {
            productReceiptDAL.AddProductReceipt(productReceipt);
        }
    }
}
