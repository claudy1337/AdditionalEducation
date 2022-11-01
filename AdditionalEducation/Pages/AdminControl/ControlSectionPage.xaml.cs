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

namespace AdditionalEducation.Pages.AdminControl
{
    /// <summary>
    /// Логика взаимодействия для ControlSectionPage.xaml
    /// </summary>
    public partial class ControlSectionPage : Page
    {
        public static Data.Model.Section Section;
        byte[] image;
        public ControlSectionPage(Data.Model.Section section)
        {
            Section = section;
            InitializeComponent();
            if (Section.isActive == null || Section.MaxCountOfVisitors == null || Section.Title == null)
            {
                isNullBindingData();
            }
            else
            {
                BindingData();
            }
        }
        private void BindingData()
        {
            txtEditOrAdd.Text = "Edit Section";
            btnEditOrAdd.Content = "Edit";
            this.DataContext = Section;
            if (Section.isActive == true)
            {
                CBIsActice.IsChecked = true;
            }
        }
        private void isNullBindingData()
        {
            txtEditOrAdd.Text = "Add Section";
            btnEditOrAdd.Content = "Add";
            string imagePath = "/Resources/default_section.png/";
            imgSection.Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
        }

        private void btnEditOrAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CBIsActice_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
