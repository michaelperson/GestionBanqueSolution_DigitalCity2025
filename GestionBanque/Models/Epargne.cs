using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Models
{
    public class Epargne
    {
        #region Private fields
        private string _numero;
        private double _solde;
        private DateTime _dateDernierRetrait;
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

        public DateTime DateDernierRetrait
        {
            get
            {
                return _dateDernierRetrait;
            }

            set
            {
                _dateDernierRetrait = value;
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
        /// </summary>
        /// <param name="MontantR">Montant positif à retirer</param>
        /// <remarks>Un compte épargne ne peut pas être en négatif!</remarks>
        public void Retrait(double MontantR)
        {
            if (MontantR <= 0)
            {
                Console.WriteLine("Le montant doit être  strictement positif");
                return;
            }
            if (Solde  < MontantR)
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
    }
}
