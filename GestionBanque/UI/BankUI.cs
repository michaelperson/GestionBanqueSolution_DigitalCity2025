using GestionBanque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.UI
{
    public class BankUI
    {
        public Banque createBank()
        {
            Banque banque = new Banque();
            Console.WriteLine(">> Création de la banque");
            Console.WriteLine("");
            Console.Write("Quel est le nom de votre banque ? __________________________________ ");
            Console.CursorLeft=34;
            banque.Nom = Console.ReadLine();
            return banque;
        }
    }
}
