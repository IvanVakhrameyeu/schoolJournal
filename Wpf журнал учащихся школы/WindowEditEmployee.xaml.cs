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
    /// Логика взаимодействия для WindowEditEmployee.xaml
    /// </summary>
    public partial class WindowEditEmployee : Window
    {
        public WindowEditEmployee()
        {
            InitializeComponent();
            start();
        }
        private void addItems()
        {
            SexCB.Items.Add("М");
            SexCB.Items.Add("Ж");

            DataSet User = new DataSet();
            string sql = "SELECT SubName FROM Subjects";
            User = WorkWithBD.outPutdb(sql).Tables[0].DataSet;

            for (int i = 0; i < User.Tables[0].DefaultView.Count; i++)
            {
                SubjectCB.Items.Add(User.Tables[0].DefaultView[i].Row[0].ToString());
            }
        }
        private void start()
        {
            try
            {
                addItems();
                SubjectCB.Text = UCEmployee.row.Row.ItemArray[5].ToString();
                FIOTB.Text = UCEmployee.row.Row.ItemArray[1].ToString();
                SexCB.Text = UCEmployee.row.Row.ItemArray[2].ToString();
                DayB.Text = (UCEmployee.row.Row.ItemArray[3].ToString()).Split(' ')[0];
                TelTB.Text = UCEmployee.row.Row.ItemArray[4].ToString();
            }
            catch { MessageBox.Show("Не выбран учащийся"); Close(); }
        }
        private void AddBN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SexCB.Text != "М" && SexCB.Text != "Ж") { return; }
                string sql = "UPDATE [Employee] SET [SubjectsID] = '" + (SubjectCB.SelectedIndex + 1).ToString() + "', " +
                    "[FIOEmployee] = '" + FIOTB.Text + "', " +
                    "[Sex] = '" + SexCB.SelectedItem.ToString() + "', " +
                    "[DOB] = '" + Convert.ToDateTime(DayB.Text) + "', " +
                    "[Tel] = '" + TelTB.Text + "' " +
                    "WHERE [EmployeeID] = " + UCEmployee.index;

                WorkWithBD.Update(sql);

                Close();
            }
            catch { MessageBox.Show("Введите корректные данные"); }

        }


        private void CancelBN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SubjectCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SexCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
