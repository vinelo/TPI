/*
 * Auteur : Vincent Naef 
 * Application : Travaux Disciplinaires au CFPT
 * Nom de la classe : Niveau
 * Description de la classe : Ceci est la classe ou est stocké le niveau et le texte du travail disciplinaire.  C'est aussi dans cette classe que les opérations lié au texte ou au niveau se feront.
 * Date de dernière modification : 23 mai 2017
 */
using System;
using System.Linq;
using System.Resources;

namespace TravauxDisciplinaireCFPT
{
    [Serializable]
    public class Niveau
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
            set 
            {
                if (value != "" && value !=null)
                    value = FiltrerCaracteres(value);
                _texteARecopier = value;
            }
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
        public int CompterCaracteres()
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
            int nbCaracteres = CompterCaracteres();

            double nbMots = nbCaracteres / 5;
            double nbMinutes = nbMots / 33;
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
            {
                if (this.CalculerMinutesDuTexte() != 0)
                    NiveauToString = "Personnalisé" + " ( ~ " + Convert.ToString(this.CalculerMinutesDuTexte()) + " min. )";
                else
                    NiveauToString = "Personnalisé" + " ( moins de 10 min. )";
            }
            else
                NiveauToString = this.NumeroNiveau + " ( ~ " + Convert.ToString(this.CalculerMinutesDuTexte()) + " min. )";
            return NiveauToString;
        }
        
        /// <summary>
        /// Filtre les caractère (suppression des caractère 'LF' (Line feed) et des retours à la ligne à la suite)
        /// </summary>
        /// <param name="paramTexteAFiltrer"></param>
        /// <returns></returns>
        public string FiltrerCaracteres(string paramTexteAFiltrer)
        {

            while (paramTexteAFiltrer.Contains(Environment.NewLine + Environment.NewLine))
            {
                paramTexteAFiltrer = paramTexteAFiltrer.Replace(Environment.NewLine + Environment.NewLine, Environment.NewLine);
            }
            while (paramTexteAFiltrer.Contains("  "))
            {
                paramTexteAFiltrer = paramTexteAFiltrer.Replace("  "," ");
            }
            while (paramTexteAFiltrer.Contains(" " + Environment.NewLine))
            {
                paramTexteAFiltrer = paramTexteAFiltrer.Replace(" " + Environment.NewLine, Environment.NewLine);
            }
            while (paramTexteAFiltrer.Contains(Environment.NewLine + " "))
            {
                paramTexteAFiltrer = paramTexteAFiltrer.Replace(Environment.NewLine + " "  , Environment.NewLine);
            }
            paramTexteAFiltrer = paramTexteAFiltrer.Replace(Convert.ToString((char)10), "");

            return paramTexteAFiltrer;
        }
    }
}
