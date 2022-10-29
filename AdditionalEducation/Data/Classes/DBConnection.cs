using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdditionalEducation.Data.Model;
using System.Threading.Tasks;

namespace AdditionalEducation.Data.Classes
{
    internal class DBConnection
    {
        public static schoolEntities connect = new schoolEntities();
    }
}
