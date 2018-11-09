﻿using System;
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

namespace Wpf_журнал_учащихся_школы
{
    /// <summary>
    /// Логика взаимодействия для WindowAddEmployee.xaml
    /// </summary>
    public partial class WindowAddEmployee : Window
    {
        public WindowAddEmployee()
        {
            InitializeComponent();
            start();
        }
        private void start()
        {
            SexCB.Items.Add("М");
            SexCB.Items.Add("Ж");

            DataSet User = new DataSet();
            string sql = "SELECT SubName FROM Subjects";
            User = WorkWithBD.outPutdb(sql).Tables[0].DataSet;

            for (int i = 0; i < User.Tables[0].DefaultView.Count; i++)
            {
                SubjectCB.Items.Add(User.Tables[0].DefaultView[i].Row[0].ToString());
            }                        
        }

        private void SubjectCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void AddBN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataSet dataSet = new DataSet();
                string sql = "INSERT INTO Employee (SubjectsID, FIOEmployee, Sex, DOB, Tel) " +
           "VALUES (@SubjectsID, @FIOEmployee, @Sex, @DOB, @Tel)";

                WorkWithBD.inputEmployee(sql, (SubjectCB.SelectedIndex + 1).ToString(), FIOTB.Text, SexCB.SelectedItem.ToString(), DayB.Text, TelTB.Text);

                Close();
            }
            catch { MessageBox.Show("Введите корректные данные"); }
        }
        private void CancelBN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void SexCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
