using GestionBanque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace GestionBanque.UI
{
    public class CourantUI
    {
        public void CreateAccount(Banque banque)
        {
            Courant compte = new Courant();
            Tools.Validator validator = new Tools.Validator();
            Console.WriteLine(">> Création d'un client");
            Console.WriteLine("");
            if (banque == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vous devez avoir créer une banque avant de créer le compte!");
                Console.WriteLine("");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Détails du compte ");
            string? Number;
            do
            {
                Console.Write("Numéro de compte : BE____________");
                Console.CursorLeft = 21;
                Number = Console.ReadLine();

            } while (Number == null ||
            Number.Length < 12 || !validator.validateBBan(Number));
            compte.Numero = $"BE{Number}";

            if (banque.NumeroComptes.Count() > 0)
            {
                Dictionary<int, Personne> clients = new Dictionary<int, Personne>();
                for (int i = 0; i < banque.NumeroComptes.Count(); i++)
                {
                    Courant? c = banque[banque.NumeroComptes[i]];
                    if (c!=null && c.Titulaire is not null)
                    {
                        if (!clients.ContainsKey(c.Titulaire.GetHashCode()))
                        {
                            clients.Add(c.Titulaire.GetHashCode(), c.Titulaire);
                        }
                    }

                }
                Console.WriteLine("Pour quel client ouvrez-vous ce compte ?");
                int cpt = 0;
                foreach (KeyValuePair<int, Personne> cli in clients)
                {
                    Console.WriteLine($"\t■ {cpt + 1} - {cli.Value.Nom} {cli.Value.Prenom} ");
                    cpt++;
                }
                Console.WriteLine($"\t■ {cpt + 1} - Aucun ");

            }

            banque.Ajouter(compte);
        }
    }
}
