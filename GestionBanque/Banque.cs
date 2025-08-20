using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque
{
    public class Banque
    {
        string _nom;
        Dictionary<string, Courant> _mesComptes = new Dictionary<string, Courant>();

        public string Nom
        {
            get
            {
                return _nom;
            }

            set
            {
                _nom = value;
            }
        }

        public Courant? this[string numerocompte]
        {
            get {                 
                _mesComptes.TryGetValue(numerocompte, out Courant? result);
                return result;
                }
            private set {
                //_mesComptes = _mesComptes ?? new Dictionary<string, Courant>();
                if (value == null) {
                    Console.WriteLine("Pas de compte transmis");
                    return;
                }

                if (_mesComptes.ContainsKey(numerocompte)) 
                {
                    Console.WriteLine($"ce compte est déjà présent dans la banque {Nom}");
                    return;
                }
                if(value?.Numero!= numerocompte)
                {
                    Console.WriteLine($"Le numéro de compte tranmis ({numerocompte}) ne correspond pas au compte à ajouter {value?.Numero}");
                }

#pragma warning disable CS8604 // Possible null reference argument.
                _mesComptes.Add(numerocompte, value);
#pragma warning restore CS8604 // Possible null reference argument.
            }
        }

        public void Ajouter(Courant compte)
        {             
            this[compte.Numero] = compte;
        }

        public void Supprimer(string Numero)
        {            

            if (string.IsNullOrEmpty(Numero)) { return; }
            if (_mesComptes.ContainsKey(Numero))
            {
                _mesComptes.Remove(Numero);                 
            }
        }

    }
}
