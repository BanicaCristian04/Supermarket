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
    public class ProducerDAL
    {
        public ObservableCollection<Producer> GetAllProducers()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllProducers", con);
                ObservableCollection<Producer> result = new ObservableCollection<Producer>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Producer producer = new Producer();
                    producer.ProducerID = (int)(reader[0]);
                    producer.Name = reader.GetString(1);
                    producer.OriginCountry = reader.GetString(2);
                    result.Add(producer);
                }
                reader.Close();
                return result;
            }
        }
        public void AddProducer(Producer producer)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddProducer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramName = new SqlParameter("@name", producer.Name);
                SqlParameter paramCountry = new SqlParameter("@originCountry", producer.OriginCountry);
                SqlParameter paramIdProducer = new SqlParameter("@producerID", SqlDbType.Int);
                paramIdProducer.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramName);
                cmd.Parameters.Add(paramCountry);
                cmd.Parameters.Add(paramIdProducer);
                con.Open();
                cmd.ExecuteNonQuery();
                producer.ProducerID = paramIdProducer.Value as int?;
            }
        }
        public void UpdateProducer(Producer producer)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateProducer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdProducer = new SqlParameter("@producerID", producer.ProducerID);
                SqlParameter paramCountry = new SqlParameter("@originCountry", producer.OriginCountry);

                SqlParameter paramName = new SqlParameter("@name", producer.Name);
                cmd.Parameters.Add(paramName);
                cmd.Parameters.Add(paramCountry);

                cmd.Parameters.Add(paramIdProducer);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
        public void DeleteProducer(Producer producer)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteProducer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdProducer = new SqlParameter("@producerID", producer.ProducerID);
                cmd.Parameters.Add(paramIdProducer);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
    }
}

