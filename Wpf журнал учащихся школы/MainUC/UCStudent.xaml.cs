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

namespace Wpf_журнал_учащихся_школы.MainUC
{
    /// <summary>
    /// Логика взаимодействия для UCStudent.xaml
    /// </summary>
    public partial class UCStudent : UserControl
    {
        public UCStudent()
        {
            InitializeComponent();
            start();
        }
        private void start()
        {
            DataSet User = new DataSet();

            string sql = "SELECT SubName FROM Lessons " +
                "JOIN Subjects ON (Lessons.SubjectsID=Subjects.SubjectsID) " +
                "WHERE Lessons.GroupNameID = " + MainWindow.GroupNameID + "";
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
        }
        private void MainListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((MainListView?.Items?[MainListView.SelectedIndex].ToString() ?? "") != "")
            {
                MainWindow.SubName = ((TextBlock)MainListView.Items[MainListView.SelectedIndex]).Text;
                ContentGrid.Children.Clear();
                ContentGrid.Children.Add(new UCStudentLogs());
            }
        }
    }
}
