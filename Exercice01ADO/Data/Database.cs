using Exercice01ADO.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Exercice01ADO.Data
{
    internal class DataBase
    {
        private static string chaine = "Data Source=(localdb)\\demo01ado; Integrated Security=True; Database=Contact";
        public static SqlConnection Connection = new SqlConnection(chaine);









    }
}
