using System;
using System.Collections.Generic;
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
using Wpf_журнал_учащихся_школы.Reports;

namespace Wpf_журнал_учащихся_школы.UControl
{
    /// <summary>
    /// Логика взаимодействия для UCReportsTeacher.xaml
    /// </summary>
    public partial class UCReportsTeacher : UserControl
    {
        public UCReportsTeacher()
        {
            InitializeComponent();
        }
        private void ReportClass_Click(object sender, RoutedEventArgs e)
        {
            WReportClass wReport = new WReportClass();
            wReport.ShowDialog();
        }
    }
}
