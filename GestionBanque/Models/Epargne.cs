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
            DateDernierRetrait = DateTime.Now;
            base.Retrait(MontantR);
        }
        #endregion
    }
}
