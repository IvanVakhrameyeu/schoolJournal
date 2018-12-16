using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для UCCharts.xaml
    /// </summary>
    /// 

        /*
         * если делать для класса, то запихивать фамилии (выбирать предмет) и дату
         * если делать для чувака, то выбирать предмет и дату
         * если делать по общему, то считать средний для каждого студента по предмету, и даты там не будет
         * 
         * 
         * если выбрать все предметы, то так нельзя считать
         * */
    public partial class UCCharts : UserControl
    {
        public UCCharts()
        {
            InitializeComponent();
            start();
        }
        private void addSubjects() // добавление предметов в комбо бокс
        {
            DataSet User = new DataSet();
            string sql = "EXEC SelectAllSubject";
            User = WorkWithBD.outPutdb(sql).Tables[0].DataSet;
            //SubjectCB.Items.Add("Все"); 
            for (int i = 0; i < User.Tables[0].DefaultView.Count; i++)
            {
                SubjectCB.Items.Add(User.Tables[0].DefaultView[i].Row[0].ToString());
            }
        }
        private void addGroup() //add groupName in ComboBox
        {
            GroupCB.Items.Clear();

            DataSet User = new DataSet();
            User = WorkWithBD.outPutdb("SELECT GroupName.Name FROM Lessons " +
                "JOIN Subjects ON (Lessons.SubjectsID = Subjects.SubjectsID) " +
                "JOIN GroupName ON (Lessons.GroupNameID = GroupName.GroupNameID) " +
                "Where Subjects.SubName = '" + SubjectCB.SelectedItem.ToString() + "'");
           // GroupCB.Items.Add("Все");
            for (int i = 0; i < User.Tables[0].DefaultView.Count; i++)
            {
                GroupCB.Items.Add(User.Tables[0].DefaultView[i].Row[0].ToString());
            }
        }
        private void addFIO()
        {
            FIOCB.Items.Clear();
            DataSet User = new DataSet();
            User = WorkWithBD.outPutdb("SELECT GroupNameID FROM GroupName Where Name = '" + GroupCB.SelectedItem.ToString() + "'");
            string id = User.Tables[0].DefaultView[0].Row[0].ToString();
            string sql = "SELECT FIO FROM Student WHERE GroupNameID = '" + id + "'";

            User = WorkWithBD.outPutdb(sql).Tables[0].DataSet;
            for (int i = 0; i < User.Tables[0].DefaultView.Count; i++)
            {
                FIOCB.Items.Add(User.Tables[0].DefaultView[i].Row[0].ToString());
            }
        }
        private void start()
        {
            addSubjects(); // добавление предметов в комбо бокс   
        }
        private bool checkDate() // проверка на корректность даты
        {
            if (Convert.ToDateTime(DayFor.Text) > Convert.ToDateTime(DayTo.Text))
            {
                return false;
            }
            else return true;
        }
        private void createChartsSubjects() // вывод графика, когда выбран только какой то предмет
        {
            if (!checkDate())
            {
                MessageBox.Show("Введите корректную дату");
                return;
            }
            SeriesCollection = new SeriesCollection();

            DataSet dataSetID = new DataSet();
            dataSetID = WorkWithBD.outPutdb("SELECT Subjects.SubjectsID FROM Subjects Where SubName = '" + SubjectCB.SelectedItem.ToString() + "'");

            string idSubject = dataSetID.Tables[0].DefaultView[0].Row[0].ToString();

            for (int i = 0; i < GroupCB.Items.Count; i++)
            {
                ChartValues<int> ts = new ChartValues<int>(); // массив куда занесем оценки

                DataSet User = new DataSet();
                User = WorkWithBD.outPutdb("SELECT GroupNameID FROM GroupName Where Name = '" + GroupCB.Items[i].ToString() + "'");
                string id = User.Tables[0].DefaultView[0].Row[0].ToString();

                User = WorkWithBD.outPutdb("SELECT Logs.Rating FROM Logs " +
                    "JOIN Student ON (Logs.StudentID = Student.StudentID) " +
                    "Where Student.GroupNameID = " + id + " " +
                    "AND Logs.Data > '" + Convert.ToDateTime(DayFor.Text) + "' AND Logs.Data < '" + Convert.ToDateTime(DayTo.Text) + "'");

                for (int j = 0; j < ((Convert.ToDateTime(DayTo.Text) - Convert.ToDateTime(DayFor.Text)).Days); j++) // считать среднии оценки по группе в даный день
                {
                    try
                    {
                        DataSet UserBuf = new DataSet();
                        UserBuf = WorkWithBD.outPutdb("SELECT Avg(Logs.Rating) FROM Logs " +
                            "JOIN Student ON(Logs.StudentID = Student.StudentID) " +
                            "Where Student.GroupNameID = "+ id + " AND " +
                            "Logs.Data = '"+ Convert.ToDateTime(Convert.ToDateTime(DayFor.Text).AddDays(j)).ToString() + "' " +
                            "AND Logs.SubjectsID = " + idSubject);
                        
                        ts.Add(Convert.ToInt32(UserBuf.Tables[0].DefaultView[0].Row[0].ToString()));
                    }
                    catch {  }
                }

                SeriesCollection.Add(new LineSeries
                {
                    Title = GroupCB.Items[i].ToString(),                    
                    Values = ts, // массив оценок
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 5
                });
            }            
            Labels = new List<string>();
           
            for (int i = 0; i < (Convert.ToDateTime(DayTo.Text) - Convert.ToDateTime(DayFor.Text)).Days; i++)
            {
                Labels.Add((Convert.ToDateTime(DayFor.Text).AddDays(i)).ToString().Split(' ')[0]);
            }            
            YFormatter = value => value.ToString("C");            

            DataContext = this;
        }
        private void clearCharts()
        {
            try
            {
                if (Labels.Count != 0)
                {
                    Labels.Clear();
                    SeriesCollection.Clear();
                }
            }
            catch { }
        }
        private void createChartsSubjectsGroup()// вывод, когда выбран предмет и группа
        {
            if (!checkDate())
            {
                MessageBox.Show("Введите корректную дату");
                return;
            }
            SeriesCollection = new SeriesCollection();

            DataSet dataSetID = new DataSet();
            dataSetID = WorkWithBD.outPutdb("SELECT Subjects.SubjectsID FROM Subjects Where SubName = '" + SubjectCB.SelectedItem.ToString() + "'");

            string idSubject = dataSetID.Tables[0].DefaultView[0].Row[0].ToString();

            for (int i = 0; i < FIOCB.Items.Count; i++)
            {
                ChartValues<int> ts = new ChartValues<int>(); // массив куда занесем оценки

                DataSet User = new DataSet();
                User = WorkWithBD.outPutdb("SELECT GroupNameID FROM GroupName Where Name = '" + GroupCB.Items[i].ToString() + "'");
                string id = User.Tables[0].DefaultView[0].Row[0].ToString();

                User = WorkWithBD.outPutdb("SELECT Logs.Rating FROM Logs " +
                    "JOIN Student ON (Logs.StudentID = Student.StudentID) " +
                    "Where Student.GroupNameID = " + id + " " +
                    "AND Logs.Data > '" + Convert.ToDateTime(DayFor.Text) + "' AND Logs.Data < '" + Convert.ToDateTime(DayTo.Text) + "'");

                dataSetID = WorkWithBD.outPutdb("SELECT Student.StudentID FROM Student Where FIO = '" + FIOCB.Items[i].ToString() + "'");

                string idStudent = dataSetID.Tables[0].DefaultView[0].Row[0].ToString();

                for (int j = 0; j < ((Convert.ToDateTime(DayTo.Text) - Convert.ToDateTime(DayFor.Text)).Days); j++) // считать среднии оценки по группе в даный день
                {
                    try
                    {
                        DataSet UserBuf = new DataSet();
                        UserBuf = WorkWithBD.outPutdb("SELECT Logs.Rating FROM Logs " +
                            "JOIN Student ON(Logs.StudentID = Student.StudentID) " +
                            "Where Student.GroupNameID = " + id + " AND " +
                            "Logs.Data = '" + Convert.ToDateTime(Convert.ToDateTime(DayFor.Text).AddDays(j)).ToString() + "' " +
                            "AND Logs.SubjectsID = " + idSubject +" " +
                            "AND Logs.StudentID = "+ idStudent);

                        ts.Add(Convert.ToInt32(UserBuf.Tables[0].DefaultView[0].Row[0].ToString()));
                    }
                    catch { }
                }

                SeriesCollection.Add(new LineSeries
                {
                    Title = FIOCB.Items[i].ToString(),
                    Values = ts, // массив оценок
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 5
                });
            }
            Labels = new List<string>();

            for (int i = 0; i < (Convert.ToDateTime(DayTo.Text) - Convert.ToDateTime(DayFor.Text)).Days; i++)
            {
                Labels.Add((Convert.ToDateTime(DayFor.Text).AddDays(i)).ToString().Split(' ')[0]);
            }
            YFormatter = value => value.ToString("C");

            DataContext = this;
        }
        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get; set; }
        public Func<int, string> YFormatter { get; set; }
        private void SubjectCB_SelectionChanged(object sender, SelectionChangedEventArgs e) // при изменении кб предмета, изменяются группы
        {
            try
            {
                addGroup();
            }
            catch { }
        }

        private void GroupCB_SelectionChanged(object sender, SelectionChangedEventArgs e) // при изменении группы, изменяются студенты
        {
            try
            {
                addFIO(); // добавление фамилий
            }
            catch
            {
              //  MessageBox.Show(ex.Message);
            }
        }

        private void FIOCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ApplayOnClick(object sender, RoutedEventArgs e)
        {
            //clearCharts();
            var current= SubjectCB?.Text ?? "";
            int res = 0;
            if (current != "")
            {
                res = 2;
                if((GroupCB?.Text ?? "")!="" & GroupCB.Text!="Все")
                {
                    res = 1;
                }
            }
            switch (res)
            {
                case 0: MessageBox.Show("Выберите предмет");
                    break;
                case 1:
                    createChartsSubjectsGroup();
                    break;
                case 2:
                    createChartsSubjects();
                    break;
                default: break;
            }
        }
    }
}
