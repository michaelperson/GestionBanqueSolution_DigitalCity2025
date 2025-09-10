namespace GestionBanque.Models;

public class Titre:Courant
{
    public override double LigneDeCredit
    {
        get
        {
            if (Solde < 0)
            {
                return base.LigneDeCredit;
            }
            else
            {
                base.LigneDeCredit = Math.Abs(Solde * 2);
                return base.LigneDeCredit;
            }
        }
        set
        {
            throw new InvalidOperationException("La ligne de crédit est calculée automatiquement");
        }
    }
  
}
