using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
using Wpf_журнал_учащихся_школы.UControl;
using Wpf_журнал_учащихся_школы.WAdd;
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
        private void createLiveCharts()//create chart
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
        private void start() // select lvl access
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
        private void AccessHigh() // Load UserControl with Access - High
        {
            GridListVew.Children.Add(new UCAdmin());
        }
        private void AccessMiddle()   // Load UserControl with access for Teacher 
        {
            GridListVew.Children.Add(new UCTeacher());
        }
        private void AccessLow() // Load UserControl with access for Student or Parents(MainUC)
        {
            GridListVew.Children.Add(new MainUC.UCStudent());
        }

        private void DataGridTotal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
