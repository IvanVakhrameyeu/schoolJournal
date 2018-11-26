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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_журнал_учащихся;

namespace Wpf_журнал_учащихся_школы.UControl
{
    /// <summary>
    /// Логика взаимодействия для UCStudentLogs.xaml
    /// </summary>
    public partial class UCStudentLogs : UserControl
    {
        public UCStudentLogs()
        {
            InitializeComponent();
            start();
        }

        private void start() // проверить студента, у которого есть оценки
        {
            string sql = "SelectStudentLog @SubName='" + MainWindow.SubName + "',@StudentID="+ MainWindow.StudentID;        

            DataGridTotal.ItemsSource = (WorkWithBD.outPutdb(sql)).Tables[0].DefaultView;
        }
        private void DataGridTotal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
