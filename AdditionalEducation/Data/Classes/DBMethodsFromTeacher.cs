using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdditionalEducation.Data.Classes;
using AdditionalEducation.Data.Model;
using HandyControl.Controls;

namespace AdditionalEducation.Data.Classes
{
    internal class DBMethodsFromTeacher
    {
        public static Teacher CurrentTeacher;
        public static ObservableCollection<Teacher> GetTeachers()
        {
            return new ObservableCollection<Teacher>(DBConnection.connect.Teacher);
        }
        public static void AddTeacher(int typeTeacher, bool isActive)
        {
            var getAdmin = DBMethodsFromUser.GetAdminRole(DBMethodsFromUser.CurrentUser.Authorization.Login);
            if (DBMethodsFromUser.CurrentUser != null && getAdmin == false)
            {
                Teacher teacher = new Teacher
                {
                    idUser = DBMethodsFromUser.CurrentUser.ID,
                    idTypeTeacher = typeTeacher,
                    isActive = isActive
                };
                CurrentTeacher = teacher;
                MessageBox.Show("учитель добавлен");
                DBConnection.connect.Teacher.Add(teacher);
                DBConnection.connect.SaveChanges();
            }
            else
            {
                MessageBox.Show("данные уже существуют");
                return;
            }
        }

    }
}
