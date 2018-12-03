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
using Wpf_журнал_учащихся_школы.UControl;
using Wpf_журнал_учащихся_школы.WAdd;

namespace Wpf_журнал_учащихся_школы.MainUC
{
    /// <summary>
    /// Логика взаимодействия для UCAdmin.xaml
    /// </summary>
    public partial class UCAdmin : UserControl
    {
        static public DataRowView row;
        static public int index;
        public DataRowView rows
        {
            get { return row; }
            set { row = value; }
        }
        public UCAdmin()
        {
            InitializeComponent();
        }
        private void MainListView_SelectionChanged(object sender, SelectionChangedEventArgs e) //change ListViewItem
        {
            switch (MainListView.SelectedIndex+1)
            {
                case 1:
                   SelectStudent();
                    break;
                case 2:
                    SelectClass();
                    break;
                case 3:
                    SelectLesson();
                    break;
                case 4:
                    SelectEmployee();
                    break;
                case 5:
                    SelectChart();
                    break;
                default:
                    break;
            }
        }
        private void refreshGrid() // обновление грида, после нажатий различных кнопок
        {
            switch (MainListView.SelectedIndex + 1)
            {
                case 1:
                    SelectStudent();
                    break;
                case 2:
                    SelectClass();
                    break;
                case 3:
                    SelectLesson();
                    break;
                case 4:
                    SelectEmployee();
                    break;
                case 5:
                    SelectChart();
                    break;
                default:
                    break;
            }
        }
        public void SelectLesson() // Load UserControl with Subjects
        {
            ContentGrid.Children.Clear();
            ContentGrid.Children.Add(new UCLessons());
        }
        public void SelectClass() // Load UserControl with Name class
        {
            ContentGrid.Children.Clear();
            ContentGrid.Children.Add(new UCClass());
        }
        public void SelectEmployee() // LOad UserControl with Teacher
        {
            ContentGrid.Children.Clear();
            ContentGrid.Children.Add(new UCEmployee());
        }
        private void SelectChart() // Load UserControl with Chart
        {
            ContentGrid.Children.Clear();
            ContentGrid.Children.Add(new UCCharts());
        }
        public void SelectStudent() // Load UserControl with Student
        {
            ContentGrid.Children.Clear();
            ContentGrid.Children.Add(new UControl.UCStudent());
        }
        private void AddBN_Click(object sender, RoutedEventArgs e) // add something
        {
            try
            {
                switch (MainListView.SelectedIndex + 1)
                {
                    case 1:
                        WindowAddStudent windowAddStudent = new WindowAddStudent();
                        windowAddStudent.ShowDialog();
                        refreshGrid();
                        break;
                    case 2:
                        refreshGrid();
                        break;
                    case 3:
                        refreshGrid();
                        break;
                    case 4:
                        WindowAddEmployee windowAddEmployee = new WindowAddEmployee();
                        windowAddEmployee.ShowDialog();
                        refreshGrid();
                        break;
                    case 5:
                        MessageBox.Show("Отчеты");
                        break;
                    default:
                        break;
                }
            }
            catch { }
        }
        private void EditBN_Click(object sender, RoutedEventArgs e) // change something
        {
            try
            {
                switch (MainListView.SelectedIndex + 1)
                {
                    case 1:
                        WindowEditStudent windowEditStudent = new WindowEditStudent();
                        windowEditStudent.ShowDialog();
                        refreshGrid();
                        break;
                    case 2:
                        refreshGrid();
                        break;
                    case 3:
                        refreshGrid();
                        break;
                    case 4:
                        WindowEditEmployee windowEditEmployee = new WindowEditEmployee();
                        windowEditEmployee.ShowDialog();
                        refreshGrid();
                        break;
                    case 5:
                        break;
                    default:
                        break;
                }
            }
            catch { }
        }
        private void DelBN_Click(object sender, RoutedEventArgs e) // delete something
        {
            try
            {
                switch (MainListView.SelectedIndex + 1)
                {
                    case 1:
                        string sql = ("EXEC DeleteStudent @StudentID=" + UControl.UCStudent.index);
                        WorkWithBD.outPutdb(sql);
                        ContentGrid.Children.Clear();
                        ContentGrid.Children.Add(new UControl.UCStudent());
                        refreshGrid();
                        break;
                    default:
                        break;
                }
            }
            catch { }
        }
    }
}
