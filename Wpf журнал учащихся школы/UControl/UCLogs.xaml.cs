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
using Wpf_журнал_учащихся_школы.MainUC;

namespace Wpf_журнал_учащихся_школы.UControl
{
    /// <summary>
    /// Логика взаимодействия для UCLogs.xaml
    /// </summary>
    public partial class UCLogs : UserControl
    {
        static public DataRowView row;
        static public int index;
        public DataRowView rows
        {
            get { return row; }
            set { row = value; }
        }
        public UCLogs()
        {
            InitializeComponent();
            start();
        }
        private void start() // тут чот не то (мб норм)
        {
           // DataSet User = new DataSet();
            //  WorkWithBD.outPutdb("SELECT GroupNameID FROM GroupName WHERE Name = '" + MainWindow.NameGroup + "'").Tables[0].DataSet;
            
            string sql = ("EXEC SelectLogs @NameGroup='" + MainWindow.NameGroup + "', @SubjectId=" + MainWindow.SubjectID);            
            DataGridTotal.ItemsSource = (WorkWithBD.outPutdb(sql)).Tables[0].DefaultView;
        }

        private void DataGridTotal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            row = DataGridTotal.SelectedItem as DataRowView;
            index = Convert.ToInt32(row.Row.ItemArray[0]);
        }
    }
}
