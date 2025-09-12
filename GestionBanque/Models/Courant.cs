using GestionBanque.Interfaces;
using GestionBanque.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace GestionBanque.Models
{
    public class Courant:Compte
    {
        #region Members
       
        private double _ligneDeCredit;
        
        #endregion
        #region Properties
       
        public override double LigneDeCredit
        {
            get
            {
                return _ligneDeCredit;
            }

            set
            {
                if (value >= 0)
                {
                    _ligneDeCredit = value;
                }
                else
                {
                    try
                    {
                        throw new NegativeCreditNotAllowedException("La ligne de crédit doit être positive");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erreur");
                        throw ex;
                    }
                   
                }
            }
        }

        #endregion
        #region Methods
        public override void Retrait(double MontantR)
        {
             
            if (Solde + LigneDeCredit < MontantR)
            {
                Console.WriteLine("Votre solde est insuffisant");
                return;
            }
            
            base.Retrait(MontantR);
        }

        protected override double CalculeInteret()
        {
            return Solde < 0 ? Solde*0.0975 : Solde*0.03;
        }

        #region Surcharge de l'opérateur +

        /// <summary>
        /// Opérateur + permettant d'additionner le solde de deux comptes
        /// </summary>
        /// <param name="c1">Compte courant N°1</param>
        /// <param name="c2">Compte courant N°2</param>
        /// <returns>La somme des actifs des comptes sans tenir compte des valeurs négatives</returns>
        /// <example>
        /// Courant c1 = new Courant();
        /// c1.Depot(100);
        /// Courant c2 = new Courant();
        /// c2.Depot(200);
        /// double sommeDesActifs = c1+c2 //Donne 300
        /// 
        /// Courant c1 = new Courant();
        /// c1.Depot(100);
        /// c1.Retrait(400);
        /// Courant c2 = new Courant();
        /// c2.Depot(200);
        /// double sommeDesActifs = c1+c2 //Donne 200
        /// </example>
        public static double operator +(Courant c1, Courant c2)
        {
             
            double solde1 = 0;
            double solde2 = 0;

            if (c1.Solde >= 0) solde1 = c1.Solde; //Si le compte   est positif , je prend sa valeur
            if (c2.Solde >= 0) solde2 = c2.Solde;//Si le compte positif , je prend sa valeur
          
            return solde1 + solde2;
        }
        /// <summary>
        /// Opérateur + permettant d'additionner un double représantant un montant avec le solde d'un compte courant
        /// </summary>
        /// <param name="c1">Somme de départ</param>
        /// <param name="c2">Compte courant N°2</param>
        /// <returns>La somme du solde + la somme de départ sans tenir compte des valeurs négatives</returns>
        /// <example>
        /// double c1 = 100;
        /// Courant c2 = new Courant();
        /// c2.Depot(200);
        /// double sommeDesActifs = c1+c2 //Donne 300
        /// 
        /// Courant c1 = 100;
        /// Courant c2 = new Courant();
        /// c.Depot(200);         
        /// c.Retrait(400);
        /// double sommeDesActifs = c1+c2 //Donne 100
        /// </example>
        public static double operator +(double c1, Courant c2)
        {
            double solde1 = c1 > 0 ? c1 : 0;
            double solde2 = 0;

            if (c2.Solde >= 0) solde2 = c2.Solde;//Si le compte positif , je prend sa valeur

            return solde1 + solde2;
        }
        #endregion

        #endregion

    }
}
