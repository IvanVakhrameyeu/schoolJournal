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
    }
}
