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
using AdditionalEducation.Data.Classes;
using AdditionalEducation.Data.Model;

namespace AdditionalEducation.Pages.TeacherControl
{
    /// <summary>
    /// Логика взаимодействия для TimeTablePage.xaml
    /// </summary>
    public partial class TimeTablePage : Page
    {
        public static User User;
        public TimeTablePage(User user)
        {
            User = user;
            InitializeComponent();
            lstvTimeTable.ItemsSource = DBConnection.connect.Section_Teacher.Where(t=>t.Teacher.User.ID == User.ID).ToList();
        }
    }
}
