/*
 * Auteur : Vincent Naef 
 * Application : Travaux Disciplinaires au CFPT
 * Nom de la forme : frmCreation
 * Description de la forme : Ceci est la forme de création. C'est dans cette forme que l'utilisateur définira les données d'un travail avant de le créer.
 * Date de dernière modification : 23 mai 2017
 */

using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TravauxDisciplinaireCFPT
{
    public partial class frmCreation : Form
    {

        //Champs...
        private Niveau _niveauSelectionne;

        //Propriétés...
        private Niveau NiveauSelectionne
        {
            get
            {
                return _niveauSelectionne;
            }

            set
            {
                _niveauSelectionne = value;
                if (value == null)
                    UpdateVuePasDeNiveau();
                else
                    UpdateVueNiveauSelectionne();
                
            }
        }

        //Constructeurs...
        /// <summary>
        /// Constructeur de la forme frmCreation. Créer un nouveau niveau.
        /// </summary>
        public frmCreation()
        {
            InitializeComponent();
            NiveauSelectionne = new Niveau(ChoisirNiveau());

        }
        //Méthodes...

        /// <summary>
        /// Créer un travail avec les données saisies
        /// </summary>
        /// <returns>Renvoie un travail disciplinaire crée</returns>
        public TravailDisciplinaire CreerTravail()
        {
            string NomProfesseur = tbxNomProf.Text;
            string PrenomProfesseur = tbxPrenomProf.Text;
            string NomEleve = tbxNomEleve.Text;
            string PrenomEleve = tbxPrenomEleve.Text;
            string ClasseEleve = tbxClasseEleve.Text;

            TravailDisciplinaire Td;
            Td = new TravailDisciplinaire(new Eleve(NomEleve, PrenomEleve, ClasseEleve), new Personne(NomProfesseur, PrenomProfesseur), NiveauSelectionne);

            return Td;
        }

        /// <summary>
        /// Vérifie si les champs sont remplis
        /// </summary>
        /// <returns>Renvoie vrai si les champs sont remplis</returns>
        public bool VerifierChampsEtNiveau()
        {
            bool Validation = false;
            if (this.tbxClasseEleve.Text != "" && this.tbxNomEleve.Text != "" && this.tbxNomProf.Text != "" && this.tbxPrenomEleve.Text != "" && this.tbxPrenomProf.Text != "" && NiveauSelectionne != null)
            {
                Validation = true;
            }
            return Validation;
        }



        /// <summary>
        /// Lis le texte dans le fichier passé en paramètre
        /// </summary>
        /// <param name="paramFichier">Fichier à lire</param>
        /// <returns>Texte du fichier passé en paramètre</returns>
        public string LireTexte(string paramFichier)
        {
            string[] lireText = File.ReadAllLines(paramFichier, Encoding.Default);

            string Texte = "";
            foreach (string uneLigne in lireText)
            {
                Texte += uneLigne + Environment.NewLine;
            }
            return Texte;
        }

        /// <summary>
        /// Choisi le niveau correspondant à la "case" coché
        /// </summary>
        /// <returns>Niveau du texte</returns>
        public int ChoisirNiveau()
        {
            int NiveauARetourner = 0;
            if (rbnPersonnaliser.Checked == true)
                NiveauARetourner = 6;
            if (rbnNiveau1.Checked == true)
                NiveauARetourner = 1;
            if (rbnNiveau2.Checked == true)
                NiveauARetourner = 2;
            if (rbnNiveau3.Checked == true)
                NiveauARetourner = 3;
            if (rbnNiveau4.Checked == true)
                NiveauARetourner = 4;
            if (rbnNiveau5.Checked == true)
                NiveauARetourner = 5;

            return NiveauARetourner;
        }
        /// <summary>
        /// Affiche un texte incitant l'utilisateur à séléctionner un texte
        /// </summary>
        public void UpdateVuePasDeNiveau()
        {
            rbxApercu.Text = "Veuillez sélectionner un texte.";
            btnCreer.Enabled = VerifierChampsEtNiveau();
            btnPersonnaliser.Enabled = rbnPersonnaliser.Checked;
        }

        /// <summary>
        /// Raffraichit la vue en fonction des paramètres du niveau actuel
        /// </summary>
        public void UpdateVueNiveauSelectionne()
        {
            rbxApercu.Text = NiveauSelectionne.TexteARecopier;
            btnCreer.Enabled = VerifierChampsEtNiveau();
            btnPersonnaliser.Enabled = rbnPersonnaliser.Checked;
        }

        //Événements
        /// <summary>
        /// Cet événement est appelé lorsque l'utilisateur clique sur le bouton "...". Il lui permet de sélectionner un texte à travers une boîte de dialogue prévu à cette effet.
        /// </summary>
        private void btnPersonnaliser_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == ofdOuvrir.ShowDialog())
            {
                NiveauSelectionne = new Niveau(ChoisirNiveau(), LireTexte(ofdOuvrir.FileName));
                if (NiveauSelectionne.CalculerMinutesDuTexte() != 0)
                {
                    if (DialogResult.Cancel == MessageBox.Show("Ce texte prendra environ " + Convert.ToString(NiveauSelectionne.CalculerMinutesDuTexte() + " minutes à être recopié."), "Durée du texte", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                        NiveauSelectionne = null;
                }
                else
                {
                    if (DialogResult.Cancel == MessageBox.Show("Ce texte prendra moins de 10 minutes à être recopié.", "Durée du texte", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                        NiveauSelectionne = null;
                }
            }

        }

        /// <summary>
        /// Cet événement est appelé lorsque l'utilisateur tape du texte dans les zones de saisie. Il raffraîchit la vue.
        /// </summary>
        private void tbx_TextChanged(object sender, EventArgs e)
        {
            if(NiveauSelectionne != null)
                UpdateVueNiveauSelectionne();
        }

        /// <summary>
        /// Cet événement est appelé lorsque l'utilisateur change de niveau. Il raffraîchit la vue en fonction du bouton radio coché.
        /// </summary>
        private void rbnNiveau_CheckedChanged(object sender, EventArgs e)
        {
            if (ChoisirNiveau() == 6)
            {
                NiveauSelectionne = null;
                UpdateVuePasDeNiveau();
            }

            else
            {
                NiveauSelectionne = new Niveau(ChoisirNiveau());
                UpdateVueNiveauSelectionne();
            }
        }

        /// <summary>
        /// Cet événement est appelé lorsque la forme se crée. Il raffraichît la vue.
        /// </summary>
        private void frmCreation_Load(object sender, EventArgs e)
        {
            
            UpdateVueNiveauSelectionne();
        }
    }
}
