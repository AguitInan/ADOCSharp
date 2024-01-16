using System;
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
                Console.WriteLine("4-Supprimmer Etudiant");
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





    }
}
