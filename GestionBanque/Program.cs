#region Tests
//// See https://aka.ms/new-console-template for more information
//using GestionBanque;

//Console.WriteLine("Gestion de Banque - Exercice fil rouge OO");
//Personne Client = new Personne();
//Client.Nom = "Smith";
//Client.Prenom = "Jhon";
//Client.DateDeNaissance = new DateTime(1993, 01, 30);
//if(Client.DateDeNaissance== DateTime.MinValue)
//{
//    Console.WriteLine("Vous n'avez pas pu encoder votre date de naissance");
//    //Permet de sortir de l'application avec un code d'erreur personalisé
//    System.Environment.Exit(2);
//}
////Création du compte courant pour notre client
//Courant courant = new Courant();
//courant.Numero = "0070";
//courant.Titulaire = Client;
//double MontantD = 1000;
//double MontantR = 2000;

//Console.WriteLine(courant.Solde);
//courant.Depot(MontantD);

//Console.WriteLine(courant.Solde);
//courant.Retrait(MontantR);
//Console.WriteLine(courant.Solde);


//Banque voleur1 = new Banque();
//voleur1.Nom = "Ing";
//Banque voleur2 = new Banque();
//voleur2.Nom = "Belfius(Dexia,Credit Communal, CGER)";

////voleur1[courant.Numero] = courant;
////voleur1[courant.Numero] = courant;
//voleur1.Ajouter(courant);
//voleur1.Ajouter(courant);

//Courant? c1 = voleur2["0070"];
//if(c1==null) Console.WriteLine($"Pas de compte dans cette banque avec le numéro 0070");
//Courant? c2 = voleur1["0080"];
//if (c2 == null)
//{
//    Console.WriteLine($"Pas de compte dans cette banque avec le numéro 0070");
//}
//else
//{
//    Console.WriteLine($"Titulaire : {c2.Titulaire.Nom}");
//}

//voleur1.Supprimer("0070");

//Personne p1 = new Personne() { Prenom = "Shakira" };
//Personne p2 = new Personne() { Prenom = "Mike" };

//Personne enfant = p1 + p2;

//Console.WriteLine($"La fusion des deux personnes se nomme  : {enfant.Prenom}");


//Personne p3 = new Personne() { Prenom = "Mike", Nom="Thyson" };
//Personne p4 = new Personne() { Prenom = "Mike", Nom = "Thyson" };
//if (p3==p4)
//{
//    Console.WriteLine("Mes deux personnes sont identiques");
//}
//else
//{
//    Console.WriteLine("Il s'agit de deux personnes différentes");
//}

//if (p3.Equals(p4))
//{
//    Console.WriteLine("Mes deux personnes sont identiques");
//}
//else
//{
//    Console.WriteLine("Il s'agit de deux personnes différentes");
//}


////tester l'opérateur +

//Personne RichieRich = new Personne() { Nom = "Mak", Prenom = "Kaulkin" };


//Courant test1 = new Courant();
//test1.Numero = "123";
//test1.Depot(100);
//test1.Titulaire = RichieRich;
//Courant test2 = new Courant();
//test2.Numero = "456";
//test2.Titulaire = RichieRich;
//test2.LigneDeCredit = 5000;
//test2.Depot(100);
//test2.Retrait(400);


//double total = test1 + test2;
//Console.WriteLine($"Solde des deux comptes : {total}");



//voleur2.Ajouter(test1);
//voleur2.Ajouter(test2);

////je vais tester les avoirs
//double capital = voleur2.AvoirDesComptes(RichieRich);
//Console.WriteLine($" Notre {RichieRich.Nom} détient £{capital}");


#endregion
//using GestionBanque.Models;
//using GestionBanque.UI;

//Banque banque = new Banque() { Nom="Belfius" };
//#region UI
//Menu menu = new Menu();
//BankUI bankUI = new BankUI();
//ClientUI clientUI = new ClientUI();
//CourantUI courantUi = new CourantUI();
//MvtFinanciersUI mvtFinanciersUI = new MvtFinanciersUI();
//#endregion
//bool Exit = false;
//do
//{
//    menu.Clear();
//    menu.Header();
//    menu.Infos(banque);
//    int choix = menu.MainMenu();
//    menu.Clear();
//    switch (choix)
//    {
//        case 1:
//            menu.Clear();
//            menu.Header();
//            banque=bankUI.createBank();
//            Console.ForegroundColor = ConsoleColor.DarkGreen;
//            Console.WriteLine("Opération effectuée");
//            break;

//        case 2:
//            menu.Clear();
//            menu.Header();
//            if (banque == null)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("Vous devez créer la banque avant!");
//                break;
//            }
//            courantUi.CreateAccount(banque);
//            Console.ForegroundColor = ConsoleColor.DarkGreen;
//            Console.WriteLine("Opération effectuée");
//            break;
//        case 3:
//            menu.Clear();
//            menu.Header();
//            if(banque == null)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("Vous devez créer la banque avant!");
//                break;
//            }
//            clientUI.createClient(banque);
//            Console.ForegroundColor = ConsoleColor.DarkGreen;
//            Console.WriteLine("Opération effectuée");
//            break;
//        case 4:
//            menu.Clear();
//            menu.Header();
//            if (banque == null)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("Vous devez créer la banque avant!");
//                break;
//            }
//            mvtFinanciersUI.Menu(banque);
//            Console.ForegroundColor = ConsoleColor.DarkGreen;
//            Console.WriteLine("Opération effectuée");
//            break;

//        case 5:break;
//        case 6:break;
//        default:
//            break;
//    } 
//    Exit = menu.ExitMenu();
//} while (!Exit);
//Console.ForegroundColor = ConsoleColor.Gray;

using GestionBanque.Interfaces;
using GestionBanque.Models;
using GestionBanque.Models.Exceptions;

Banque CGER = new Banque();

Courant MonCompte = new Courant();
MonCompte.Numero = "4"; 
MonCompte.Depot(100);
Console.WriteLine(MonCompte.Solde);

CGER.Ajouter(MonCompte);

Compte Ecureuil = new Epargne();
Ecureuil.Numero = "8";
Ecureuil.Depot(100);
Console.WriteLine(Ecureuil.Solde);
CGER.Ajouter(Ecureuil);

CGER["4"].AppliquerInteret();
CGER["8"].AppliquerInteret();

AfficheInfo(MonCompte);
AfficheInfo(Ecureuil); 
UtiliseCompteCommeUnBanquier(MonCompte);
UtiliseCompteCommeUnBanquier(Ecureuil);

static void AfficheInfo(ICustomer customerAccount)
{
    Console.WriteLine($"Solde : {customerAccount.Solde}");
     
}

static void UtiliseCompteCommeUnBanquier(IBanker banker)
{
    banker.AppliquerInteret();
    Console.WriteLine($"Solde : {banker.Solde}");
    Console.WriteLine($"Titulaire : {banker.Titulaire.Nom}");
    Console.WriteLine($"Num : {banker.Numero}");

}

