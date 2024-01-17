using Exercice02Commande.Classes;
using Exercice02Commande.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice02Commande.Classes
{
    internal class IHM
    {
        public static void Menu()
        {
            bool continuer = true;
            while (continuer)
            {
                Console.WriteLine("1. Ajouter un client");
                Console.WriteLine("2. Modifier un client");
                Console.WriteLine("3. Supprimer un client");
                Console.WriteLine("4. Afficher tous les clients");
                Console.WriteLine("5. Ajouter une commande");
                Console.WriteLine("6. Modifier une commande");
                Console.WriteLine("7. Supprimer une commande");
                Console.WriteLine("8. Afficher toutes les commandes");
                Console.WriteLine("0. Quitter");
                Console.Write("Votre choix : ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        AjouterClient();
                        break;
                    case "2":
                        ModifierClient();
                        break;
                    case "3":
                        SupprimerClient();
                        break;
                    case "4":
                        AfficherClients();
                        break;
                    case "5":
                        AjouterCommande();
                        break;
                    case "6":
                        ModifierCommande();
                        break;
                    case "7":
                        SupprimerCommande();
                        break;
                    case "8":
                        AfficherCommandes();
                        break;
                    case "0":
                        continuer = false;
                        break;
                    default:
                        Console.WriteLine("Choix invalide, réessayez.");
                        break;
                }
            }
        }

        private static void AjouterClient()
        {
            Console.Write("Entrez le nom du client : ");
            string nom = Console.ReadLine();
            Console.Write("Entrez le prénom du client : ");
            string prenom = Console.ReadLine();
            Console.Write("Entrez l'adresse du client : ");
            string adresse = Console.ReadLine();
            Console.Write("Entrez le code postal du client : ");
            string codePostal = Console.ReadLine();
            Console.Write("Entrez la ville du client : ");
            string ville = Console.ReadLine();
            Console.Write("Entrez le téléphone du client : ");
            string telephone = Console.ReadLine();

            Client client = new Client(nom, prenom, adresse, codePostal, ville, telephone);
            if (DataBase.AjouterClient(client))
            {
                Console.WriteLine("Client ajouté avec succès.");
            }
            else
            {
                Console.WriteLine("Erreur lors de l'ajout du client.");
            }
        }

        private static void ModifierClient()
        {
            Console.Write("Entrez l'ID du client à modifier : ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Entrez le nouveau nom du client : ");
            string nom = Console.ReadLine();
            Console.Write("Entrez le nouveau prénom du client : ");
            string prenom = Console.ReadLine();
            Console.Write("Entrez la nouvelle adresse du client : ");
            string adresse = Console.ReadLine();
            Console.Write("Entrez le nouveau code postal du client : ");
            string codePostal = Console.ReadLine();
            Console.Write("Entrez la nouvelle ville du client : ");
            string ville = Console.ReadLine();
            Console.Write("Entrez le nouveau téléphone du client : ");
            string telephone = Console.ReadLine();

            Client client = new Client(nom, prenom, adresse, codePostal, ville, telephone) { Id = id };
            if (DataBase.ModifierClient(client))
            {
                Console.WriteLine("Client modifié avec succès.");
            }
            else
            {
                Console.WriteLine("Erreur lors de la modification du client.");
            }
        }

        private static void SupprimerClient()
        {
            Console.Write("Entrez l'ID du client à supprimer : ");
            int id = int.Parse(Console.ReadLine());
            if (DataBase.SupprimerClient(id))
            {
                Console.WriteLine("Client supprimé avec succès.");
            }
            else
            {
                Console.WriteLine("Erreur lors de la suppression du client.");
            }
        }

        private static void AfficherClients()
        {
            List<Client> clients = DataBase.ObtenirClients();
            foreach (Client client in clients)
            {
                Console.WriteLine(client); // Appelle implicitement client.ToString()
            }
        }

        private static void AjouterCommande()
        {
            Console.Write("Entrez l'ID du client pour la commande : ");
            int clientId = int.Parse(Console.ReadLine());
            Console.Write("Entrez la date de la commande (format YYYY-MM-DD) : ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            Console.Write("Entrez le montant total de la commande : ");
            decimal total = decimal.Parse(Console.ReadLine());

            Commande commande = new Commande(clientId, date, total);
            if (DataBase.AjouterCommande(commande))
            {
                Console.WriteLine("Commande ajoutée avec succès.");
            }
            else
            {
                Console.WriteLine("Erreur lors de l'ajout de la commande.");
            }
        }

        private static void ModifierCommande()
        {
            Console.Write("Entrez l'ID de la commande à modifier : ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Entrez le nouvel ID client pour la commande : ");
            int clientId = int.Parse(Console.ReadLine());
            Console.Write("Entrez la nouvelle date de la commande (format YYYY-MM-DD) : ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            Console.Write("Entrez le nouveau montant total de la commande : ");
            decimal total = decimal.Parse(Console.ReadLine());

            Commande commande = new Commande(clientId, date, total) { Id = id };
            if (DataBase.ModifierCommande(commande))
            {
                Console.WriteLine("Commande modifiée avec succès.");
            }
            else
            {
                Console.WriteLine("Erreur lors de la modification de la commande.");
            }
        }

        private static void SupprimerCommande()
        {
            Console.Write("Entrez l'ID de la commande à supprimer : ");
            int id = int.Parse(Console.ReadLine());
            if (DataBase.SupprimerCommande(id))
            {
                Console.WriteLine("Commande supprimée avec succès.");
            }
            else
            {
                Console.WriteLine("Erreur lors de la suppression de la commande.");
            }
        }

        private static void AfficherCommandes()
        {
            List<Commande> commandes = DataBase.ObtenirCommandes();
            foreach (Commande commande in commandes)
            {
                Console.WriteLine(commande); // Appelle implicitement commande.ToString()
            }
        }
    }
}
