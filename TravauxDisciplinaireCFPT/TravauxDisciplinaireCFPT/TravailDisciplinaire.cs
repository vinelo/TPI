using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;

namespace TravauxDisciplinaireCFPT
{
    [Serializable]
    public class TravailDisciplinaire
    {
        
        //Variables..

        private Eleve _eleve;
        private Personne _professeur;
        private DateTime _dureeEffective;
        private string _texte;
        private string _hash;
        private int _progression;
        private Niveau _niveau;
        private bool _valide;
        
        

        //Propriétés...
        internal Eleve Eleve
        {
            get { return _eleve; }
            set { _eleve = value; }
        }
        internal Personne Professeur
        {
            get { return _professeur; }
            set { _professeur = value; }
        }

        public DateTime DureeEffective
        {
            get { return _dureeEffective; }
            set { _dureeEffective = value; }
        }
        internal Niveau Niveau
        {
            get { return _niveau; }
            set { _niveau = value; }
        }
        public string Texte
        {
            get { return _texte; }
            set { _texte = value; }
        }

        public int Progression
        {
            get { return _progression; }
            set { _progression = value; }
        }

        public bool Valide
        {
            get { return _valide; }
            set { _valide = value; }
        }

        public string Hash
        {
            get { return _hash; }
            set { _hash = value; }
        }

        //Constructeurs...

        /// <summary>
        /// Créer un travail disciplinaire avec des valeurs par défaut
        /// </summary>
        public TravailDisciplinaire() : this("NomProfesseur", "PrenomProfesseur", "NomEleve", "PrenomEleve", "ClasseEleve", 6, null) { }

        /// <summary>
        /// Créer un nouveau travail disciplinaire avec le texte correspondant niveau séléctionné
        /// </summary>
        /// <param name="paramNomProf">Nom du professeur</param>
        /// <param name="paramPrenomProf">Prenom du professeur</param>
        /// <param name="paramNomEleve">Nom de l'élève</param>
        /// <param name="paramPrenomEleve">Prenom de l'élève</param>
        /// <param name="paramClasse">Classe de l'élève</param>
        /// <param name="paramTexte">Texte à recopier</param>
        public TravailDisciplinaire(string paramNomProf, string paramPrenomProf, string paramNomEleve, string paramPrenomEleve, string paramClasse, int paramNiveau) : this(paramNomProf, paramPrenomProf, paramNomEleve, paramPrenomEleve, paramClasse, paramNiveau, null){ }
        /// <summary>
        /// Créer un nouveau travail disciplinaire
        /// </summary>
        /// <param name="paramNomProf">Nom du professeur</param>
        /// <param name="paramPrenomProf">Prenom du professeur</param>
        /// <param name="paramNomEleve">Nom de l'élève</param>
        /// <param name="paramPrenomEleve">Prenom de l'élève</param>
        /// <param name="paramClasse">Classe de l'élève</param>
        /// <param name="paramTexte">Texte à recopier</param>
        /// <param name="paramNiveau">Niveau du texte</param>
        public TravailDisciplinaire(string paramNomProf, string paramPrenomProf, string paramNomEleve, string paramPrenomEleve, string paramClasse, int paramNiveau, string paramTexte)
        {
            //Initialise les données
            this.Eleve = new Eleve(paramNomEleve, paramPrenomEleve, paramClasse);
            this.Professeur = new Personne(paramNomProf, paramPrenomProf);
            this.Niveau = new Niveau(paramNiveau);

            if (paramTexte == null)
                this.Texte = Niveau.ChoisirTexte();
            else
                this.Texte = paramTexte;
            
            this.Progression = 0;
            this.Valide = true;
        }

        /// <summary>
        /// Vérifie si le caractère correspond à celui qui doit être tapé
        /// </summary>
        /// <param name="paramCaractere">Caractère à vérifier</param>
        /// <returns>Si le caractère entré est le bon</returns>
        public bool VerifierCaractere(char paramCaractere)
        {
            bool Verification = false;
            char CaractereATaper = this.Texte[this.Progression];
            if(CaractereATaper == paramCaractere)
            {
                Verification = true;
            }
            return Verification;
        }
        /// <summary>
        /// Avance la progression de 1
        /// </summary>
        public void AvancerProgression()
        {
            Progression += 1;
        }
        /// <summary>
        /// Vérifie si l'utilisateur à finit son travail disciplinaire
        /// </summary>
        /// <returns>Vérification</returns>
        public bool EstFini()
        {
            bool EstFini = false;
            if (this.Progression == this.CompterCaractere())
            {
                EstFini = true;
            }
            return EstFini;
        }
        /// <summary>
        /// Compte le nombre de caractères total
        /// </summary>
        /// <returns>Nombre de caractère total</returns>
        public int CompterCaractere()
        {
            return this.Texte.Count();
        }




    }
}
