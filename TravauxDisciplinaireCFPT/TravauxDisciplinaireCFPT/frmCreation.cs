using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravauxDisciplinaireCFPT
{
    public partial class frmCreation : Form
    {

        //Champs...
        private string _texte;
        private Niveau _niveauSelectionne;

        //Propriétés...
        private string Texte
        {
            get { return _texte; }
            set { _texte = value; }
        }

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
        public frmCreation()
        {
            InitializeComponent();

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



        // A REFAIRE POUR SUPPRIMER LES ENTER EN TROP
        public string LireTexte(string paramFichier)
        {
            string[] lireText = File.ReadAllLines(paramFichier, Encoding.Default);

            Texte = "";
            foreach (string uneLigne in lireText)
            {
                Texte += uneLigne + Environment.NewLine;
            }
            return Texte;
        }
        public void UpdateVuePasDeNiveau()
        {
            rbxApercu.Text = "Veuillez sélectionner un texte.";
            btnCreer.Enabled = VerifierChampsEtNiveau();
            btnPersonnaliser.Enabled = rbnPersonnaliser.Checked;
        }

        /// <summary>
        /// Raffraichit la vue
        /// </summary>
        public void UpdateVueNiveauSelectionne()
        {
            //Choisi le texte à afficher en fonction du niveau

            rbxApercu.Text = NiveauSelectionne.TexteARecopier;
            btnCreer.Enabled = VerifierChampsEtNiveau();
            btnPersonnaliser.Enabled = rbnPersonnaliser.Checked;
        }

        //A REVOIR
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

        // A Refaire au propre pour filtrer les caractères et mettre dans une fonction
        private void btnPersonnaliser_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == ofdOuvrir.ShowDialog())
            {
                NiveauSelectionne = new Niveau(ChoisirNiveau(), LireTexte(ofdOuvrir.FileName));
                if (DialogResult.Cancel == MessageBox.Show("Ce texte prendra environ " + Convert.ToString(NiveauSelectionne.CalculerMinutesDuTexte() + " minutes à être recopié."), "Durée du texte", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                    NiveauSelectionne = null;
                
            }

        }

        private void tbx_TextChanged(object sender, EventArgs e)
        {
            UpdateVueNiveauSelectionne();
        }

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

        private void frmCreation_Load(object sender, EventArgs e)
        {
            NiveauSelectionne = new Niveau(ChoisirNiveau());
            UpdateVueNiveauSelectionne();
        }
    }
}
