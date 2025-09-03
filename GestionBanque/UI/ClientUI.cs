using GestionBanque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.UI
{
    public class ClientUI
    {
        public  void createClient(Banque banque)
        { 
            Console.WriteLine(">> Création d'un client");
            Console.WriteLine("");
            if (banque == null || banque.NumeroComptes.Count() < 1)
            {
                Console.ForegroundColor=ConsoleColor.Red;
                Console.WriteLine("Vous devez avoir créer une banque et un compte avant de créer le client!");
                Console.WriteLine("");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Pour quel compte voulez-vous créer le client ?");
            for (int i = 0; i < banque.NumeroComptes.Count; i++)
            {
                Console.WriteLine($"\t■ {i+1} - {banque.NumeroComptes[i]} ");
            }
            Console.WriteLine($"\t■ {banque.NumeroComptes.Count+1} - Annuler ");
            string strCompte;
            int choix;
            do
            {
               strCompte = Console.ReadLine();
         
             }while(!int.TryParse(strCompte, out choix) && (choix<1 && choix >= banque.NumeroComptes.Count+1));
            if (choix == banque.NumeroComptes.Count + 1) return;
            string NumCompte = banque.NumeroComptes[choix-1];
            Console.CursorTop--;
            Console.WriteLine(" ");
            banque[NumCompte].Titulaire = ClientEncode(NumCompte);

             


        }
        private Personne ClientEncode(string numCompte)
        {
            Personne personne = new Personne();
            Console.WriteLine($"Détails du client pour le compte {numCompte}");


            Console.WriteLine("Nom du client               :______________________________ ");
            Console.WriteLine("Prenom du client            :______________________________ ");
            Console.WriteLine("Date de naissance du client :____-__-__ ");


            bool isCorrect = false;
            string nom;
            do
            {
                Console.SetCursorPosition(Console.CursorTop - 4, 11);
                nom = Console.ReadLine();
                if(!string.IsNullOrWhiteSpace(nom)) isCorrect=true;
                else
                {
                    displayInfo("Le nom est obligatoire");
                }
            } while (!isCorrect);
            isCorrect = false;
            string prenom;
            do
            {
                Console.SetCursorPosition(Console.CursorTop - 4, 12);
                  prenom = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(prenom)) isCorrect = true;
                else
                {
                    displayInfo("Le prénom est obligatoire");
                }
            } while (!isCorrect);
            isCorrect = false;
            DateTime dtOk;
            do
            {
                Console.SetCursorPosition(Console.CursorTop-4, 13);
                Console.WriteLine("____-__-__");
                Console.SetCursorPosition(Console.CursorTop - 4, 13);
                string date = Console.ReadLine();
                if (DateTime.TryParseExact(date,"yyyy-MM-dd",null, System.Globalization.DateTimeStyles.None,out dtOk)) isCorrect = true;
                else
                {
                    displayInfo("La date n'est pas dans le bon format");continue;
                }
                double age = ((DateTime.Now - dtOk).TotalDays) / 365;
                if (age >= 18 && age <= 100) isCorrect = true;
                else
                {
                    displayInfo("Le client doit avoir min 18ans et maximum 100 ans"); continue;
                }
            } while (!isCorrect);

            personne.Nom = nom;
            personne.Prenom = prenom;
            personne.DateDeNaissance = dtOk;
            return personne;
        }

        private void displayInfo(string message)
        {
            Console.CursorTop = Console.WindowHeight /2;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (message.Length / 2)) + "}", message)); 
            Console.ForegroundColor = ConsoleColor.Gray;
            Thread.Sleep(500);
            Console.CursorTop = Console.CursorTop - 1;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));

        }
    }
}
