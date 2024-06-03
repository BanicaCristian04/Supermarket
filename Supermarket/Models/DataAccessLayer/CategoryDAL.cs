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
    public class CategoryDAL
    {

        public ObservableCollection<Category> GetAllCategories()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllCategories", con);
                ObservableCollection<Category> result = new ObservableCollection<Category>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Category category = new Category();
                    category.CategoryID = (int)(reader[0]);
                    category.Name = reader.GetString(1);
                    result.Add(category);
                }
                reader.Close();
                return result;
            }
        }
        public void AddCategory(Category category)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramName = new SqlParameter("@category", category.Name);
                SqlParameter paramIdCategory = new SqlParameter("@categoryID", SqlDbType.Int);
                paramIdCategory.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramName);
                cmd.Parameters.Add(paramIdCategory);
                con.Open();
                cmd.ExecuteNonQuery();
                category.CategoryID = paramIdCategory.Value as int?;
            }
        }
        public void UpdateCategory(Category category)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdCategory = new SqlParameter("@categoryID", category.CategoryID);
                SqlParameter paramName = new SqlParameter("@name", category.Name);
                cmd.Parameters.Add(paramName);
                cmd.Parameters.Add(paramIdCategory);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
        public void DeleteUser(Category category)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdUser = new SqlParameter("@categoryID", category.CategoryID);
                cmd.Parameters.Add(paramIdUser);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
    }
}
