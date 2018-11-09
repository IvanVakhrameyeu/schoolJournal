using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
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
using Xceed.Wpf.DataGrid;

namespace Wpf_журнал_учащихся_школы
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static public DataRowView row;
        static public int index;
        static public string NAME;
        static public string SubjectID;
        static public string GroupNameID;
        static public string StudentID;
        static public string NameGroup;
        static public string SubName;

        public static string Access = ""; // уровень доступа пользователя
        public DataRowView rows
        {
            get { return row; }
            set { row = value; }
        }
        public MainWindow()
        {
            WindowLogin windowLogin = new WindowLogin();
            windowLogin.ShowDialog();

            if (Access == "") Close();
            else
            {
                InitializeComponent();
                start();
            }
        }

        private void refreshGrid() // обновление грида, после нажатий различных кнопок
        {
            switch (MainListView.Items[MainListView.SelectedIndex].ToString())
            {
                case "Студенты":
                    ContentGrid.Children.Clear();
                    ContentGrid.Children.Add(new UCStudent());
                    break;
                case "Классы":
                    ContentGrid.Children.Clear();
                    ContentGrid.Children.Add(new UCClass());
                    break;
                case "Предметы":
                    ContentGrid.Children.Clear();
                    ContentGrid.Children.Add(new UCLessons());
                    break;

                case "Учителя":
                    ContentGrid.Children.Clear();
                    ContentGrid.Children.Add(new UCEmployee());
                    break;
                case "Отчеты":
                    ContentGrid.Children.Clear();

                    break;
                default:
                    ContentGrid.Children.Clear();
                    ContentGrid.Children.Add(new UCLogs());
                    break;
            }
        }
        private void AddBN_Click(object sender, RoutedEventArgs e) // добавление
        {
            try
            {
                switch (MainListView.Items[MainListView.SelectedIndex].ToString())
                {
                    case "Студенты":
                        WindowAddStudent windowAddStudent = new WindowAddStudent();
                        windowAddStudent.ShowDialog();
                        refreshGrid();
                        break;
                    case "Классы":
                        refreshGrid();
                        break;
                    case "Предметы":
                        refreshGrid();
                        break;
                    case "Учителя":
                        WindowAddEmployee windowAddEmployee = new WindowAddEmployee();
                        windowAddEmployee.ShowDialog();
                        refreshGrid();
                        break;
                    case "Отчеты":

                        MessageBox.Show("Отчеты");
                        break;

                    default:
                        WindowAddRating windowAddRating = new WindowAddRating();
                        windowAddRating.ShowDialog();

                        refreshGrid();
                        break;
                }
            }
            catch { }
        }
        private void EditBN_Click(object sender, RoutedEventArgs e) // изменение
        {
            try
            {
                switch (MainListView.Items[MainListView.SelectedIndex].ToString())
                {
                    case "Студенты":
                        WindowEditStudent windowEditStudent = new WindowEditStudent();
                        windowEditStudent.ShowDialog();
                        refreshGrid();
                        break;

                    case "Классы":


                        refreshGrid();
                        break;
                    case "Предметы":

                        refreshGrid();
                        break;

                    case "Учителя":
                        WindowEditEmployee windowEditEmployee = new WindowEditEmployee();
                        windowEditEmployee.ShowDialog();
                        refreshGrid();
                        break;

                    case "Отчеты":
                        break;
                    default:
                        WindowEditRating windowEditRating = new WindowEditRating();
                        windowEditRating.ShowDialog();
                        refreshGrid();
                        break;
                }
            }
            catch { }
        }
        private void DelBN_Click(object sender, RoutedEventArgs e)
        {

        }
        private void TotalCB_SelectionChanged(object sender, SelectionChangedEventArgs e) // вывод в грид предметов, для студента
        {
            //try
            //{

                ContentGrid.Children.Clear();
                SubName = TotalCB.SelectedItem.ToString();

                ContentGrid.Children.Add(new UCStudentLogs());
            

            //}
            //catch { }
        }
        private void MainListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (MainListView.Items[MainListView.SelectedIndex].ToString())
            {
                case "Студенты":
                    SelecStudent();
                    break;
                case "Классы":
                    SelectClass();
                    break;
                case "Предметы":
                    SelectLesson();
                    break;
                case "Учителя":
                    SelectEmployee();
                    break;
                case "Отчеты":
                    refreshGrid();

                    ContentGrid.Children.Add(new UCCharts());
                    break;
                default:
                    NameGroup = MainListView.Items[MainListView.SelectedIndex].ToString();

                    ContentGrid.Children.Clear();
                    ContentGrid.Children.Add(new UCLogs());
                    break;
            }
        }
        //--------------------------------------------------
        private string[] _labels;

        public SeriesCollection SeriesCollection { get; set; }

        public string[] Labels
        {
            get { return _labels; }
            set
            {
                _labels = value;
               // OnPropertyChanged("Labels");
            }
        }
        private void createLiveCharts()
        {
            SeriesCollection = new SeriesCollection
            {
                new OhlcSeries()
                {
                    Values = new ChartValues<OhlcPoint>
                    {
                        new OhlcPoint(32, 35, 30, 32),
                        new OhlcPoint(33, 38, 31, 37),
                        new OhlcPoint(35, 42, 30, 40),
                        new OhlcPoint(37, 40, 35, 38),
                        new OhlcPoint(35, 38, 32, 33)
                    }
                },
                new LineSeries
                {
                    Values = new ChartValues<double> {30, 32, 35, 30, 28},
                    Fill = Brushes.Transparent
                }
            };

            Labels = new[]
            {
                DateTime.Now.ToString("23.12"),
                DateTime.Now.AddDays(1).ToString("21.12"),
                DateTime.Now.AddDays(2).ToString("22.12"),
                DateTime.Now.AddDays(3).ToString("23.12"),
                DateTime.Now.AddDays(4).ToString("24.12"),
            };


        }

        //----------------------------------------------------------------------------------------
        private void start() // выбор уровня доступа, для пользователя
        {
            switch (Access)
            {
                case "High":
                    AccessHigh();
                    break;
                case "Middle":
                    AccessMiddle();
                    break;
                case "Low":
                    AccessLow();
                    break;
            }
        }
        private void AccessHigh() // уровень доступа для администратора
        {
            MainListView.Items.Add(new Button().Content = "Студенты");
            MainListView.Items.Add(new Button().Content = "Классы");
            MainListView.Items.Add(new Button().Content = "Предметы");
            MainListView.Items.Add(new Button().Content = "Учителя");
            MainListView.Items.Add(new Button().Content = "Отчеты");
            TotalCB.Visibility = Visibility.Collapsed;
            TotalLB.Visibility = Visibility.Collapsed;
        }
        private void AccessMiddle()   // уровень доступа для учителей\\\\\\(в комбо боксе предмет?)ОБСУДИТЬ КАК БУДЕТ ВЫГЛЯДИТЬ
        {
            DataSet User = new DataSet();
            string sql = "SELECT Name FROM GroupName";
            User = WorkWithBD.outPutdb(sql).Tables[0].DataSet;

            for (int i = 0; i < User.Tables[0].DefaultView.Count; i++)
            {
                MainListView.Items.Add(new Button().Content = User.Tables[0].DefaultView[i].Row[0].ToString());
            }
            sql = "SELECT Employee.SubjectsID, Subjects.SubName FROM Employee JOIN Subjects ON (Employee.SubjectsID = Subjects.SubjectsID) WHERE FIOEmployee = '" + NAME + "' ";
            User = WorkWithBD.outPutdb(sql).Tables[0].DataSet;
            SubjectID = User.Tables[0].DefaultView[0].Row[0].ToString();

            TotalLB.Content= MainWindow.NAME + "   " + User.Tables[0].DefaultView[0].Row[1].ToString();
            TotalCB.Visibility= Visibility.Collapsed;
        }
        private void AccessLow() // уровень доступа для учащихся\родителей
        {
            MainListView.Visibility = Visibility.Collapsed;
            DataSet User = new DataSet();
            
            string sql = "SELECT SubName FROM Lessons " +
                "JOIN Subjects ON (Lessons.SubjectsID=Subjects.SubjectsID) " +
                "WHERE Lessons.GroupNameID = " + GroupNameID + "";
            User = WorkWithBD.outPutdb(sql).Tables[0].DataSet;

            for (int i = 0; i < User.Tables[0].DefaultView.Count; i++)
            {
                TotalCB.Items.Add(User.Tables[0].DefaultView[i].Row[0].ToString());
            }

        }
        private void SelecStudent() // вывод всех учащихся (возможно удалить комбо бокс) возможно взять из старой версии динамич загрузку данных
        {
            TotalLB.Content = "Выберите Класс";
            TotalCB.Items.Clear();

            DataSet User = new DataSet();
            string sql = "SELECT Name FROM GroupName";
            User = WorkWithBD.outPutdb(sql).Tables[0].DataSet;

            TotalCB.Items.Add("Все");
            for (int i = 0; i < User.Tables[0].DefaultView.Count; i++)
            {
                TotalCB.Items.Add(User.Tables[0].DefaultView[i].Row[0].ToString());
            }

            ContentGrid.Children.Clear();
            ContentGrid.Children.Add(new UCStudent());
        }
        private void SelectLesson() // вывод всех предметов к классам
        {
            ContentGrid.Children.Clear();
            ContentGrid.Children.Add(new UCLessons());
        }
        private void SelectClass() 
        {
            ContentGrid.Children.Clear();
            ContentGrid.Children.Add(new UCClass());
        }
        private void SelectEmployee()
        {
            ContentGrid.Children.Clear();
            ContentGrid.Children.Add(new UCEmployee());
        }
    }
}
