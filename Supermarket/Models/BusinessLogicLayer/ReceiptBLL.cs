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
    public class ReceiptBLL
    {

        private readonly ReceiptDAL receiptDAL = new ReceiptDAL();

        public void AddReceipt(Receipt receipt)
        {
            receiptDAL.AddReceipt(receipt);
        }
        public Receipt GetLargestReceipt(DateTime? date)
        {
            return receiptDAL.GetLargestReceipt(date);
        }
        public ObservableCollection<ProductReceipt> GetProductsByReceiptID(int? receiptID)
        {
            return receiptDAL.GetProductsByReceiptID(receiptID);
        }
    }
}
