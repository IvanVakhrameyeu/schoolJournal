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
    /// Логика взаимодействия для UCTeacher.xaml
    /// </summary>
    public partial class UCTeacher : UserControl
    {
        public UCTeacher()
        {
            InitializeComponent();
            start();
        }
        private void start()
        {

            DataSet User = new DataSet();
            string sql = "SELECT Name FROM GroupName";
            User = WorkWithBD.outPutdb(sql).Tables[0].DataSet;

            for (int i = 0; i < User.Tables[0].DefaultView.Count; i++)
            {
                MainListView.Items.Add(new TextBlock()
                {
                    Text = User.Tables[0].DefaultView[i].Row[0].ToString(),
                    VerticalAlignment = VerticalAlignment.Center,
                    Height = 60,
                    FontSize = 16,
                    TextWrapping = TextWrapping.Wrap
                    
                });
            }
            sql = "SELECT Employee.SubjectsID, Subjects.SubName FROM Employee JOIN Subjects ON (Employee.SubjectsID = Subjects.SubjectsID) WHERE FIOEmployee = '" + MainWindow.NAME + "' ";
            User = WorkWithBD.outPutdb(sql).Tables[0].DataSet;
            MainWindow.SubjectID = User.Tables[0].DefaultView[0].Row[0].ToString();
            
        }
        private void MainListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((MainListView?.Items?[MainListView.SelectedIndex].ToString()?? "") !="")
            {
                MainWindow.NameGroup = ((TextBlock)MainListView.Items[MainListView.SelectedIndex]).Text;
                ContentGrid.Children.Clear();
                ContentGrid.Children.Add(new UCLogs());
            }            
        }
        private void AddBN_Click(object sender, RoutedEventArgs e) // add something
        {
            try
            {
                if ((MainListView?.Items?[MainListView.SelectedIndex].ToString() ?? "") != "")
                {
                    WindowAddRating windowAddRating = new WindowAddRating();
                    windowAddRating.ShowDialog();

                    ContentGrid.Children.Clear();
                    ContentGrid.Children.Add(new UCLogs());
                }
            }
            catch { }
        }
        private void EditBN_Click(object sender, RoutedEventArgs e) // change something
        {
            try
            {
                if ((MainListView?.Items?[MainListView.SelectedIndex].ToString() ?? "") != "")
                {
                    WindowEditRating windowEditRating = new WindowEditRating();
                    windowEditRating.ShowDialog();
                    ContentGrid.Children.Clear();
                    ContentGrid.Children.Add(new UCLogs());
                }
            }
            catch { }
        }
        private void DelBN_Click(object sender, RoutedEventArgs e) // delete something
        {

        }
    }
}
