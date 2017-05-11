using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravauxDisciplinaireCFPT
{
    [Serializable]
    public class TravailDisciplinaire
    {
        
        //Variables..

        private string _nomProfesseur;
        private string _prenomProfesseur;        
        private string _nomEleve;
        private string _prenomEleve;
        private string _classe;
        private string _texte;
        private string _hash;
        private int _progression;
        private int _totalCaractere;
        private int _tempsPris;
        private int _niveau;
        private double _temps;
        private bool _valide;
        
        

        //Propriétés...

        public double Temps
        {
            get { return _temps; }
            set { _temps = value; }
        }
        public string NomProfesseur
        {
            get { return _nomProfesseur; }
            set { _nomProfesseur = value; }
        }

        public string PrenomProfesseur
        {
            get { return _prenomProfesseur; }
            set { _prenomProfesseur = value; }
        }

        public string NomEleve
        {
            get { return _nomEleve; }
            set { _nomEleve = value; }
        }

        public string PrenomEleve
        {
            get { return _prenomEleve; }
            set { _prenomEleve = value; }
        }

        public string Classe
        {
            get { return _classe; }
            set { _classe = value; }
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

        public int TotalCaractere
        {
            get { return _totalCaractere; }
            set { _totalCaractere = value; }
        }
        
        public int TempsPris
        {
            get { return _tempsPris; }
            set { _tempsPris = value; }
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

        public int Niveau
        {
            get { return _niveau; }
            set { _niveau = value; }
        }

        //Constructeurs...

        /// <summary>
        /// Créer un travail disciplinaire avec des valeurs par défaut
        /// </summary>
        public TravailDisciplinaire() : this("NomProfesseur", "PrenomProfesseur", "NomEleve", "PrenomEleve", "ClasseEleve", 6, "Texte Exemple") { }

        /// <summary>
        /// Créer un nouveau travail disciplinaire avec le texte correspondant niveau séléctionné
        /// </summary>
        /// <param name="paramNomProf">Nom du professeur</param>
        /// <param name="paramPrenomProf">Prenom du professeur</param>
        /// <param name="paramNomEleve">Nom de l'élève</param>
        /// <param name="paramPrenomEleve">Prenom de l'élève</param>
        /// <param name="paramClasse">Classe de l'élève</param>
        /// <param name="paramTexte">Texte à recopier</param>
        public TravailDisciplinaire(string paramNomProf, string paramPrenomProf, string paramNomEleve, string paramPrenomEleve, string paramClasse, int paramNiveau) : this(paramNomProf, paramPrenomProf, paramNomEleve, paramPrenomEleve, paramClasse, paramNiveau, ""){ }
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
            this.NomProfesseur = paramNomProf;
            this.PrenomProfesseur = paramPrenomProf;
            this.NomEleve = paramNomEleve;
            this.PrenomEleve = paramPrenomEleve;
            this.Classe = paramClasse;
            this.Niveau = paramNiveau;

            //Pour choisir le texte selon le niveau
            switch(Niveau)
            {
                case 1:
                    this.Texte = Properties.Resources.TexteExemple;
                    this.TotalCaractere = this.Texte.Length;
                    break;
                case 2:
                    this.Texte = Properties.Resources.TexteExemple;
                    this.TotalCaractere = this.Texte.Length;
                    break;
                case 3:
                    this.Texte = Properties.Resources.TexteExemple;
                    this.TotalCaractere = this.Texte.Length;
                    break;
                case 4:
                    this.Texte = Properties.Resources.TexteExemple;
                    this.TotalCaractere = this.Texte.Length;
                    break;
                case 5:
                    this.Texte = Properties.Resources.TexteExemple;
                    this.TotalCaractere = this.Texte.Length;
                    break;
                case 6:
                    this.Texte = paramTexte;
                    this.TotalCaractere = this.Texte.Length;
                    break;
            }

            
            
            this.Progression = 0;
            this.Valide = true;
            this.Temps = 0;
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
        
        public bool VerifierFin()
        {
            bool Verification = false;
            if (this.Progression == this.TotalCaractere)
            {
                Verification = true;
            }
            return Verification;
        }


    }
}
