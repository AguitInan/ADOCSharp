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
            //Id = id;
            Nom = n;
            Prenom = p;
            NumeroClasse = c;
            DateDiplome = d;
        }













    }
}

