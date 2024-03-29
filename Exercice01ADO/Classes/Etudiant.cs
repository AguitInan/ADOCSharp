﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Exercice01ADO.Data;

namespace Exercice01ADO.Classes
{
    internal class Etudiant
    {
        private int _id;
        private string _nom;
        private string _prenom;
        private string _numeroClasse;
        private string _dateDiplome;


        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
        public string NumeroClasse { get => _numeroClasse; set => _numeroClasse = value; }
        public string DateDiplome { get => _dateDiplome; set => _dateDiplome = value; }



        public Etudiant()
        {

        }
        public Etudiant(string n, string p, string c, string d)
        {
            Nom = n;
            Prenom = p;
            NumeroClasse = c;
            DateDiplome = d;
        }


        public void Add()
        {
            if (DataBase.AjouterEtudiant(this))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Etudiant ajouté...");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erreur lors ajout de l'étudiant...");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void Del()
        {
            if (DataBase.SupprimerEtudiant(this))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Etudiant supprimé...");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erreur lors supression de l'étudiant...");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void Update()
        {
            if (DataBase.UpdateEtudiant(this))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Etudiant modifié...");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erreur lors de la modification de l'étudiant...");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public Etudiant Get(string nom, string prenom)
        {
            Etudiant p = DataBase.TrouverEtudiant(nom, prenom);
            if (p != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Etudiant trouvé...");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Aucun étudiant trouvé avec ces éléments...");
                Console.ForegroundColor = ConsoleColor.White;
            }
            return p;
        }

        public static List<Etudiant> GetList()
        {
            return DataBase.AvoirListeEtudiant();
        }


        public override string ToString()
        {
            return Nom + " " + Prenom + " - Numéro de classe : " + NumeroClasse + " Date de diplôme : " + DateDiplome;
        }

    }
}

