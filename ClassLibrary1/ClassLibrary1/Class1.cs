using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient

namespace ClassLibrary1
{ 

        public class dllTest
        {
            public static string fn_Add()
            {
                return "Hi";
            }
            public static string fn_Addd()
            {
                return "By";
            }
        public class Connection
        {
            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=demo;port=3305;Uid=root;Pwd=root;");
        }
    } 
}
