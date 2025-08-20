using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Tools
{
    public class Validator
    {
        /// <summary>
        /// Permet de valider le numéro de compte Belge
        /// </summary>
        /// <param name="Compte">numéro de compte belge</param>
        /// <returns>True si le compte est valide</returns>
        /// <remarks>Cette fonction vérifier si le numéro de compte est valide pas si il existe réellement</remarks>
        public bool validateBBan(string Compte)
        {
            if (string.IsNullOrEmpty(Compte)) return false;


            long TenFirst = long.Parse(compte.Substring(0, 10));
            int LastTwo = int.Parse(compte.Substring(10, 2));

            int Modulo = (int)(TenFirst % 97);

            return LastTwo == ((Modulo == 0) ? 97 : Modulo);

        }
    }
}
