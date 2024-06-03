using Supermarket.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Supermarket.Controls;

namespace Supermarket.Models.DataAccessLayer
{
    public class ReceiptDAL
    {

        public void AddReceipt(Receipt receipt)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddReceipt", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramCashier = new SqlParameter("@cashierID", receipt.UserID);
                SqlParameter paramIssueDate = new SqlParameter("@issueDate", receipt.IssueDate);
                SqlParameter paramTotalAmount = new SqlParameter("@totalAmount", receipt.TotalAmount);
                SqlParameter paramIdReceipt = new SqlParameter("@receiptID", SqlDbType.Int);
                paramIdReceipt.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramCashier);
                cmd.Parameters.Add(paramIssueDate);
                cmd.Parameters.Add(paramTotalAmount);
                cmd.Parameters.Add(paramIdReceipt);
                con.Open();
                cmd.ExecuteNonQuery();
                receipt.ReceiptID = paramIdReceipt.Value as int?;
            }
        }
        public Receipt GetLargestReceipt(DateTime? date)
        {
            Receipt largestReceipt = null;

            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetLargestReceipt", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramDate = new SqlParameter("@date", date);
                cmd.Parameters.Add(paramDate);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    largestReceipt = new Receipt
                    {
                        ReceiptID = reader.GetInt32(0),
                        UserID = reader.GetInt32(1),
                        IssueDate = reader.GetDateTime(2),
                        TotalAmount = reader.GetDecimal(3)
                    };
                   

                }
                
            }

            return largestReceipt;
        }
        public ObservableCollection<ProductReceipt> GetProductsByReceiptID(int? receiptID)
        {


            ObservableCollection<ProductReceipt> products = new ObservableCollection<ProductReceipt>();
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetProductByReceiptID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramReceiptId = new SqlParameter("@receiptID", receiptID);
                cmd.Parameters.Add(paramReceiptId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductReceipt product = new ProductReceipt
                    {
                        ProductReceiptID = reader.GetInt32(0),
                        Product =new Product{
                            ProductID=reader.GetInt32(1) },
                        Receipt =new Receipt
                        {
                            ReceiptID=reader.GetInt32(2),
                        },
                        Subtotal = reader.GetDecimal(3),
                        Quantity = reader.GetInt32(4)
                    };
                    products.Add(product);

                }
            }
            return products;
        }


    }
}

