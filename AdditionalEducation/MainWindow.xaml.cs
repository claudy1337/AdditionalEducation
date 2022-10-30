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
using AdditionalEducation.Pages;
using AdditionalEducation.Windws;

namespace AdditionalEducation
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static User CurrentUser;
        public MainWindow(User currentUser)
        {
            CurrentUser = currentUser;
            InitializeComponent();
            if (DBMethodsFromUser.GetAdminRole(CurrentUser.Authorization.Login) == false)
            {
                txtCreate.Visibility = Visibility.Hidden;
                txtStatistics.Visibility = Visibility.Hidden;
            }
            txtWelcome.Text = $"Welcome: {currentUser.Role.Title} " + CurrentUser.Name;
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                    this.DragMove();
            }
            catch (System.InvalidOperationException)
            {
                return;
            }
        }

        private void btnMinus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void txtExit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Close();
        }
        private void ColorSet()
        {
            txtAccount.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(144, 130, 130));
            txtExit.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(144, 130, 130));

            txtStatistics.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(144, 130, 130));
            txtCreate.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(144, 130, 130));

            txtSection.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(144, 130, 130));
            txtStudent.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(144, 130, 130));
            
        }

        private void txtAccount_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ColorSet();
            fContainer.Navigate(new Account(CurrentUser));
            txtAccount.Foreground = Brushes.White;
        }

        private void txtExit_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Close();
        }

        private void txtSection_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ColorSet();

            txtSection.Foreground = Brushes.White;
        }

        private void txtStatistics_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ColorSet();

            txtStatistics.Foreground = Brushes.White;
        }

        private void txtCreate_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ColorSet();
            fContainer.Navigate(new ControlPage(CurrentUser));
            txtCreate.Foreground = Brushes.White;
        }

        private void txtStudent_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ColorSet();

            txtStudent.Foreground = Brushes.White;
        }
    }
}
