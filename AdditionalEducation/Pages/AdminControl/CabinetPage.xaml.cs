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
    /// Логика взаимодействия для CabinetPage.xaml
    /// </summary>
    public partial class CabinetPage : Page
    {
        bool editData = false;
        bool isState = false;
        public CabinetPage()
        {
            InitializeComponent();
            BindingData();
        }
        private void BindingData()
        {
            lstvCabinet.ItemsSource = DBConnection.connect.Cabinet.ToList();
        }
        private void CBState_Checked(object sender, RoutedEventArgs e)
        {
            CBState.IsChecked = true;
            isState = true;
        }

        private void btnAddCabinet_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("заполните все поля");
            }
            else
            {
                if (editData == true)
                {
                    var selectCabinet = lstvCabinet.SelectedItem as Cabinet;
                    DBMethodsFromCabinet.EditCabinet(selectCabinet, isState);
                    NavigationService.Navigate(new CabinetPage());
                }
                else
                {
                    DBMethodsFromCabinet.AddCabinet(txtTitle.Text, isState);
                    NavigationService.Navigate(new CabinetPage());
                }
            }
        }

        private void lstvCabinet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            editData = true;
            var selectCabinet = lstvCabinet.SelectedItem as Cabinet;
            this.DataContext = selectCabinet;
            CBState.IsChecked = selectCabinet.State;
            
        }
    }
}
