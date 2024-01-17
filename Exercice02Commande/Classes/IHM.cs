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












    }
}
