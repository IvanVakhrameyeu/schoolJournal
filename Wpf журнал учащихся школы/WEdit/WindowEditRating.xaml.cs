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
using Wpf_журнал_учащихся_школы.UControl;

namespace Wpf_журнал_учащихся_школы
{
    /// <summary>
    /// Логика взаимодействия для WindowEditRating.xaml
    /// </summary>
    public partial class WindowEditRating : Window
    {
        public WindowEditRating()
        {
            InitializeComponent();
            start();
        }
        private void start()
        {
            RatingCB.Items.Add(" ");
            for (int i = 1; i <= 10; i++)
                RatingCB.Items.Add(i.ToString());
            

            DataSet User = new DataSet();
            string sql = "SELECT GroupNameID FROM GroupName WHERE Name='" + MainWindow.NameGroup + "'";
            User = WorkWithBD.outPutdb(sql).Tables[0].DataSet;

            var id = User.Tables[0].DefaultView[0].Row[0].ToString();

            sql = "SELECT FIO FROM Student WHERE GroupNameID = '" + id.ToString() + "'";
            User = WorkWithBD.outPutdb(sql).Tables[0].DataSet;
            for (int i = 0; i < User.Tables[0].DefaultView.Count; i++)
            {
                FIOCB.Items.Add(User.Tables[0].DefaultView[i].Row[0].ToString());
            }

            try
            {
                FIOCB.Text = UCLogs.row.Row.ItemArray[1].ToString();
                DayB.Text = (UCLogs.row.Row.ItemArray[2].ToString()).Split(' ')[0];
                MissedChB.IsChecked = (UCLogs.row.Row.ItemArray[3].ToString() == "н") ? true:false ;
                RatingCB.Text = UCLogs.row.Row.ItemArray[4].ToString();
            }
            catch { MessageBox.Show("Не выбран учащийся"); Close(); }
        }
        private void AddBN_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                DataSet User = new DataSet();
                User = WorkWithBD.outPutdb("SELECT StudentID FROM Student WHERE FIO ='" + (FIOCB.SelectedItem).ToString() + "'").Tables[0].DataSet;

                string idfio = (User.Tables[0].DefaultView[0].Row[0].ToString());
        
                string sql = "UPDATE [Logs] SET [StudentID] = " + idfio + ", " +
                   "[Missed] = '" + ((MissedChB.IsChecked==true)? "н" : " ") + "', " +
                   "[Rating] = " + (RatingCB.SelectedItem.ToString()==" "? "NULL" : RatingCB.SelectedItem.ToString()) + ", " +
                   "[Data] = '" + Convert.ToDateTime(DayB.Text) + "' " +
                   "WHERE [LogsID] = " + UCLogs.index;

                WorkWithBD.Update(sql);

                Close();
            }
            catch { MessageBox.Show("Введите корректные данные или проверьте поле оценка"); }
        }

        private void CancelBN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
