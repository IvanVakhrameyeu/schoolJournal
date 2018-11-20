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
using Wpf_журнал_учащихся_школы.MainUC;

namespace Wpf_журнал_учащихся_школы
{
    /// <summary>
    /// Логика взаимодействия для WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        public WindowLogin()
        {
            InitializeComponent();
        }

        private void AddBN_Click(object sender, RoutedEventArgs e) // поставить ифы на сравнение, если учитель, совпадение имени учителя в комбобоксе и логина
        {
            //try
            //{
            DataSet User = new DataSet();
            string sql = "SELECT [Login], [Password], Users.EmployeeID, Users.Access, Users.StudentID, " +
                 "Employee.FIOEmployee, Student.FIO, GroupName.Name, GroupName.GroupNameID " +
                "FROM Users " +
            "FULL OUTER JOIN Employee ON (Users.EmployeeID=Employee.EmployeeID) " +
            "FULL OUTER JOIN Student ON (Users.StudentID=Student.StudentID) " +
            "FULL OUTER JOIN GroupName ON (Student.GroupNameID=GroupName.GroupNameID)";
            User = WorkWithBD.outPutdb(sql).Tables[0].DataSet;
           

            for (int i = 0; i < User.Tables[0].DefaultView.Count; i++)
            {
                if (LoginTB.Text == User.Tables[0].DefaultView[i].Row[0].ToString() && PasswordTB.Password.ToString() == User.Tables[0].DefaultView[i].Row[1].ToString())
                {
                    MainWindow.Access = User.Tables[0].DefaultView[i].Row[3].ToString();
                    MainWindow.NAME = User.Tables[0].DefaultView[i].Row[5].ToString();
                    MainWindow.GroupNameID= User.Tables[0].DefaultView[i].Row[8].ToString();
                    MainWindow.StudentID= User.Tables[0].DefaultView[i].Row[4].ToString();
                    Close();
                 
                }
            }
            if (MainWindow.Access == "")
                MessageBox.Show("Неверный логин или пароль.");
            //}
            //catch { MessageBox.Show("Заполните поля"); }
        }

        private void CancelBN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }        
    }
}