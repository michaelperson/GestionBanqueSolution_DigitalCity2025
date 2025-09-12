using GestionBanque.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Models
{
    public abstract class Compte:ICustomer, IBanker
    {
        private string _numero;
        private double _solde;
        private Personne _titulaire;
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

        public virtual double LigneDeCredit
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Permet de retirer un montant du solde du compte 
        /// en respectant la ligne de crédit
        /// </summary>
        /// <param name="MontantR">Montant positif à retirer</param>
        public virtual void Retrait(double MontantR)
        {
            if (MontantR <= 0)
            {
                Console.WriteLine("Le montant doit être  strictement positif");
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
        
        public void AppliquerInteret()
        { 
            Solde = Solde +  CalculeInteret();
        }

        protected abstract double CalculeInteret();
    
    }
}
