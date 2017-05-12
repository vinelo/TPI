using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace TravauxDisciplinaireCFPT
{
    [Serializable]
    class Niveau
    {
        //Champs
        private int _numeroNiveau;
        private string _texteARecopier;

        //Propriétés
        public int NumeroNiveau
        {
            get { return _numeroNiveau; }
            set { _numeroNiveau = value; }
        }

        public string TexteARecopier
        {
            get { return _texteARecopier; }
            set { _texteARecopier = value; }
        }

        //Constructeur
        public Niveau() : this(1) { }
        public Niveau(int paramNiveau) : this(paramNiveau, null) { } 
        /// <summary>
        /// Constructeur du niveau
        /// </summary>
        /// <param name="paramNiveau">Numéro du niveau</param>
        /// <param name="paramTexte">Texte du niveau</param>
        public Niveau(int paramNiveau, string paramTexte)
        {
            NumeroNiveau = paramNiveau;
            if (paramTexte != null)
                this.TexteARecopier = paramTexte;
            else
                this.TexteARecopier = ChoisirTexte();
        }
        //Méthodes
        /// <summary>
        /// Choisi un texte correspondant au niveau
        /// </summary>
        /// <returns>Le texte</returns>
        public string ChoisirTexte()
        {
            ResourceManager rm = Properties.Resources.ResourceManager;
            string Texte = (string)rm.GetObject("TexteNiveau" + Convert.ToString(this.NumeroNiveau));
            return Texte;
        }

        /// <summary>
        /// Compte le nombre de caratères dans le texte à recopier
        /// </summary>
        /// <returns>Nombre de caratères dans le texte à recopier</returns>
        public int CompterCaractere()
        {
            int nbCaractere = this.TexteARecopier.Count();
            return nbCaractere;
        }

        /// <summary>
        /// Calcule le temps approximatif que prendrait le texte à être écrit
        /// </summary>
        /// <returns>Temps du texte</returns>
        public int CalculerMinutesDuTexte()
        {
            int nbCaracteres = CompterCaractere();

            double nbMots = nbCaracteres / 5;
            double nbMinutes = nbMots / 30;
            //Arrondie de la minutes à 10
            nbMinutes /= 10;
            nbMinutes = Math.Round(nbMinutes);
            nbMinutes *= 10;
            return (int)nbMinutes;
        }
        /// <summary>
        /// Retourne en string les paramètres de la classe "Niveau"
        /// </summary>
        /// <returns>Paramètres de la classe niveau</returns>
        public override string ToString()
        {
            string NiveauToString = "";
            if (this.NumeroNiveau == 6)
                NiveauToString = "Texte personnalisé" + " ( ~ " + Convert.ToString(this.CalculerMinutesDuTexte()) + " minutes )";
            else
                NiveauToString = this.NumeroNiveau + " ( ~ " + Convert.ToString(this.CalculerMinutesDuTexte()) + " minutes )";
            return NiveauToString;
        }
    }
}
