using Exercice02Commande.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

using System.Data.SqlClient;

namespace Exercice02Commande.Data
{
    internal class DataBase
    {
        private static string chaine = "Data Source=(localdb)\\demo01ado; Integrated Security=True; Database=Commande";
        public static SqlConnection Connection = new SqlConnection(chaine);

        

        

        

        

        

        

        

        
    }
}
