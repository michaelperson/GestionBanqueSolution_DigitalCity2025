using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Models
{
    public class Banque
    {
        string _nom;
        Dictionary<string, Compte> _mesComptes = new Dictionary<string, Compte>();

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
        public List<string> NumeroComptes { get { return _mesComptes.Keys.ToList(); } }

       
        public Compte? this[string numerocompte]
        {
            get {                 
                _mesComptes.TryGetValue(numerocompte, out Compte? result);
                return result;
                }
            private set {
                _mesComptes = _mesComptes ?? new Dictionary<string, Compte>();
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

        public void Ajouter(Compte compte)
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


        public double AvoirDesComptes(Personne titulaire)
        {
            double total = 0;
            foreach (KeyValuePair<string, Compte> element in _mesComptes)
            {
                #region Version naïve
                //Version sans utiliser le +
                ////string numero = compte.Key; // récupération du numéro de compte dans l'élément courant
                //Courant lecompte = element.Value;
                //if (lecompte.Titulaire == titulaire)
                //{
                //    total = total + lecompte.Solde;
                //} 
                #endregion
                Compte compte = element.Value;
                //Courant ghostAccount = new Courant();
                
                if (compte.Titulaire == titulaire)
                {
                    //Si j'utilise la surcharge d'opérator courant + courant
                    //total = total +  ( ghostAccount + compte);
                    //( Courant      + Courant) version du + surchargé
                    //double +  (double)

                    //Si j'utilise la surcharge d'opérator double + courant
                    //total = total + compte;
                    //Fonctionne car c# fait l'équivalent de total=total + compte;
                    //                        total += compte;
                    //#paresseux
                    total += compte.Solde;
                }

            }

            return total;
        }

    }
}
