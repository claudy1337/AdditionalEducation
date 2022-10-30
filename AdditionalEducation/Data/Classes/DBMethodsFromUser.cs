using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdditionalEducation.Data.Model;
using HandyControl.Controls;
using Microsoft.Win32;

namespace AdditionalEducation.Data.Classes
{
    internal class DBMethodsFromUser
    {
        public static User CurrentUser;
        public static ObservableCollection<User> GetUsers()
        {
            return new ObservableCollection<User>(DBConnection.connect.User);
        }
        public static ObservableCollection<Authorization> GetAuthorizations()
        {
            return new ObservableCollection<Authorization>(DBConnection.connect.Authorization);
        }
        public static User GetUser(string login, string password)
        {
            return GetUsers().FirstOrDefault(u => u.Authorization.Login == login && u.Authorization.Password == password);
        }
        public static Authorization GetAuthorization(string login, string password)
        {
            return GetAuthorizations().FirstOrDefault(a=>a.Login == login && a.Password == password);
        }
        public static bool IsCorrectUser(string login, string password)
        {
            ObservableCollection<User> users = new ObservableCollection<User>(DBConnection.connect.User);
            var currentUser = users.Where(u => u.Authorization.Password == password && u.Authorization.Login == login).FirstOrDefault();
            CurrentUser = currentUser;
            return currentUser != null;
        }
        public static bool GetAdminRole(string login)
        {
            ObservableCollection<User> admin = new ObservableCollection<User>(DBConnection.connect.User);
            var currentAdmin = admin.Where(a=>a.Authorization.Login == login && a.RoleID == 1).FirstOrDefault();
            return currentAdmin != null;
        }
        public static void EditImageUser(User oldUser)
        {
            var getuser = GetUser(oldUser.Authorization.Login, oldUser.Authorization.Password);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                getuser.Image = File.ReadAllBytes(openFileDialog.FileName);
            }
            DBConnection.connect.SaveChanges();
        }
        public static void EditAccount(User user, string name, string surname, string patronymic)
        {
            var getUser = GetUser(user.Authorization.Login, user.Authorization.Password);
            if (getUser != null)
            {
                if (GetAdminRole(getUser.Authorization.Login) == true)
                {
                    getUser.Name = name;
                    getUser.Surname = surname;
                    getUser.Patronymic = patronymic;
                }
                DBConnection.connect.SaveChanges();
                MessageBox.Show("данные успешно поменялись");
            }
        }
        
    }
}
