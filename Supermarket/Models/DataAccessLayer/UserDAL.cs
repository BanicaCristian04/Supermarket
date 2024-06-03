using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using Supermarket.Models.EntityLayer;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Supermarket.Models.DataAccessLayer
{
    public class UserDAL
    {
        public ObservableCollection<User> GetAllUsers()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllUsers", con);
                ObservableCollection<User> result = new ObservableCollection<User>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(4))
                    {
                        if (reader.GetBoolean(4) == true)
                            return result;
                    }
                    else
                    {
                        User user = new User();
                        user.UserID = (int)(reader[0]);
                        user.Username = reader.GetString(1);
                        user.Password = reader.GetString(2);
                        user.UserType = (UserTypeEnum)Enum.Parse(typeof(UserTypeEnum), reader.GetString(3));
                        result.Add(user);

                    }
                }
                reader.Close();
                return result;
            }
        }
        public void AddUser(User user)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramUsername = new SqlParameter("@username", user.Username);
                SqlParameter paramPassword = new SqlParameter("@password", user.Password);
                SqlParameter paramType = new SqlParameter("@userType", Enum.GetName(typeof(UserTypeEnum),user.UserType));
                SqlParameter paramIdUser = new SqlParameter("@userID", SqlDbType.Int);
                paramIdUser.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramUsername);
                cmd.Parameters.Add(paramPassword);
                cmd.Parameters.Add(paramType);
                cmd.Parameters.Add(paramIdUser);
                con.Open();
                cmd.ExecuteNonQuery();
                user.UserID = paramIdUser.Value as int?;
            }
        }
        public void UpdateUser(User user)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdUser = new SqlParameter("@userID", user.UserID);
                SqlParameter paramUsername = new SqlParameter("@username", user.Username);
                SqlParameter paramPassword = new SqlParameter("@password", user.Password);
                SqlParameter paramType = new SqlParameter("@userType", user.UserType.ToString());
                cmd.Parameters.Add(paramUsername);
                cmd.Parameters.Add(paramPassword);
                cmd.Parameters.Add(paramType);
                cmd.Parameters.Add(paramIdUser);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
        public void DeleteUser(User user)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdUser = new SqlParameter("@userID", user.UserID);
                cmd.Parameters.Add(paramIdUser);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }


        public User AuthenticateUser(User user)
        {
            using(SqlConnection con= DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UserAuthentication", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramName = new SqlParameter("@username", user.Username);
                SqlParameter paramPass = new SqlParameter("@password", user.Password);
                cmd.Parameters.Add(paramName);
                cmd.Parameters.Add(paramPass);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    user.UserID = (int)reader[0];
                    if (Enum.TryParse(reader.GetString(1), out UserTypeEnum userTypeEnum))
                        user.UserType = userTypeEnum;
                    return user;
                }
                return null;

            }
        }

        public ObservableCollection<User> GetAllCashiers()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllCashiers", con);
                ObservableCollection<User> result = new ObservableCollection<User>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                        User user = new User();
                        user.UserID = (int)(reader[0]);
                        user.Username = reader.GetString(1);
                        user.Password = reader.GetString(2);
                        user.UserType = (UserTypeEnum)Enum.Parse(typeof(UserTypeEnum), reader.GetString(3));
                        result.Add(user);
                }
                reader.Close();
                return result;

            }

        }
        public ObservableCollection<DailyTransaction> GetTotalAmountPerDayUser(int? cashierID, DateTime? date)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetTotalAmountPerDayUser", con);
                ObservableCollection<DailyTransaction> result = new ObservableCollection<DailyTransaction>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramCashierID = new SqlParameter("@cashierID", cashierID);
                SqlParameter paramDate = new SqlParameter("@date", date);
                cmd.Parameters.Add(paramCashierID);
                cmd.Parameters.Add(paramDate);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DailyTransaction transaction = new DailyTransaction
                    {
                        IssueDate = reader.GetDateTime(0),
                        TotalAmount = reader.GetDecimal(1)
                    };
                    result.Add(transaction);
                }
                reader.Close();
                return result;
            }
        }
        

    }
}
