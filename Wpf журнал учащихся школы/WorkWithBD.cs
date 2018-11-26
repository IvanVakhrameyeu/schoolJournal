using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //--------------------ДОБАВЛЕНИЕ---------------------
        public static void inputStudent(string sql, string GroupNameID, string MedGroupID, string FIOTB, string Sex, string DayB, string Tel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@GroupNameID", GroupNameID);
                    cmd.Parameters.AddWithValue("@MedGroupID", MedGroupID);
                    cmd.Parameters.AddWithValue("@FIO", FIOTB);
                    cmd.Parameters.AddWithValue("@Sex", Sex);
                    cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(DayB));
                    cmd.Parameters.AddWithValue("@Tel", Tel);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void inputEmployee(string sql, string SubjectsID, string FIOTB, string Sex, string DayB, string Tel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@SubjectsID", SubjectsID);
                    cmd.Parameters.AddWithValue("@FIOEmployee", FIOTB);
                    cmd.Parameters.AddWithValue("@Sex", Sex);
                    cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(DayB));
                    cmd.Parameters.AddWithValue("@Tel", Tel);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void inputLogs(string sql, string DayB, string StudentID, string SubjectsID, string Missed, string Rating)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Data", Convert.ToDateTime(DayB));
                    cmd.Parameters.AddWithValue("@StudentID", StudentID);
                    cmd.Parameters.AddWithValue("@SubjectsID ", SubjectsID);
                    cmd.Parameters.AddWithValue("@Missed", Missed);
                    cmd.Parameters.AddWithValue("@Rating", Rating);
                    cmd.ExecuteNonQuery();
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
