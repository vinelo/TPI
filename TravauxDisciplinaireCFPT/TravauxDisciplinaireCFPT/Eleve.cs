using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravauxDisciplinaireCFPT
{
    [Serializable]
    class Eleve : Personne
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
