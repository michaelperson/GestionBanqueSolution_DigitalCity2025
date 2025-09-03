using GestionBanque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.UI
{
    public class MvtFinanciersUI
    {
        private Banque _banque;
        private string _numCompte;
        public void Menu(Banque banque)
        {
            this._banque = banque;
            Console.WriteLine(">> Mouvements financiers");
            Console.WriteLine("");
            Console.WriteLine("Que désirez-vous effectuer ?");
            Console.WriteLine($"\t■ 1 - Changer la ligne de crédit ");
            Console.WriteLine($"\t■ 2 - Effectuer un dépôt ");
            Console.WriteLine($"\t■ 3 - Effectuer un retrait ");
            Console.WriteLine($"\t■ 4 - Annuler ");
            string strChoix;
            int choix;
            do
            {
                strChoix = Console.ReadLine();

            } while (!int.TryParse(strChoix, out choix) && (choix < 1 && choix >=5));
            if (choix == 4) return;
            Console.CursorTop--;
            Console.WriteLine(" ");
            if (SelectAccount())
            {
                switch (choix)
                {
                    case 1: ChangeCreditLigne(); break;
                    case 2: Depot(); break;
                    case 3: Retrait(); break;
                    default:
                        break;
                }
            }
            else
            {
                Menu(banque);
            }
            
        }

        private void Retrait()
        {
            Courant c = _banque[_numCompte];
            Console.WriteLine($"Votre solde actuel est de : {c.Solde}");
            Console.WriteLine("Combien voulez-vous retirer : ________");
            bool retry = true;
            do
            {
                Console.CursorTop -= 1;
                Console.CursorLeft = 27;
                string strRetrait;
                double mntRetrait;
                do
                {
                    strRetrait = Console.ReadLine();
                } while (!double.TryParse(strRetrait, out mntRetrait) && (mntRetrait < 0));
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Vous voulez faire un retrait de  : {mntRetrait}");

                string strConfirm;
                do
                {
                    Console.WriteLine("Confirmer (Y/N) ?");
                    strConfirm = Console.ReadLine();
                } while (strConfirm.ToUpper() != "Y" && strConfirm.ToUpper() != "N");

                if (strConfirm.ToUpper() == "Y")
                {
                    if (c.Solde + c.LigneDeCredit >= mntRetrait)
                    {
                        c.Retrait(mntRetrait);
                        displayInfo("Votre retrait a été effectué", ConsoleColor.Green);
                        retry = false;
                    }
                    else
                    {
                        displayInfo("Votre compte présente un solde insuffisant", ConsoleColor.Red);
                        retry = true;
                    }
                }
                else
                {
                    displayInfo("Le retrait est annulé", ConsoleColor.Red);
                    retry = false;
                } 
            } while (retry);
        }

        private void Depot()
        {
            Courant c = _banque[_numCompte];
            Console.WriteLine($"Votre solde actuel est de : {c.Solde}");
            Console.WriteLine("Combien voulez-vous déposer : ________");
            Console.CursorTop -= 1;
            Console.CursorLeft = 27;
            string strDepot;
            double mntDepot;
            do
            {
                strDepot = Console.ReadLine();
            } while (!double.TryParse(strDepot, out mntDepot) && (mntDepot < 0));
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Vous voulez faire un dépôt de  : {mntDepot}");

            string strConfirm;
            do
            {
                Console.WriteLine("Confirmer (Y/N) ?");
                strConfirm = Console.ReadLine();
            } while (strConfirm.ToUpper() != "Y" && strConfirm.ToUpper() != "N");

            if (strConfirm.ToUpper() == "Y")
            {
                c.Depot(mntDepot);
                displayInfo("Votre dépôt a été effectué", ConsoleColor.Green);
            }
            else
            {
                displayInfo("Le dépôt est annulé", ConsoleColor.Red);
            }
        }

        private void ChangeCreditLigne()
        {
            Courant c = _banque[_numCompte];
            Console.WriteLine($"Votre ligne de crédit actuelle est de : {c.LigneDeCredit}");
            Console.WriteLine("Encodez une nouvelle valeur pour la ligne de crédit : ________");
            Console.CursorTop -= 1;
            Console.CursorLeft = 54;
            string strLigneCredit;
            double ligneDeCredit;
            do { 
                strLigneCredit = Console.ReadLine();
            } while (!double.TryParse(strLigneCredit, out ligneDeCredit) && (ligneDeCredit < 0));
            Console.ForegroundColor= ConsoleColor.DarkRed;
            Console.WriteLine($"Vous avez encodez la ligne de crédit suivante : {ligneDeCredit}");
            
            string strConfirm;
            do
            {
                Console.WriteLine("Confirmer (Y/N) ?");
                strConfirm = Console.ReadLine();
            } while (strConfirm.ToUpper() != "Y" && strConfirm.ToUpper() != "N");

            if(strConfirm.ToUpper() == "Y")
            {
                c.LigneDeCredit= ligneDeCredit;
                displayInfo("Ligne de crédit modifié", ConsoleColor.Green);
            }
            else
            {
                displayInfo("Modification annulée", ConsoleColor.Red);
            }

        }

        public bool SelectAccount()
        {
            Console.WriteLine("Pour quel compte voulez-vous effectuer cette opération ?");
            for (int i = 0; i < _banque.NumeroComptes.Count; i++)
            {
                Console.WriteLine($"\t■ {i + 1} - {_banque.NumeroComptes[i]} ");
            }
            Console.WriteLine($"\t■ {_banque.NumeroComptes.Count + 1} - Annuler ");
            string strCompte;
            int choix;
            do
            {
                strCompte = Console.ReadLine();

            } while (!int.TryParse(strCompte, out choix) && (choix < 1 && choix >= _banque.NumeroComptes.Count + 1));
            if (choix == 2) return false;
            _numCompte = _banque.NumeroComptes[choix - 1];
            Console.CursorTop--;
            Console.WriteLine(" ");
            return true;
        }

        private void displayInfo(string message, ConsoleColor color)
        {
            Console.CursorTop = Console.WindowHeight / 2;
            Console.ForegroundColor = color;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (message.Length / 2)) + "}", message));
            Console.ForegroundColor = ConsoleColor.Gray;
            Thread.Sleep(500);
            Console.CursorTop = Console.CursorTop - 1;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));

        }
    }
}
