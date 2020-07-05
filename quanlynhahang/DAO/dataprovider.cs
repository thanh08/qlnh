using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlynhahang.DTO
{
    class dataprovider
    {
        private static dataprovider instance;
       

        private string connectionSTR = "Data Source=.\\SQLEXPRESS;Initial Catalog=quanlynhahang;Integrated Security=True";

        internal static dataprovider Instance
        {
            get
            {
                 if (instance == null) instance = new dataprovider(); return dataprovider.instance ;
            }

            set
            {
                dataprovider.instance = value;
            }
        }
        private dataprovider() { }

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {          connection.Open();

                SqlCommand commad = new SqlCommand(query, connection);
                if(parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach(string item in listPara)
                    {
                        if(item.Contains('@'))
                        {
                            commad.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                
                SqlDataAdapter adapter = new SqlDataAdapter(commad);

                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }


        public int ExecuteNonQuery (string query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand commad = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            commad.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = commad.ExecuteNonQuery();

                
                connection.Close();
            }
            return data;
        }

        public object ExecuteScalar (string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand commad = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            commad.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = commad.ExecuteScalar();

                connection.Close();

            }
            return data;
        }



    }
}
