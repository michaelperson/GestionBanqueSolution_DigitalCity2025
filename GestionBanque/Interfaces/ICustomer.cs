using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Interfaces
{
    public interface ICustomer
    {
        double Solde { get; }
        void Depot(double MontantD);
        void Retrait(double MontantR);
    }
}
