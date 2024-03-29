﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice01ADO.Classes
{
    internal class IHM
    {
        public static void Menu()
        {
            int choix = 10;
            do
            {
                bool valid = false;
                Console.WriteLine("******** Liste d'Etudiants ********");
                Console.WriteLine("1-Créer Etudiant");
                Console.WriteLine("2-Consulter Liste Etudiants");
                Console.WriteLine("3-Modifier Etudiant");
                Console.WriteLine("4-Supprimer Etudiant");
                Console.WriteLine("0-Quitter");
                Console.Write("Entrez votre choix : ");
                while (!valid)
                {
                    if (int.TryParse(Console.ReadLine(), out int i))
                    {
                        choix = i;
                        valid = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Merci de saisir 0 - 1 - 2 - 3 - 4 : ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                switch (choix)
                {
                    case 1:
                        CreationEtudiant();
                        break;
                    case 2:
                        AfficherListeEtudiant();
                        break;
                    case 3:
                        ModifierEtudiant();
                        break;
                    case 4:
                        SupprimerEtudiant();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Merci de saisir 0 - 1 - 2 - 3 - 4 : ");
                        break;
                }

            } while (choix != 0);
        }
        static void CreationEtudiant()
        {
            Console.Clear();
            Console.WriteLine("****** Création d'un nouvel étudiant ******");
            Console.WriteLine("Le nom de l'étudiant : ");
            string nom = Console.ReadLine();
            Console.WriteLine("Le prénom de l'étudiant : ");
            string prenom = Console.ReadLine();
            Console.WriteLine("Le numéro de classe de l'étudiant : ");
            string numeroClasse = Console.ReadLine();
            Console.WriteLine("La date d'obtention de diplôme de l'étudiant (AAAA-MM-JJ) : ");
            string dateDiplome = Console.ReadLine();
            Etudiant p = new Etudiant(nom, prenom, numeroClasse, dateDiplome);
            p.Add();

            Console.WriteLine("Appuyez sur Enter pour revenir au menu principal...");
            Console.ReadLine();
            Console.Clear();
        }
        static void AfficherListeEtudiant()
        {
            Console.Clear();
            Console.WriteLine("****** Afficher la liste des étudiants ******");
            List<Etudiant> etudiants = new List<Etudiant>(Etudiant.GetList());
            if (etudiants.Count <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erreur ! Aucun étudiant dans la liste");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                foreach (Etudiant p in etudiants)
                {
                    Console.WriteLine(p.ToString());
                    Console.WriteLine("-----------------------------------");
                }
            }
            Console.WriteLine("Appuyez sur Enter pour revenir au menu principal...");
            Console.ReadLine();
            Console.Clear();
        }
        static Etudiant RechercherEtudiant()
        {
            Console.WriteLine("*** Recherche d'un étudiant ***");
            Console.WriteLine("Saisir le nom de l'étudiant : ");
            string nom = Console.ReadLine();
            Console.WriteLine("Saisir le prénom de l'étudiant : ");
            string prenom = Console.ReadLine();
            Etudiant p = new Etudiant();
            p = p.Get(nom, prenom);
            return p;
        }
        static void ModifierEtudiant()
        {
            Console.Clear();
            Console.WriteLine("****** Modification d'un nouvel étudiant ******");
            Etudiant p = RechercherEtudiant();
            if (p != null)
            {
                Console.WriteLine(p.ToString());
                Console.WriteLine("****** Modification de {0} {1} ******\n", p.Nom, p.Prenom);

                Console.WriteLine("Modifier le nom de l'étudiant : ");
                p.Nom = Console.ReadLine();
                Console.WriteLine("Modifier le prénom de l'étudiant : ");
                p.Prenom = Console.ReadLine();
                Console.WriteLine("Modifier le numéro de classe de l'étudiant : ");
                p.NumeroClasse = Console.ReadLine();
                Console.WriteLine("Modifier la date d'obtention de diplôme de l'étudiant (AAAA-MM-JJ) : ");
                p.DateDiplome = Console.ReadLine();
                p.Update();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erreur ! Aucun étudiant Trouvé");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("Appuyez sur Enter pour revenir au menu principal...");
            Console.ReadLine();
            Console.Clear();
        }
        static void SupprimerEtudiant()
        {
            Console.Clear();
            Console.WriteLine("****** Suppression d'un étudiant ******");
            Etudiant p = new Etudiant();
            p = RechercherEtudiant();
            Console.WriteLine(p.ToString());
            Console.WriteLine("****** Suppression, de {0} {1} ******\n", p.Nom, p.Prenom);
            string confirm;
            Console.Write("Etes-vous sûr de vouloir supprimer cet étudiant ? (oui/non) :");
            confirm = Console.ReadLine().ToUpper();
            while (confirm != "OUI" && confirm != "NON")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Erreur Veuillez saisir OUI / NON : ");
                Console.ForegroundColor = ConsoleColor.White;
                confirm = Console.ReadLine().ToUpper();
            }
            if (confirm == "OUI")
            {
                p.Del();
            }
            else
            {
                Console.WriteLine("Vous avez annulé la suppression...");
            }

            Console.WriteLine("Appuyez sur Enter pour revenir au menu principal...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
