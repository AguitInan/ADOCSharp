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

        public static bool AjouterEtudiant(Etudiant p)
        {
            bool ok = false;
            SqlCommand command = new SqlCommand("INSERT INTO etudiant(nom,prenom,numeroclasse,dateDiplome) values (@Nom,@Prenom,@NumeroClasse,@DateDiplome)", Connection);
            command.Parameters.Add(new SqlParameter("@Nom", System.Data.SqlDbType.VarChar) { Value = p.Nom });
            command.Parameters.Add(new SqlParameter("@Prenom", System.Data.SqlDbType.VarChar) { Value = p.Prenom });
            command.Parameters.Add(new SqlParameter("@NumeroClasse", System.Data.SqlDbType.VarChar) { Value = p.NumeroClasse });
            command.Parameters.Add(new SqlParameter("@DateDiplome", System.Data.SqlDbType.VarChar) { Value = p.DateDiplome });
            Connection.Open();
            int nbLigne = command.ExecuteNonQuery();
            command.Dispose();
            Connection.Close();
            if (nbLigne > 0)
                return ok = true;
            else
                return ok = false;
        }







    }
}
