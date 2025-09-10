using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Models.Exceptions
{
    public class NegativeCreditNotAllowedException : Exception
    {
        public string CustomMessage { get; set; }
        public NegativeCreditNotAllowedException(string message):base(message)
        {
            this.CustomMessage = this.Message + "{PROPULSED BY MIKE}";
        }


    }
}
