﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdditionalEducation.Data.Model;
using AdditionalEducation.Data.Classes;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Data.Common;
using System.Windows.Controls.Primitives;

namespace AdditionalEducation.Data.Classes
{
    internal class DBMethodsFromSectionTeacher
    {
        public static ObservableCollection<Section_Teacher> GetTeacher_Sections()
        {
            return new ObservableCollection<Section_Teacher>(DBConnection.connect.Section_Teacher);
        }
        public static Section_Teacher GetTeacher_Section(int section, int teacher)
        {
            return GetTeacher_Sections().FirstOrDefault(t=>t.Teacher.ID == teacher && t.Section.ID == section);
        }
        public static void EditTeacherFromSection(int section, int teacher, bool status)
        {
            var getTeacherSection = GetTeacher_Section(section, teacher);
            if (getTeacherSection != null)
            {
                getTeacherSection.isActive = status;
                DBConnection.connect.SaveChanges();
            }
        }
        public static void AddTeacherFromSection(int section, int teacher)
        {
            Section_Teacher teacher_Section = new Section_Teacher
            {
                idSection = section,
                idTeacher = teacher,
                isActive = true
            };
            DBConnection.connect.Section_Teacher.Add(teacher_Section);
            DBConnection.connect.SaveChanges();
        }

    }
}
