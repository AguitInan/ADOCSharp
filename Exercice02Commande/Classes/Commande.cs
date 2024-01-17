using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice02Commande.Classes
{
    internal class Commande
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }

        public Commande() { }

        public Commande(int clientId, DateTime date, decimal total)
        {
            ClientId = clientId;
            Date = date;
            Total = total;
        }


    }
}
