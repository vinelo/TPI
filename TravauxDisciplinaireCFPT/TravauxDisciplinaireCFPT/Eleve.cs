/*
 * Auteur : Vincent Naef 
 * Application : Travaux Disciplinaires au CFPT
 * Nom de la classe : Eleve
 * Description de la classe : Cette classe descend de la classe "Personne". C'est ici qu'est stocké, en plus du nom et du prénom, la classe de l'élève chargé du travail disciplinaire.
 * Date de dernière modification : 23 mai 2017
 */

using System;

namespace TravauxDisciplinaireCFPT
{
    [Serializable]
    public class Eleve : Personne
    {
        private string _classe;

        public string Classe
        {
            get { return _classe; }
            set { _classe = value; }
        }

        /// <summary>
        /// Constructeur de la classe Eleve
        /// </summary>
        public Eleve() : this("NomEleve", "PrenomEleve", "ClasseEleve") { }
        /// <summary>
        /// Constructeur de la classe Eleve
        /// </summary>
        /// <param name="paramNom">Nom de l'élève</param>
        /// <param name="paramPrenom">Prenom de l'élève</param>
        /// <param name="paramClasse">Classe de l'élève</param>
        public Eleve(string paramNom, string paramPrenom, string paramClasse)
        {
            this.Nom = paramNom;
            this.Prenom = paramPrenom;
            this.Classe = paramClasse;
        }
    }
}
