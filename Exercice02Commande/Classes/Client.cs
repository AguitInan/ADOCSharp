﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice02Commande.Classes
{
    internal class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Telephone { get; set; }
        public List<Commande> Commandes { get; set; }

        public Client()
        {
            Commandes = new List<Commande>();

        }

        public Client(string nom, string prenom, string adresse, string codePostal, string ville, string telephone)
        {
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            CodePostal = codePostal;
            Ville = ville;
            Telephone = telephone;
            Commandes = new List<Commande>();
        }


    }
}
