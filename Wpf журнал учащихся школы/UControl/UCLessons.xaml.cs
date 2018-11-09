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
    /// Логика взаимодействия для UCLessons.xaml
    /// </summary>
    public partial class UCLessons : UserControl
    {
        static public DataRowView row;
        static public int index;
        public DataRowView rows
        {
            get { return row; }
            set { row = value; }
        }
        public UCLessons()
        {
            InitializeComponent();
            start();
        }
        private void start()
        {
            string sql = "SELECT Lessons.LessonsID, GroupName.Name, Subjects.SubName " +
                        "FROM Lessons " +
                        "JOIN Subjects ON (Lessons.SubjectsID = Subjects.SubjectsID) " +
                        "JOIN GroupName ON (Lessons.GroupNameID = GroupName.GroupNameID)";

            DataGridTotal.ItemsSource = (WorkWithBD.outPutdb(sql)).Tables[0].DefaultView;
        }

        private void DataGridTotal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            row = DataGridTotal.SelectedItem as DataRowView;
            index = Convert.ToInt32(row.Row.ItemArray[0]);
        }
    }
}
