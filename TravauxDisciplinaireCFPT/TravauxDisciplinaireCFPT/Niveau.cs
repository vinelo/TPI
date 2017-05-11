using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace TravauxDisciplinaireCFPT
{
    class Niveau
    {
        //Champs
        private int _numeroNiveau;

        //Propriétés
        public int NumeroNiveau
        {
            get { return _numeroNiveau; }
            set { _numeroNiveau = value; }
        }

        //Constructeur
        public Niveau() : this(1) { }
        public Niveau(int paramNiveau)
        {
            NumeroNiveau = paramNiveau;
        }
        //Méthodes
        /// <summary>
        /// Choisi un texte correspondant au niveau
        /// </summary>
        /// <returns>Le texte</returns>
        public string ChoisirTexte()
        {
            ResourceManager rm = Properties.Resources.ResourceManager;
            string Texte = (string)rm.GetObject("TexteNiveau"+Convert.ToString(this.NumeroNiveau));
            return Texte;
        }
    }
}
