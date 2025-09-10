using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Models
{
    public class Epargne : Compte
    {
        #region Private fields        
        private DateTime _dateDernierRetrait; 
        #endregion
        #region Properties        
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
        #endregion
        #region Methods
        public override void Retrait(double MontantR)
        {
            if (Solde - MontantR < 0) { Console.WriteLine("Tu ne peux pas retirer autant de frix su le compte. Tips: Call ousmane!");
                return;
            }
          
            base.Retrait(MontantR);
            DateDernierRetrait = DateTime.Now;
        }

        protected override double CalculeInteret()
        {
            return Solde * 0.045;
        }
        #endregion
    }
}
