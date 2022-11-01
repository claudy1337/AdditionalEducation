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
using AdditionalEducation.Data.Model;
using AdditionalEducation.Data.Classes;
using MaterialDesignThemes.Wpf;

namespace AdditionalEducation.Pages.AdminControl
{
    /// <summary>
    /// Логика взаимодействия для TimetablePage.xaml
    /// </summary>
    public partial class TimetablePage : Page
    {
        public TimetablePage()
        {
            InitializeComponent();
            BindingData();
        }

        private void btnAddTime_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BindingData()
        {
            CBHour.ItemsSource = DBConnection.connect.Time.ToList();
            CBMinutes.ItemsSource = DBConnection.connect.Time.ToList();
            CBDayOfWeek.ItemsSource = DBConnection.connect.DayOfWeek.ToList();
        }
    }
}
