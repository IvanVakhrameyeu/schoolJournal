using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_журнал_учащихся;

namespace Wpf_журнал_учащихся_школы.WAdd
{
    /// <summary>
    /// Логика взаимодействия для WindowAddRating.xaml
    /// </summary>
    public partial class WindowAddRating : Window
    {
        public WindowAddRating()
        {
            InitializeComponent();
            start();
        }
        private void start()
        {
            for (int i = 1; i <= 10; i++)
                RatingCB.Items.Add(i.ToString());

            DataSet User = new DataSet();
            string sql = "SELECT GroupNameID FROM GroupName WHERE Name='"+ MainWindow.NameGroup + "'";
            User = WorkWithBD.outPutdb(sql).Tables[0].DataSet;

            var id = User.Tables[0].DefaultView[0].Row[0].ToString();

            sql="SELECT FIO FROM Student WHERE GroupNameID = '" + id.ToString() +"'";
            User = WorkWithBD.outPutdb(sql).Tables[0].DataSet;
            for (int i = 0; i < User.Tables[0].DefaultView.Count; i++)
            {
                FIOCB.Items.Add(User.Tables[0].DefaultView[i].Row[0].ToString());
            }
        }
        private void AddBN_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                DataSet User = new DataSet();
                User = WorkWithBD.outPutdb("SELECT StudentID FROM Student WHERE FIO ='" + (FIOCB.SelectedItem).ToString() + "'").Tables[0].DataSet;

                string idfio = (User.Tables[0].DefaultView[0].Row[0].ToString());
                string sql = "INSERT INTO Logs (Data , StudentID, SubjectsID, Missed, Rating) " +
           "VALUES (@Data, @StudentID, @SubjectsID, @Missed, @Rating)";
                
                    WorkWithBD.inputLogs(sql, DayB.Text, idfio, MainWindow.SubjectID, ((MissedChB.IsChecked == true) ? "н" : "NULL"), RatingCB.Text); //короткая запись сделать

                Close();
        }
            catch { MessageBox.Show("Введите корректные данные"); }
}

        private void CancelBN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
