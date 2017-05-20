using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravauxDisciplinaireCFPT
{
    [Serializable]
    public class Personne
    {
        //Champs...
        private string _nom;
        private string _prenom;

        //Propriétés

        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        //Constructeur
        /// <summary>
        /// Constructeur de la classe personne
        /// </summary>
        public Personne() : this("NomDeLaPersonne", "PrenomDeLaPersonne") { }
        /// <summary>
        /// Constructeur de la classe personne
        /// </summary>
        /// <param name="paramNom">Nom de la personne</param>
        /// <param name="paramPrenom">Prenom de la personne</param>
        public Personne(string paramNom, string paramPrenom)
        {
            this.Nom = paramNom;
            this.Prenom = paramPrenom;
        }
        //Méthodes
        /// <summary>
        /// Renvoie les information de la personne sous forme de texte
        /// </summary>
        /// <returns>Nom et Prenom de la personne</returns>
        public override string ToString()
        {
            string Personne = this.Nom + " " + this.Prenom;
            return Personne;
        }

    }
}
