using Supermarket.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Instrumentation;

namespace Supermarket.Models.DataAccessLayer
{
    public class ProductDAL
    {
        public ObservableCollection<Product> GetAllProducts()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllProducts", con);
                ObservableCollection<Product> result = new ObservableCollection<Product>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ProductID = (int)(reader[0]);
                    product.Name = reader.GetString(1);
                    product.Barcode = reader.GetString(2);
                    product.Category = new Category()
                    {
                        CategoryID = (int)(reader[3]),
                        Name = reader.GetString(4),

                    };
                    product.Producer = new Producer()
                    {
                        ProducerID = (int)(reader[5]),
                        Name = reader.GetString(6),
                        OriginCountry = reader.GetString(7)
                    };
                    result.Add(product);
                }
                reader.Close();
                return result;
            }
        }
        public void AddProduct(Product product)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramName = new SqlParameter("@name", product.Name);
                SqlParameter paramBarcode = new SqlParameter("@barcode", product.Barcode);
                SqlParameter paramCategory = new SqlParameter("@categoryID", product.Category.CategoryID);
                SqlParameter paramProducer = new SqlParameter("@producerID", product.Producer.ProducerID);
                SqlParameter paramIdProduct = new SqlParameter("@productID", SqlDbType.Int);
                paramIdProduct.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramName);
                cmd.Parameters.Add(paramBarcode);
                cmd.Parameters.Add(paramCategory);
                cmd.Parameters.Add(paramProducer);
                cmd.Parameters.Add(paramIdProduct);
                con.Open();
                cmd.ExecuteNonQuery();
                product.ProductID = paramIdProduct.Value as int?;
            }
        }
        public void UpdateProduct(Product product)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdProduct = new SqlParameter("@productID", product.ProductID);
                SqlParameter paramName = new SqlParameter("@name", product.Name);
                SqlParameter paramBarcode = new SqlParameter("@barcode", product.Barcode);
                SqlParameter paramCategory = new SqlParameter("@categoryID", product.Category.CategoryID);
                SqlParameter paramProducer = new SqlParameter("@producerID", product.Producer.ProducerID);
                cmd.Parameters.Add(paramName);
                cmd.Parameters.Add(paramBarcode);
                cmd.Parameters.Add(paramCategory);
                cmd.Parameters.Add(paramProducer);
                cmd.Parameters.Add(paramIdProduct);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteProduct(Product product)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdProduct = new SqlParameter("@productID", product.ProductID);
                cmd.Parameters.Add(paramIdProduct);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
        public Product GetProductByID(int? id)
        {
            if(id!=null)
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetProductByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdProduct = new SqlParameter("@productID", id);
                cmd.Parameters.Add(paramIdProduct);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        Product product = new Product();
                        product.ProductID = id;
                        product.Name = reader[0].ToString();
                        product.Barcode = reader[1].ToString();
                        product.Category = new Category()
                        {
                            CategoryID = (int)(reader[2]),
                            Name = reader[3].ToString()
                        };
                        product.Producer = new Producer()
                        {
                            ProducerID = (int)(reader[4]),
                            Name = reader[5].ToString(),
                            OriginCountry = reader[6].ToString()
                        };
                        reader.Close();

                        return product;
                    }
                reader.Close();
               

            }
            return null;
        }
        public ObservableCollection<Product> GetProductsByProducer(Producer producer)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetProductsByProducer", con);
                ObservableCollection<Product> result = new ObservableCollection<Product>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdProducer = new SqlParameter("@producerID", producer.ProducerID);
                cmd.Parameters.Add(paramIdProducer);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ProductID = (int)(reader[0]);
                    product.Name = reader.GetString(1);
                    product.Barcode = reader.GetString(2);
                    product.Category = new Category()
                    {
                        CategoryID = (int)(reader[3]),
                        Name = reader.GetString(4),

                    };
                    product.Producer = new Producer()
                    {
                        ProducerID = (int)(reader[5]),
                        Name = reader.GetString(6),
                        OriginCountry = reader.GetString(7)
                    };
                    result.Add(product);
                }
                reader.Close();
                return result;
            }
        }
    }
}

