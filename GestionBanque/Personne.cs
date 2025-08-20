namespace GestionBanque
{
    /// <summary>
    /// Classe personne de l'exercice
    /// </summary>
    public class Personne
    {
        #region Members
            private string _nom, _prenom;
            private DateTime _dateDeNaissance;
        #endregion

        #region Properties
        /// <summary>
        /// Propriété retournant la valeur du Nom et de lui affecter une valeur
        /// </summary>
        public string Nom
            {
                get { return _nom; }
                set { _nom = value; }
            }
        /// <summary>
        /// Propriété peremettant d'obtenir la valeur du Prénom et de lui affecter une valeur
        /// </summary>
        public string Prenom
            {
                get { return _prenom; }
                set { _prenom = value; }
            }
        /// <summary>
        ///Propriété permettant d'obtenir la valeur de la date de naissance et de lui affecter une valeur.
        ///Attention : vous devez avoir 18 ans!
        /// </summary>       
            public DateTime DateDeNaissance
            {
                get { return _dateDeNaissance; }
                set {
                    double NbJours = ( DateTime.Now-value).TotalDays;
                    if ((NbJours/365)>=18)
                    {
                        _dateDeNaissance = value;
                    }else
                    {
                    //A changer plus tard !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    Console.WriteLine("Vous devez avoir 18 ans");
                    }
                    
                }
            }
        #endregion

         


    
    }
}
