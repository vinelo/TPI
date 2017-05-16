using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TravauxDisciplinaireCFPT
{
    [Serializable]
    public class TravailDisciplinaire
    {

        const string AVERTISSEMENT = @"/!\ ATTENTION /!\ Ce fichier est protégé, en cas de modifications, ce fichier sera affiché comme illisible ou corrompu lorsqu'il sera rechargé par le programme Travaux Disciplinaire au CFPT /!\ ATTENTION /!\";
        //Champs..

        private DateTime _dateDeDebut;
        private Personne _professeur;
        private Eleve _eleve;
        private string _cleValidation;
        private string _hash;
        private int _progression;
        private Niveau _niveau;
        private DateTime _temps;
        private DateTime _dateDerniereModification;
        private bool _valide;



        //Propriétés...

        public DateTime DateDeDebut
        {
            get { return _dateDeDebut; }
            set { _dateDeDebut = value; }
        }
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
        public string CleValidation
        {
            get { return _cleValidation; }
            set { _cleValidation = value; }
        }

        public DateTime DateDerniereModification
        {
            get { return _dateDerniereModification; }
            set { _dateDerniereModification = value; }
        }


        //Constructeurs...

        /// <summary>
        /// Créer un travail disciplinaire avec des valeurs par défaut
        /// </summary>
        public TravailDisciplinaire() : this("NomProfesseur", "PrenomProfesseur", "NomEleve", "PrenomEleve", "ClasseEleve", new Niveau()) { }


        /// <summary>
        /// Créer un nouveau travail disciplinaire
        /// </summary>
        /// <param name="paramNomProf">Nom du professeur</param>
        /// <param name="paramPrenomProf">Prenom du professeur</param>
        /// <param name="paramNomEleve">Nom de l'élève</param>
        /// <param name="paramPrenomEleve">Prenom de l'élève</param>
        /// <param name="paramClasse">Classe de l'élève</param>
        /// <param name="paramNiveau">Niveau du travail</param>
        public TravailDisciplinaire(string paramNomProf, string paramPrenomProf, string paramNomEleve, string paramPrenomEleve, string paramClasse, Niveau paramNiveau)
        {
            //Initialise les données
            this.Eleve = new Eleve(paramNomEleve, paramPrenomEleve, paramClasse);
            this.Professeur = new Personne(paramNomProf, paramPrenomProf);
            this.Niveau = paramNiveau;

            //Pour choisir le texte selon le niveau

            this.Progression = 0;
            this.Valide = true;
            this.Temps = new DateTime(0);
            this.DateDeDebut = DateTime.Now;

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
            if (CaractereATaper == paramCaractere)
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
        /// Calclul et renvoie le pourcentage effectué du travail
        /// </summary>
        /// <returns>Pourcentage effectué</returns>
        public int CalculerPoucentageEffectue()
        {
            double a = Convert.ToDouble(this.Niveau.CompterCaractere());
            double Pourcentage = Convert.ToDouble(this.Progression) / Convert.ToDouble(this.Niveau.CompterCaractere()) * 100;
            return (int)Pourcentage;
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

        /// <summary>
        /// Retourne le temps passé par l'élève sur le projet
        /// </summary>
        /// <returns>Temps passé sur le projet sous forme de texte</returns>
        public string MinutesEtSecondesToString()
        {
            long UneSecondeEnTicks = 10000000;
            long ticks = this.Temps.Ticks;
            int minute = 0;
            int seconde = 0;
            string minutesEtSecondes = "";
            if (ticks / 600000000 >= 1)
            {
                minute = (Convert.ToInt32(Math.Round((double)ticks / UneSecondeEnTicks * 60)));
                minutesEtSecondes = Convert.ToString(minute) + " min et ";
            }

            ticks = ticks - (minute * (UneSecondeEnTicks * 60));
            seconde = (int)Math.Round((double)ticks / UneSecondeEnTicks);

            minutesEtSecondes += Convert.ToString(seconde) + " sec";
            return minutesEtSecondes;
        }

        /// <summary>
        /// Retourne  l'objet "Niveau" sous forme de texte
        /// </summary>
        /// <returns>Objet "Niveau" sous forme de texte</returns>
        public string NiveauToString()
        {
            return Niveau.ToString();
        }

        /// <summary>
        /// Retourne l'objet "TravailDisciplinaire" sous forme de texte
        /// </summary>
        /// <returns>Objet "TravailDisciplinaire" sous forme de texte</returns>
        public override string ToString()
        {
            string Travail = this.Eleve.ToString() + this.Professeur.ToString() + Convert.ToString(this.Progression) + Convert.ToString(this.Temps) + Niveau.ToString() + this.DateDeDebut;
            return Travail;
        }

        /// <summary>
        /// Sauvegarde le travail dans le répértoire passé en paramètre
        /// </summary>
        /// <param name="paramChemin">Chemin du répértoire</param>
        public void Serialiser(string paramChemin)
        {
            this.DateDerniereModification = DateTime.Now;
            this.CryptageTravail();
            FileStream stream = File.Create(paramChemin);
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Close();
        }
        /// <summary>
        /// Ouvre le fichier correspondant au chemin passé en paramètre
        /// </summary>
        /// <param name="paramFichier">Chemin du fichier</param>
        /// <returns></returns>
        public TravailDisciplinaire Deserialiser(string paramFichier)
        {
            var formatter = new BinaryFormatter();
            FileStream stream = File.OpenRead(paramFichier);

            try
            {
                TravailDisciplinaire td = (TravailDisciplinaire)formatter.Deserialize(stream);
                //td.VerifierCleValidation();
                return td;

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                stream.Close();
            }


        }
        /// <summary>
        /// Crypte le travail et stocke les données cryptées dans "CleValidation"
        /// </summary>
        public void CryptageTravail()
        {

            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
            byte[] Donnees = Encoding.Default.GetBytes(this.ToString());
            Donnees = MD5.ComputeHash(Donnees);
            this.CleValidation = Convert.ToBase64String(Donnees);

        }
        /// <summary>
        /// Vérifie si le travail a été modifié 
        /// </summary>
        /// <returns></returns>
        public bool VerifierDonneeTravail()
        {
            bool Verification = false;
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
            byte[] DonneesAVerifier = Encoding.Default.GetBytes(this.ToString());
            DonneesAVerifier = Encoding.Default.GetBytes(this.ToString());
            DonneesAVerifier = MD5.ComputeHash(DonneesAVerifier);
            string DonneesEncodeesAVerifier = Convert.ToBase64String(DonneesAVerifier);

            if (DonneesEncodeesAVerifier == this.CleValidation)
                Verification = true;

            return Verification;
        }

        
    }
}
