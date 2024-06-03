using Supermarket.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.DataAccessLayer
{
    public class ProductReceiptDAL
    {

        public void AddProductReceipt(ProductReceipt productReceipt)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddProductReceipt", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramReceiptId = new SqlParameter("@receiptID", productReceipt.Receipt.ReceiptID);
                SqlParameter paramProductId = new SqlParameter("@productID", productReceipt.Product.ProductID);
                SqlParameter paramQuantity = new SqlParameter("@quantity", productReceipt.Quantity);
                SqlParameter paramSubtotal = new SqlParameter("@subtotal", productReceipt.Subtotal);
                SqlParameter paramIdProductReceipt = new SqlParameter("@productReceiptID", SqlDbType.Int);
                paramIdProductReceipt.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramReceiptId);
                cmd.Parameters.Add(paramProductId);
                cmd.Parameters.Add(paramQuantity);
                cmd.Parameters.Add(paramSubtotal);
                cmd.Parameters.Add(paramIdProductReceipt);
                con.Open();
                cmd.ExecuteNonQuery();
                productReceipt.ProductReceiptID = paramIdProductReceipt.Value as int?;
            }
        }
    }
}
