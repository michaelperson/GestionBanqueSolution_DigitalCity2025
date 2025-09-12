using GestionBanque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Interfaces
{
    public interface IBanker:ICustomer
    {
        string Numero { get; }
        Personne Titulaire { get; }
         
        void AppliquerInteret();
    }
}
