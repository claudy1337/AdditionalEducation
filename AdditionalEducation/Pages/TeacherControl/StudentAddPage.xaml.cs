using AdditionalEducation.Data.Model;
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

namespace AdditionalEducation.Pages.TeacherControl
{
    /// <summary>
    /// Логика взаимодействия для StudentAddPage.xaml
    /// </summary>
    public partial class StudentAddPage : Page
    {
        public StudentAddPage()
        {
            InitializeComponent();
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClassNumber.Text) || string.IsNullOrWhiteSpace(txtSurname.Text) || string.IsNullOrWhiteSpace(txtPatronymic.Text))
            {
                MessageBox.Show("заполните все поля");
            }
            else
            {
                
            }
        }
    }
}
