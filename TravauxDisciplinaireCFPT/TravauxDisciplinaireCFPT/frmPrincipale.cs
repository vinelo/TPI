using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravauxDisciplinaireCFPT
{
    public partial class frmPrincipale : Form
    {
        //Champs...


        private List<TravailDisciplinaire> _listeTravauxDisciplinaires;
        private int _indexTravailSelectionne;
        private int _secondesInactif;

        //Propriétés...

        public int IndexTravailSelectionne
        {
            get { return _indexTravailSelectionne; }
            set { _indexTravailSelectionne = value; }
        }

        internal List<TravailDisciplinaire> ListeTravauxDisciplinaires
        {
            get { return _listeTravauxDisciplinaires; }
            set
            {
                _listeTravauxDisciplinaires = value;
            }
        }
        public int SecondesInactif
        {
            get { return _secondesInactif; }
            set { _secondesInactif = value; }
        }

        //Constructeurs...


        public frmPrincipale()
        {
            InitializeComponent();
            ListeTravauxDisciplinaires = new List<TravailDisciplinaire>();
            UpdateVueBouton();
            tbcPrincipale.SelectTab(1);
        }


        //Méthodes...

        #region UpdateVue
        /// <summary>
        /// Grise ou dégrise les bouton supprimer et editer
        /// </summary>
        public void UpdateVueBouton()
        {
            this.btnSupprimer.Enabled = EstIndexSelectionne();
            this.btnEditer.Enabled = EstIndexSelectionne();
        }
        /// <summary>
        /// Raffraichit la liste
        /// </summary>
        public void UpdateVueList()
        {
            //Liste
            if (ListeTravauxDisciplinaires != null)
            {
                lsbListeTravaux.Items.Clear();
                foreach (TravailDisciplinaire travail in this.ListeTravauxDisciplinaires)
                {
                    lsbListeTravaux.Items.Add(travail);
                }
            }
        }
        /// <summary>
        /// Affiche le travail sélectionné dans l'onglet "travail"
        /// </summary>
        public void UpdateVueSelection()
        {

            if (ListeTravauxDisciplinaires != null)
            {
                //Affichage du Texte Exemple
                this.rbxTexteExemple.Text = "";
                this.rbxTexteExemple.AppendText(this.ListeTravauxDisciplinaires[IndexTravailSelectionne].Niveau.TexteARecopier);
                this.rbxTexteExemple.SelectionStart = 0;
                this.rbxTexteExemple.SelectionLength = this.ListeTravauxDisciplinaires[IndexTravailSelectionne].Progression;
                this.rbxTexteExemple.SelectionBackColor = Color.LightGray;
                //Temps
                lblTemps.Text = this.ListeTravauxDisciplinaires[IndexTravailSelectionne].MinutesEtSecondesToString();
                //Affichage du reste
                this.lblClasse.Text = ListeTravauxDisciplinaires[IndexTravailSelectionne].Eleve.Classe;
                this.lblProfesseur.Text = ListeTravauxDisciplinaires[IndexTravailSelectionne].Professeur.ToString();
                this.lblEleve.Text = ListeTravauxDisciplinaires[IndexTravailSelectionne].Eleve.ToString();
                this.lblTravailAccompli.Text = Convert.ToString(ListeTravauxDisciplinaires[IndexTravailSelectionne].Progression) + " caractère(s) sur " + Convert.ToString(ListeTravauxDisciplinaires[IndexTravailSelectionne].CompterCaractere());

                //Affichage du niveau sélectionné
                lblNiveau.Text = this.ListeTravauxDisciplinaires[IndexTravailSelectionne].NiveauToString();

            }
        }

        /// <summary>
        /// Afficher le texte déjà tapé par l'utilisateur
        /// </summary>
        public void UpdateVueTexteUtilisateur()
        {
            tbxCopieTexte.Text = this.ListeTravauxDisciplinaires[IndexTravailSelectionne].GetTexteTapeParUtilisateur();
        }

        #endregion


        /// <summary>
        /// Détermine si un travail est sélectionné dans la liste
        /// </summary>
        /// <returns>Travail sélectionné dans la liste -> vrai ou faux</returns>
        public bool EstIndexSelectionne()
        {
            bool EstIndexSelectionne = false;
            if (lsbListeTravaux.SelectedIndex != -1)
                EstIndexSelectionne = true;
            return EstIndexSelectionne;
        }






        //Événements...

        //Affiche le formulaire de création et nous renvoie le résultat de celui-ci
        private void tsiNouveau_Click(object sender, EventArgs e)
        {
            frmCreation Creation = new frmCreation();
            //Si l'utilisateur a cliqué sur "OK", Récupère le travail créer dans le formulaire de création et l'ajoute dans la liste
            if (Creation.ShowDialog() == DialogResult.OK)
            {
                ListeTravauxDisciplinaires.Add(Creation.CreerTravail());
                UpdateVueList();
                tbcPrincipale.SelectTab(1);
            }
        }

        private void lsbListeTravaux_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            // Determine la couleur des stylos que l'on va utiliser
            Brush fond = Brushes.White;
            Brush fondSelectionne = Brushes.LightGray;
            Brush stylo = Brushes.Black;

            //remplis l'arrière plan d'une couleur différente en fonction de si c'est l'item sélectionné
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e.Graphics.FillRectangle(fondSelectionne, e.Bounds);
            else
                e.Graphics.FillRectangle(fond, e.Bounds);

            //Pour chaque item de la liste dessine l'intérieur
            if (e.Index >= 0)
            {
                if (ListeTravauxDisciplinaires[e.Index].Valide == true)
                {
                    //Affichage professeur
                    e.Graphics.DrawString("Professeur :",
                       e.Font, stylo, e.Bounds.X, e.Bounds.Y + 10);
                    e.Graphics.DrawString(ListeTravauxDisciplinaires[e.Index].Professeur.ToString(),
                       e.Font, stylo, e.Bounds.X + 90, e.Bounds.Y + 10);
                    //Affichage élève
                    e.Graphics.DrawString("Élève :",
                       e.Font, stylo, e.Bounds.X, e.Bounds.Y + 30);
                    e.Graphics.DrawString(ListeTravauxDisciplinaires[e.Index].Eleve.ToString(),
                       e.Font, stylo, e.Bounds.X + 90, e.Bounds.Y + 30);
                    //Temps passé sur le travail
                    //e.Graphics.DrawString("Élève :",
                    //   e.Font, stylo, e.Bounds.X, e.Bounds.Y + 30);
                    //e.Graphics.DrawString(ListeTravauxDisciplinaires[e.Index].Eleve.ToString(),
                    //   e.Font, stylo, e.Bounds.X + 90, e.Bounds.Y + 30);
                }
                else
                {
                    e.Graphics.DrawString("Fichier corrompu !", e.Font, stylo, (e.Bounds.X / 2) + 10, (e.Bounds.Y / 2) + 2);
                }

                e.DrawFocusRectangle();
                //Contour
                e.Graphics.DrawRectangle(new Pen(Color.Black), e.Bounds);

            }
        }

        private void btnEditer_Click(object sender, EventArgs e)
        {
            this.IndexTravailSelectionne = lsbListeTravaux.SelectedIndex;
            tbcPrincipale.SelectTab(0);

            UpdateVueBouton();
            UpdateVueTexteUtilisateur();
            UpdateVueSelection(); // "true" car on veut que le texte déjà écrit s'affiche
        }

        private void tbxCopieTexte_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Si l'index est hors du tableau alors ne fait rien
            if (ListeTravauxDisciplinaires[IndexTravailSelectionne].Progression + 1 > ListeTravauxDisciplinaires[IndexTravailSelectionne].CompterCaractere() || this.ListeTravauxDisciplinaires[this.IndexTravailSelectionne].VerifierCaractere(e.KeyChar) == false)
            {
                e.Handled = true;
            }
            //Sinon Avance la progression de 1 et Update la vue du travail sélectionné
            else
            {
                this.ListeTravauxDisciplinaires[IndexTravailSelectionne].AvancerProgression();
                UpdateVueSelection();
                SecondesInactif = 0;
            }

            //verifie si le travail est fini
            if (this.ListeTravauxDisciplinaires[IndexTravailSelectionne].EstFini())
            {
                MessageBox.Show("Vous avez terminé !");
                tmrTempsEffectif.Enabled = false;
            }

            //Timer activer
            tmrTempsEffectif.Enabled = true;
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            //Vérifie si un travail est sélectionné
            if (lsbListeTravaux.SelectedIndex != -1)
            {
                ListeTravauxDisciplinaires.RemoveAt(lsbListeTravaux.SelectedIndex);
                this.UpdateVueBouton();
            }
        }

        private void lsbListeTravaux_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateVueBouton();
        }

        private void tmrTempsEffectif_Tick(object sender, EventArgs e)
        {
            if (SecondesInactif >= 3)
                tmrTempsEffectif.Enabled = false;
            else
            {
                this.ListeTravauxDisciplinaires[IndexTravailSelectionne].AvancerTemps();
                UpdateVueSelection();
                SecondesInactif += 1;
            }

        }

        private void tsiEnregistrer_Click(object sender, EventArgs e)
        {
            if (sfdSauvegarder.ShowDialog() == DialogResult.OK)
            {
                this.ListeTravauxDisciplinaires[IndexTravailSelectionne].Serialiser(sfdSauvegarder.FileName);
            }
        }

        private void tsiEnregistrerSous_Click(object sender, EventArgs e)
        {

        }

        private void tsiOuvrir_Click(object sender, EventArgs e)
        {
            if (ofdOuvrirFichier.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    TravailDisciplinaire td = new TravailDisciplinaire();
                    ListeTravauxDisciplinaires.Add(td.Deserialiser(ofdOuvrirFichier.FileName));
                    UpdateVueList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ce fichier est corrompu");
                }
                
            }
        }


    }
}
