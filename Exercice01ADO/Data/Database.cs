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

        public static Etudiant TrouverEtudiant(string nom, string prenom)
        {
            Etudiant p = null;
            SqlCommand command = new SqlCommand("SELECT * FROM etudiant Where prenom = @Prenom AND nom = @Nom", Connection);
            command.Parameters.Add(new SqlParameter("@Nom", System.Data.SqlDbType.VarChar) { Value = nom });
            command.Parameters.Add(new SqlParameter("@Prenom", System.Data.SqlDbType.VarChar) { Value = prenom });
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                p = new Etudiant() { Id = reader.GetInt32(0), Nom = reader.GetString(1), Prenom = reader.GetString(2), NumeroClasse = reader.GetString(3), DateDiplome = reader.GetString(4) };
            }
            reader.Close();
            command.Dispose();
            Connection.Close();
            return p;
        }
        public static bool UpdateEtudiant(Etudiant p)
        {
            bool ok = false;
            SqlCommand command = new SqlCommand("UPDATE etudiant SET nom=@Nom,prenom=@Prenom,numeroClasse=@NumeroClasse,dateDiplome=@DateDiplome where id = @Id ", Connection);
            command.Parameters.Add(new SqlParameter("@Id", System.Data.SqlDbType.Int) { Value = p.Id });
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

        public static bool SupprimerEtudiant(Etudiant p)
        {
            bool ok = false;
            SqlCommand command = new SqlCommand("DELETE FROM etudiant Where id=@Id", Connection);
            command.Parameters.Add(new SqlParameter("@Id", System.Data.SqlDbType.Int) { Value = p.Id });
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
