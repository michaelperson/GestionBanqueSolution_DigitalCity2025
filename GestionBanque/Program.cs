// See https://aka.ms/new-console-template for more information
using GestionBanque;

Console.WriteLine("Hello, World!");
Personne m = new Personne();
m.Nom = "Person";
m.DateDeNaissance = new DateTime(2000, 08, 8);
if(m.DateDeNaissance== DateTime.MinValue)
{
    Console.WriteLine("Vous n'avez pas pu encoder votre date de naissance");
}

Courant courant = new Courant();
courant.Numero = "0070";
courant.Titulaire = m;
double MontantD = 1000;
double MontantR = 2000;

Console.WriteLine(courant.Solde);
courant.Depot(MontantD);

Console.WriteLine(courant.Solde);
courant.Retrait(MontantR);
Console.WriteLine(courant.Solde);