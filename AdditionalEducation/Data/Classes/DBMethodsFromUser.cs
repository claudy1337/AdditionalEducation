using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdditionalEducation.Data.Model;

namespace AdditionalEducation.Data.Classes
{
    internal class DBMethodsFromUser
    {
        public static ObservableCollection<User> GetUsers()
        {
            return new ObservableCollection<User>(DBConnection.connect.User);
        }
        public static IEnumerable<User> GetUser()
        {
            return GetUsers().ToList();
        }
        public static bool IsCorrectUser(string login, string password)
        {
            ObservableCollection<User> users = new ObservableCollection<User>(DBConnection.connect.User);
            var currentUser = users.Where(u => u.Authorization.Password == password && u.Authorization.Login == login).FirstOrDefault();
            return currentUser != null;
        }
        public static bool isRole(string login)
        {
            ObservableCollection<User> users = new ObservableCollection<User>(DBConnection.connect.User);
            var isAdmin = users.Where(u => u.Authorization.Login == login && u.RoleID == 1);
            return isAdmin != null;
        }
    }
}
