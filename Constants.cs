using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Using_Databases
{
    public class Constants
    {
        public const string DATABASE_FILE = "LabDB.db3";

        public static string DatabasePath =>
            Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, DATABASE_FILE);

        public Constants() { }
    }
}
