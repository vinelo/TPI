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
        
        //Champs..

        private Personne _professeur;
        private Eleve _eleve;
        private string _hash;
        private int _progression;
        private Niveau _niveau;
        private DateTime _temps;
        private bool _valide;
        
        

        //Propriétés...

        internal Niveau Niveau
        {
            get { return _niveau; }
            set { _niveau = value; }
        }
        internal Personne Professeur
        {
            get { return _professeur; }
            set { _professeur = value; }
        }
        internal Eleve Eleve
        {
            get { return _eleve; }
            set { _eleve = value; }
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

        public DateTime Temps
        {
            get { return _temps; }
            set { _temps = value; }
        }


        //Constructeurs...

        /// <summary>
        /// Créer un travail disciplinaire avec des valeurs par défaut
        /// </summary>
        public TravailDisciplinaire() : this("NomProfesseur", "PrenomProfesseur", "NomEleve", "PrenomEleve", "ClasseEleve", 3) { }

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
            this.Niveau = new Niveau(paramNiveau, paramTexte);

            //Pour choisir le texte selon le niveau
           
            this.Progression = 0;
            this.Valide = true;
            this.Temps = new DateTime(0);
        }

        /// <summary>
        /// Vérifie si le caractère corresponds à celui qui doit être tapé
        /// </summary>
        /// <param name="paramCaractere">Caractère à vérifier</param>
        /// <returns>Le caractère tapé est-il le bon ? -> vrai ou faux</returns>
        public bool VerifierCaractere(char paramCaractere)
        {
            bool Verification = false;
            char CaractereATaper = this.Niveau.TexteARecopier[Progression];
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
        
        public bool EstFini()
        {
            bool Verification = false;
            if (this.Progression == this.CompterCaractere())
            {
                Verification = true;
            }
            return Verification;
        }
        
        /// <summary>
        /// Compte le nombre de caractère du texte
        /// </summary>
        /// <returns>Nombre de caractères</returns>
        public int CompterCaractere()
        {
            return this.Niveau.CompterCaractere();
        }

        /// <summary>
        /// Calcul le texte déjà tapé par l'utilisateur
        /// </summary>
        /// <returns>Texte déjà tapé par l'utilisateur</returns>
        public string GetTexteTapeParUtilisateur()
        {
            string TexteDejaCopie = "";
            for (int i = 0; i < this.Progression; i++)
            {
                TexteDejaCopie += this.Niveau.TexteARecopier[i];
            }
            return TexteDejaCopie;
        }

        public void AvancerTemps()
        {
            this.Temps = this.Temps.AddSeconds(1);
        }


        //Fonction à voir ou mettre avec Mr.Beney


        public string MinutesEtSecondesToString()
        {
            double UneSecondeEnTicks = 10000000;
            double ticks = this.Temps.Ticks;
            int minute = 0;
            int seconde = 0;
            string minutesEtSecondes = "";
            if (ticks / 600000000 >= 1)
            {
                minute = (int)Math.Round(ticks / UneSecondeEnTicks * 60);
                minutesEtSecondes = Convert.ToString(minute) + " minute(s) et ";
            }

            ticks = ticks - (minute * (UneSecondeEnTicks * 60));
            seconde = (int)Math.Round(ticks / UneSecondeEnTicks);

            minutesEtSecondes += Convert.ToString(seconde) + " seconde(s)";
            return minutesEtSecondes;
        }

        public string NiveauToString()
        {
            string NiveauToString = "";
            if (this.Niveau.NumeroNiveau == 6)
                NiveauToString = "Texte personnalisé" + " ( ~ " + Convert.ToString(this.Niveau.CalculerMinutesDuTexte()) + " minutes )";
            else
                NiveauToString = this.Niveau.NumeroNiveau + " ( ~ " + Convert.ToString(this.Niveau.CalculerMinutesDuTexte()) + " minutes )";
            return NiveauToString;
        }
    }
}
