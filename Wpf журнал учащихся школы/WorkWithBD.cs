using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace WPF_журнал_учащихся
{
    public class WorkWithBD
    {
        static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True";
        // @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|schooldb.mdf;Integrated Security=True;Connect Timeout=30;";

        static DataSet ds = new DataSet();
        public static DataSet outPutdb(string sql) // вывод из бд
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                    connection.Open();
                    // Создаем объект DataAdapter (отправляет запрос на бд)
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    // Создаем объект Dataset (представление о таблице)
                    DataSet ds = new DataSet();
                    // Заполняем Dataset
                    adapter.Fill(ds);
                    return ds;
            }
        }
        //------------------------ИЗМЕНЕНИЕ----------------
        public static void Update(string sql) // обновление изменений 
        {
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                using (SqlCommand com = new SqlCommand(sql, sqlConn))
                {
                    sqlConn.Open();
                    SqlDataReader read = com.ExecuteReader();
                    read.Close();
                }
            }
        }    
        //-------------------УДАЛЕНИЕ-----------------------
        public static void removeRegistrationdb(int index) // удаление из бд
        {
            removeServiceListdb(index);
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM [Registration] WHERE [RegistrationID] = " + index, sqlConn))
                {
                    sqlConn.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void removeClientdb(int index) // удаление из бд клиента
        {
            string sql = "SELECT RegistrationID FROM Registration WHERE Registration.ClientID=" + index + "";

            List<int> list = new List<int>();
            for (int i = 0; i < Convert.ToInt32(WorkWithBD.outPutdb(sql).Tables[0].Rows.Count); i++)
            {
                list.Add(Convert.ToInt32(WorkWithBD.outPutdb(sql).Tables[0].DefaultView[i].Row[0].ToString()));
            }
            for (int i = 0; i < list.Count; i++)
            {
                removeServiceListdb(list[i]);
                removeRegistrationdb(list[i]);
            }

            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM [Client] WHERE [ClientID] = " + index, sqlConn))
                {
                    sqlConn.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM [Document] WHERE [DocumentID] = " + index, sqlConn))
                {
                    sqlConn.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void removeServicedb(int index)
        {
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM [Service] WHERE [ServiceID] = " + index, sqlConn))
                {
                    sqlConn.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void removeServiceListdb(int index)
        {
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM [ServiceList] WHERE [RegistrationID] = " + index, sqlConn))
                {
                    sqlConn.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void removeServiceListGooddb(int index)
        {
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM [ServiceList] WHERE [ServiceListID] = " + index, sqlConn))
                {
                    sqlConn.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
