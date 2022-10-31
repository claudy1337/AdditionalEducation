using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

namespace AdditionalEducation.Pages.AdminControl
{
    /// <summary>
    /// Логика взаимодействия для ControlTeacherPage.xaml
    /// </summary>
    public partial class ControlTeacherPage : Page
    {
        public static Teacher CurretTeacher;
        byte[] image;
        bool isActive = false;
        bool imgClick = false;
        public ControlTeacherPage(Teacher currnetTeacher)
        {
            CurretTeacher = currnetTeacher; 
            InitializeComponent();
            if (CurretTeacher.idUser == null || CurretTeacher.idTypeTeacher == null)
            {
                isNullData();
            }
            else
            {
                BindingData();
            }
            cbTypeTeacher.ItemsSource = DBConnection.connect.TypeTeacher.ToList();
            
        }
        private void BindingData()
        {
            this.DataContext = CurretTeacher;
            txtEditOrAdd.Text = "Edit Teacher";
            btnEditOrAdd.Content = "Edit";
            cbTypeTeacher.SelectedIndex = CurretTeacher.TypeTeacher.id;
            if (CurretTeacher.isActive == true)
                CBIsActice.IsChecked = true;
        }
        private void isNullData()
        {
            txtEditOrAdd.Text = "Add Teacher";
            btnEditOrAdd.Content = "Add";
            string imagePath = "/Resources/default_user.png";
            imgTeacher.Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
        }
        private void btnEditOrAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtPatronymic.Text)
                ||string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("заполните все данные");
                return;
            }
            else
            {
                var selectType = cbTypeTeacher.SelectedIndex;
                if (CurretTeacher.idUser == null || CurretTeacher.idTypeTeacher == null)
                {
                    DBMethodsFromUser.AddAuth(txtLogin.Text, txtPassword.Text);
                    DBMethodsFromUser.AddUser(image, txtName.Text, txtSurname.Text, txtPatronymic.Text);
                    DBMethodsFromTeacher.AddTeacher(selectType, isActive);
                    Refresh();
                }
                else
                {
                    DBMethodsFromUser.EditImageUser(CurretTeacher.User);
                    DBMethodsFromUser.EditAccount(CurretTeacher.User,txtName.Text, txtSurname.Text, txtPatronymic.Text);
                    DBMethodsFromTeacher.EditTeacher(CurretTeacher, selectType, isActive);
                    Refresh();

                }
            }
        }
        private void imgTeacher_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            imgClick = true;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FilterIndex = 1;
            if (ofd.ShowDialog() == true)
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(ofd.FileName);
                bitmapImage.EndInit();
                imgTeacher.Source = bitmapImage;
                image = File.ReadAllBytes(ofd.FileName);
            }
        }
        private void Refresh()
        {
            NavigationService.Navigate(new TeacherPage());
        }

        private void cbTypeTeacher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void CBIsActice_Checked(object sender, RoutedEventArgs e)
        {
            CBIsActice.IsChecked = true;
            isActive = true;
        }
    }
}
