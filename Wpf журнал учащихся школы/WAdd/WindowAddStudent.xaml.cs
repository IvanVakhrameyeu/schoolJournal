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
    /// Логика взаимодействия для WindowAddStudent.xaml
    /// </summary>
    public partial class WindowAddStudent : Window
    {
        public WindowAddStudent()
        {
            InitializeComponent();
            start();
        }
        private void start()
        {
            DayB.Maximum = (DateTime.Today).AddYears(-18);
            SexCB.Items.Add("М");
            SexCB.Items.Add("Ж");

            DataSet User = new DataSet();
            string sql = "EXEC SelectAllClass";
            User = WorkWithBD.outPutdb(sql).Tables[0].DataSet;

            for (int i = 0; i < User.Tables[0].DefaultView.Count; i++)
            {
                ClassCB.Items.Add(User.Tables[0].DefaultView[i].Row[1].ToString());
            }
            sql = "EXEC SelectAllMedGroup";
            User = WorkWithBD.outPutdb(sql).Tables[0].DataSet;

            for (int i = 0; i < User.Tables[0].DefaultView.Count; i++)
            {
                MedGroupCB.Items.Add(User.Tables[0].DefaultView[i].Row[0].ToString());
            }

        }

        private void ClassCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MedGroupCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SexCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddBN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "EXEC InsertStudent " +
               "@GroupNameID=" + (ClassCB.SelectedIndex + 1).ToString() + " ,@MedGroupID="+ (MedGroupCB.SelectedIndex+1) +",@FIO='" + FIOTB.Text + "', " +
               "@Sex='" + SexCB.SelectedItem.ToString() + "', @DOB='" + Convert.ToDateTime(DayB.Text) + "'," +
               "@Tel='" + TelTB.Text + "'";
                WorkWithBD.outPutdb(sql);
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
