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
using AdditionalEducation.Pages.AdminControl;

namespace AdditionalEducation.Pages
{
    /// <summary>
    /// Логика взаимодействия для ControlPage.xaml
    /// </summary>
    public partial class ControlPage : Page
    {
        public static User CurrentUser;
        public ControlPage(User curentUser)
        {
            CurrentUser = curentUser;
            InitializeComponent();
        }
        private void ColorSet()
        {
            txtAddClass.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(144, 130, 130));
            txtAddSection.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(144, 130, 130));
            txtAddTeacher.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(144, 130, 130));
            txtAddTimetable.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(144, 130, 130));
        }

        private void txtAddTeacher_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ColorSet();
            fContainerControl.Navigate(new TeacherPage());
            txtAddTeacher.Foreground = Brushes.White;
        }

        private void txtAddClass_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ColorSet();
            fContainerControl.Navigate(new ClassPage());
            txtAddClass.Foreground = Brushes.White;
        }

        private void txtAddTimetable_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ColorSet();
            fContainerControl.Navigate(new TimetablePage());
            txtAddTimetable.Foreground = Brushes.White;
        }

        private void txtAddSection_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ColorSet();
            fContainerControl.Navigate(new SectionPage());
            txtAddSection.Foreground = Brushes.White;
        }
    }
}
