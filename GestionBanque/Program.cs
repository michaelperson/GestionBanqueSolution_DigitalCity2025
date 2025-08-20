// See https://aka.ms/new-console-template for more information
using GestionBanque;

Console.WriteLine("Gestion de Banque - Exercice fil rouge OO");
Personne Client = new Personne();
Client.Nom = "Smith";
Client.Prenom = "Jhon";
Client.DateDeNaissance = new DateTime(1993, 01, 30);
if(Client.DateDeNaissance== DateTime.MinValue)
{
    Console.WriteLine("Vous n'avez pas pu encoder votre date de naissance");
    //Permet de sortir de l'application avec un code d'erreur personalisé
    System.Environment.Exit(2);
}
//Création du compte courant pour notre client
Courant courant = new Courant();
courant.Numero = "0070";
courant.Titulaire = Client;
double MontantD = 1000;
double MontantR = 2000;

Console.WriteLine(courant.Solde);
courant.Depot(MontantD);

Console.WriteLine(courant.Solde);
courant.Retrait(MontantR);
Console.WriteLine(courant.Solde);


Banque voleur1 = new Banque();
voleur1.Nom = "Ing";
Banque voleur2 = new Banque();
voleur2.Nom = "Belfius(Dexia,Credit Communal, CGER)";

//voleur1[courant.Numero] = courant;
//voleur1[courant.Numero] = courant;
voleur1.Ajouter(courant);
voleur1.Ajouter(courant);

Courant? c1 = voleur2["0070"];
if(c1==null) Console.WriteLine($"Pas de compte dans cette banque avec le numéro 0070");
Courant? c2 = voleur1["0080"];
if (c2 == null)
{
    Console.WriteLine($"Pas de compte dans cette banque avec le numéro 0070");
}
else
{
    Console.WriteLine($"Titulaire : {c2.Titulaire.Nom}");
}

voleur1.Supprimer("0070");

Personne p1 = new Personne() { Prenom = "Shakira" };
Personne p2 = new Personne() { Prenom = "Mike" };

Personne enfant = p1 + p2;

Console.WriteLine($"La fusion des deux personnes se nomme  : {enfant.Prenom}");


Personne p3 = new Personne() { Prenom = "Mike", Nom="Thyson" };
Personne p4 = new Personne() { Prenom = "Mike", Nom = "Thyson" };
if (p3==p4)
{
    Console.WriteLine("Mes deux personnes sont identiques");
}
else
{
    Console.WriteLine("Il s'agit de deux personnes différentes");
}

if (p3.Equals(p4))
{
    Console.WriteLine("Mes deux personnes sont identiques");
}
else
{
    Console.WriteLine("Il s'agit de deux personnes différentes");
}