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

namespace Wpf_журнал_учащихся_школы.Reports
{
    /// <summary>
    /// Логика взаимодействия для WReportClass.xaml
    /// </summary>
    public partial class WReportClass : Window
    {
        public WReportClass()
        {
            InitializeComponent();
            start();
        }
        private void start()
        {
            DataSet User=new DataSet();
            string sql = "EXEC SelectAllClass";
            User = WorkWithBD.outPutdb(sql).Tables[0].DataSet;
            for (int i = 0; i < User.Tables[0].DefaultView.Count; i++)
            {
                    ClassCB.Items.Add(User.Tables[0].DefaultView[i].Row[1].ToString());
            }
        }
        private void CancelBN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void AddBN_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToDateTime(DayFor.Text) < Convert.ToDateTime(DayOn.Text))
            {
                MessageBox.Show("Проверьте введенную дату");
                return;
            }
            else
            {
                try
                {
                    DataSet ds = new DataSet();
                    ds = WorkWithBD.outPutdb("EXEC SelectClassLog @GroupName = '" + ClassCB.Text + "', " +
                        "@DayOn = '" + Convert.ToDateTime(DayOn.Text) + "', @DayFor = '" + Convert.ToDateTime(DayFor.Text) + "'");
                    WorkWithWord.writeClass(ds, "reportClass");
                    Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
             }
        }
        private void ClassCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
