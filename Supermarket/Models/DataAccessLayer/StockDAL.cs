using Supermarket.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.DataAccessLayer
{
    public class StockDAL
    {

        public ObservableCollection<Stock> GetAllStocks()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllStocks", con);
                ObservableCollection<Stock> result = new ObservableCollection<Stock>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Stock stock = new Stock();
                    stock.StockID = (int)(reader[0]);
                    stock.Product = new Product()
                    {  ProductID = (int)(reader[1]),
                       
                    };
                    stock.Quantity = (int)(reader[2]);
                    stock.UnitOfMeasure = reader.GetString(3);
                    stock.SupplyDate = reader.GetDateTime(4);
                    stock.ExpirationDate = reader.GetDateTime(5);
                    stock.PurchasePrice = reader.GetDecimal(6);
                    stock.SellingPrice = reader.GetDecimal(7);
                    
                    result.Add(stock);
                }
                reader.Close();
                return result;
            }
        }

        internal void UpdateStockQuantity(int stockID, int quantity)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateStockQuantity", con);
                ObservableCollection<Stock> result = new ObservableCollection<Stock>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramStockID = new SqlParameter("@stockID", stockID);
                SqlParameter paramQuantity = new SqlParameter("@quantity", quantity);
                cmd.Parameters.Add(paramStockID);
                cmd.Parameters.Add(paramQuantity);
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }
        //public void AddStock(Stock stock)
        //{
        //    using (SqlConnection con = DALHelper.Connection)
        //    {
        //        SqlCommand cmd = new SqlCommand("AddProduct", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlParameter paramName = new SqlParameter("@name", product.Name);
        //        SqlParameter paramBarcode = new SqlParameter("@barcode", product.Barcode);
        //        SqlParameter paramCategory = new SqlParameter("@categoryID", product.Category.CategoryID);
        //        SqlParameter paramProducer = new SqlParameter("@producerID", product.Producer.ProducerID);
        //        SqlParameter paramIdProduct = new SqlParameter("@productID", SqlDbType.Int);
        //        paramIdProduct.Direction = ParameterDirection.Output;
        //        cmd.Parameters.Add(paramName);
        //        cmd.Parameters.Add(paramBarcode);
        //        cmd.Parameters.Add(paramCategory);
        //        cmd.Parameters.Add(paramProducer);
        //        cmd.Parameters.Add(paramIdProduct);
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        product.ProductID = paramIdProduct.Value as int?;
        //    }
        //}
        //public void UpdateProduct(Product product)
        //{
        //    using (SqlConnection con = DALHelper.Connection)
        //    {
        //        SqlCommand cmd = new SqlCommand("UpdateProduct", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlParameter paramIdProduct = new SqlParameter("@productID", product.ProductID);
        //        SqlParameter paramName = new SqlParameter("@name", product.Name);
        //        SqlParameter paramBarcode = new SqlParameter("@barcode", product.Barcode);
        //        SqlParameter paramCategory = new SqlParameter("@categoryID", product.Category.CategoryID);
        //        SqlParameter paramProducer = new SqlParameter("@producerID", product.Producer.ProducerID);
        //        cmd.Parameters.Add(paramName);
        //        cmd.Parameters.Add(paramBarcode);
        //        cmd.Parameters.Add(paramCategory);
        //        cmd.Parameters.Add(paramProducer);
        //        cmd.Parameters.Add(paramIdProduct);
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //}
        //public void DeleteProduct(Product product)
        //{
        //    using (SqlConnection con = DALHelper.Connection)
        //    {
        //        SqlCommand cmd = new SqlCommand("DeleteProduct", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlParameter paramIdProduct = new SqlParameter("@productID", product.ProductID);
        //        cmd.Parameters.Add(paramIdProduct);
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //    }

        //}

    }
}
