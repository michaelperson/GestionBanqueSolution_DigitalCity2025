using GestionBanque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.UI
{
    public  class Menu
    {
        public void Clear()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void Header()
        {
            Console.WriteLine("╔═══════════════════════════════════════════╗");
            Console.WriteLine("║    Gestion de banque - Principes OO       ║");
            Console.WriteLine("╚═══════════════════════════════════════════╝");
            Console.WriteLine();
        }
        public int MainMenu()
        {
            Console.SetCursorPosition(0, 4);
            Console.WriteLine("Menu");
            Console.WriteLine("\t1- Création de la banque");
            Console.WriteLine("\t2- Création d'un compte courant");
            Console.WriteLine("\t3- Création d'un client");
            Console.WriteLine("\t4- Mouvements financiers");
            Console.WriteLine("\t5- Avoir des comptes");
            Console.WriteLine("\t6- Quitter");
            int choix;
            string strChoix;
            do
            {

                Console.Write("Faites votre choix: ");
                strChoix = Console.ReadLine();

            }
            while (!int.TryParse(strChoix, out choix) || (choix > 6 || choix < 1));
            return choix;
        }

        public bool ExitMenu()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            string strExit;
            do
            {

                Console.Write("Vouslez-vous quitter l'application ?(Y/N) ");
                strExit = Console.ReadLine();
            } while (strExit.ToUpper() != "Y" && strExit.ToUpper() != "N");

            return strExit.ToUpper() != "N";
            
        }

        public void Infos(Banque? banque)
        {
            if (banque == null) return;

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            movecursor(0);
            Console.WriteLine("╔═══════════════════════════════════════════╗");

            movecursor(1);
            Console.WriteLine("║    Gestion de banque - Information        ║");
            movecursor(2);
            Console.WriteLine("╚═══════════════════════════════════════════╝");

            movecursor(3);
            Console.WriteLine($"► Banque : {banque.Nom}");

            movecursor(4);
            Console.WriteLine($"► Nombre de comptes : {banque.NumeroComptes.Count}");

            if (banque.NumeroComptes.Count>0)
            {
                movecursor(5);
                Console.WriteLine("► Comptes :");
                movecursor(6);
                int nextligne = 1;
                for (int i = 0; i < banque.NumeroComptes.Count; i++)
                {
                    Courant? c = banque[banque.NumeroComptes[i]];
                    if (c != null)
                    {

                        movecursor(7 + nextligne);
                        Console.WriteLine($"\tNuméro de compte : {c.Numero}");

                        movecursor(8 + nextligne);
                        Console.WriteLine($"\tSolde : {c.Solde}");

                        movecursor(9 + nextligne);
                        Console.WriteLine($"\tLigne de crédit : {c.LigneDeCredit}");

                        movecursor(10 + nextligne);

                        if (!(c.Titulaire is null))
                        {
                            Console.WriteLine("\tTitulaire");

                            movecursor(11 + nextligne);
                            Console.WriteLine($"\t\tNom : {c.Titulaire.Nom} {c.Titulaire.Prenom}");

                            movecursor(12 + nextligne);
                            Console.WriteLine($"\t\tAge : {(int)((DateTime.Now - c.Titulaire.DateDeNaissance).TotalDays / 365)}"); 
                        }
                        else
                        {
                            Console.WriteLine("\tTitulaire : Aucun"); 
                        }
                        nextligne += 6;
                    }
                } 
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void movecursor(int line)
        {
            Console.CursorLeft = Console.WindowWidth / 2;
            Console.CursorTop = 0+line;
        }
    }
}
