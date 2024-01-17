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

        // Méthodes pour la gestion des Clients
        public static bool AjouterClient(Client client)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("INSERT INTO client (Nom, Prenom, Adresse, CodePostal, Ville, Telephone) VALUES (@Nom, @Prenom, @Adresse, @CodePostal, @Ville, @Telephone)", Connection))
                {
                    command.Parameters.AddWithValue("@Nom", client.Nom);
                    command.Parameters.AddWithValue("@Prenom", client.Prenom);
                    command.Parameters.AddWithValue("@Adresse", client.Adresse);
                    command.Parameters.AddWithValue("@CodePostal", client.CodePostal);
                    command.Parameters.AddWithValue("@Ville", client.Ville);
                    command.Parameters.AddWithValue("@Telephone", client.Telephone);

                    Connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }

        

        

        

        

        

        

        
    }
}
