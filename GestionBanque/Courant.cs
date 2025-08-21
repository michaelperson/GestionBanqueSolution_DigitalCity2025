using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace GestionBanque
{
    public class Courant
    {
        #region Members
        private string _numero;
        private double _solde;
        private double _ligneDeCredit;
        private Personne _titulaire;
        #endregion
        #region Properties
        public string Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                _numero = value;
            }
        }
        public double Solde
        {
            get
            {
                return _solde;
            }
            private set { _solde = value; }
        }
        public double LigneDeCredit
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
                    Console.WriteLine("Ligne de crédit doit être positive");
                }
            }
        }
        public Personne Titulaire
        {
            get
            {
                return _titulaire;
            }

            set
            {
                _titulaire = value;
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Permet de retirer un montant du solde du compte 
        /// en respectant la ligne de crédit
        /// </summary>
        /// <param name="MontantR">Montant positif à retirer</param>
        public void Retrait(double MontantR)
        {
            if (MontantR <= 0)
            {
                Console.WriteLine("Le montant doit être  strictement positif");
                return;
            }
            if ((Solde + LigneDeCredit) < MontantR)
            {
                Console.WriteLine("Votre solde est insuffisant");
                return;
            }
            Solde -= MontantR;
        }
        /// <summary>
        /// Procédure permettant de déposer un montant positif sur notre compte
        /// </summary>
        /// <param name="MontantD">Montant positif à déposer</param>
        public void Depot(double MontantD)
        {
            if (MontantD <= 0)
            {
                Console.WriteLine("Le montant doit être strictement positif");
                return;
            }
            //Solde = Solde + Montant;
            Solde += MontantD;

        }
        #endregion

        //Surcharge de l'opérateur +
        public static double operator +(Courant c1, Courant c2)
        {
            //return c1.Solde<0?0:c1.Solde+ c2.Solde<0?0:c2.Solde;
          
            double solde1 = 0;
            double solde2 = 0;

            if(c1.Solde>=0)  solde1=c1.Solde; //Si le compte   est positif , je prend sa valeur
            if (c2.Solde>= 0) solde2 = c2.Solde;//Si le compte positif , je prend sa valeur

            return solde1 + solde2;
        }

        public static double operator +(double c1, Courant c2)
        {

        }

    }
}
