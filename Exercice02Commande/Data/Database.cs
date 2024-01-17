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

        public static bool SupprimerClient(int clientId)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM client WHERE Id = @Id", Connection))
                {
                    command.Parameters.AddWithValue("@Id", clientId);

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

        public static bool ModifierClient(Client client)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("UPDATE client SET Nom = @Nom, Prenom = @Prenom, Adresse = @Adresse, CodePostal = @CodePostal, Ville = @Ville, Telephone = @Telephone WHERE Id = @Id", Connection))
                {
                    command.Parameters.AddWithValue("@Id", client.Id);
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

        public static List<Client> ObtenirClients()
        {
            List<Client> clients = new List<Client>();
            try
            {
                using (SqlCommand command = new SqlCommand("SELECT Id, Nom, Prenom, Adresse, CodePostal, Ville, Telephone FROM client", Connection))
                {
                    Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clients.Add(new Client
                            {
                                Id = reader.GetInt32(0),
                                Nom = reader.GetString(1),
                                Prenom = reader.GetString(2),
                                Adresse = reader.GetString(3),
                                CodePostal = reader.GetString(4),
                                Ville = reader.GetString(5),
                                Telephone = reader.GetString(6)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return clients;
        }

        // Méthodes pour la gestion des Commandes
        public static bool AjouterCommande(Commande commande)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("INSERT INTO commande (ClientId, Date, Total) VALUES (@ClientId, @Date, @Total)", Connection))
                {
                    command.Parameters.AddWithValue("@ClientId", commande.ClientId);
                    command.Parameters.AddWithValue("@Date", commande.Date);
                    command.Parameters.AddWithValue("@Total", commande.Total);

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

        public static bool SupprimerCommande(int commandeId)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM commande WHERE Id = @Id", Connection))
                {
                    command.Parameters.AddWithValue("@Id", commandeId);

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

        public static bool ModifierCommande(Commande commande)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("UPDATE commande SET ClientId = @ClientId, Date = @Date, Total = @Total WHERE Id = @Id", Connection))
                {
                    command.Parameters.AddWithValue("@Id", commande.Id);
                    command.Parameters.AddWithValue("@ClientId", commande.ClientId);
                    command.Parameters.AddWithValue("@Date", commande.Date);
                    command.Parameters.AddWithValue("@Total", commande.Total);

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
