﻿using System;
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
    /// Логика взаимодействия для TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {
        public TeacherPage()
        {
            InitializeComponent();
            BindingData();
        }
        private void BindingData()
        {
            lstvTeacher.ItemsSource = DBConnection.connect.Teacher.ToList();
            cbTypeTeacher.ItemsSource = DBConnection.connect.TypeTeacher.ToList();
        }

        private void lstvTeacher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectTeacher = lstvTeacher.SelectedItem as Teacher;
            NavigationService.Navigate(new ControlTeacherPage(selectTeacher));
        }

        private void cbTypeTeacher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Teacher teacher = new Teacher();
            NavigationService.Navigate(new ControlTeacherPage(teacher));
        }
    }
}
