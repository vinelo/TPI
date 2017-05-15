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
        const int SECONDS_AVANT_ARRET_DU_TIMER = 5;


        private List<TravailDisciplinaire> _listeTravauxDisciplinaires;
        private int _indexTravailSelectionne;
        private int _secondesInactif;
        private int _nbCaractereTapeDepuisDernierScroll;


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

        private int NbCaractereTapeDepuisDernierScroll
        {
            get
            {
                return _nbCaractereTapeDepuisDernierScroll;
            }

            set
            {
                _nbCaractereTapeDepuisDernierScroll = value;
            }
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
                //Surlignage du texte tapé
                this.rbxTexteExemple.SelectionStart = 0;
                this.rbxTexteExemple.SelectionLength = rbxTexteExemple.Text.Length;
                this.rbxTexteExemple.SelectionBackColor = Color.WhiteSmoke;

                this.rbxTexteExemple.SelectionStart = 0;
                this.rbxTexteExemple.SelectionLength = this.ListeTravauxDisciplinaires[IndexTravailSelectionne].Progression;
                this.rbxTexteExemple.SelectionBackColor = Color.LightGray;
                //Temps
                lblTemps.Text = this.ListeTravauxDisciplinaires[IndexTravailSelectionne].MinutesEtSecondesToString();
                this.pgbBarreProgression.Value = this.ListeTravauxDisciplinaires[IndexTravailSelectionne].CalculerPoucentageEffectue() * 10;
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
            this.rbxTexteExemple.Text = this.ListeTravauxDisciplinaires[IndexTravailSelectionne].Niveau.TexteARecopier;
            tbxCopieTexte.Text = this.ListeTravauxDisciplinaires[IndexTravailSelectionne].GetTexteTapeParUtilisateur();


            //Scroll
            tbxCopieTexte.SelectionStart = tbxCopieTexte.Text.Length;
            // scroll it automatically
            tbxCopieTexte.ScrollToCaret();
            rbxTexteExemple.SelectionStart = tbxCopieTexte.Text.Length;
            rbxTexteExemple.ScrollToCaret();
            NbCaractereTapeDepuisDernierScroll = 0;
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
            Brush Fond = Brushes.White;
            Brush FondSelectionne = Brushes.LightGray;
            Brush Stylo = Brushes.Black;
            Brush Vert = Brushes.Green;
            Brush Gris = Brushes.Gray;

            //remplis l'arrière plan d'une couleur différente en fonction de si c'est l'item sélectionné
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e.Graphics.FillRectangle(FondSelectionne, e.Bounds);
            else
                e.Graphics.FillRectangle(Fond, e.Bounds);

            //Pour chaque item de la liste dessine l'intérieur
            if (e.Index >= 0)
            {
                if (ListeTravauxDisciplinaires[e.Index].Valide == true)
                {
                    //Affichage professeur
                    e.Graphics.DrawString("Professeur :",
                       e.Font, Stylo, e.Bounds.X, e.Bounds.Y + 10);
                    e.Graphics.DrawString(ListeTravauxDisciplinaires[e.Index].Professeur.ToString(),
                       e.Font, Stylo, e.Bounds.X + 90, e.Bounds.Y + 10);
                    //Affichage élève
                    e.Graphics.DrawString("Élève :",
                       e.Font, Stylo, e.Bounds.X + 35, e.Bounds.Y + 30);
                    e.Graphics.DrawString(ListeTravauxDisciplinaires[e.Index].Eleve.ToString(),
                       e.Font, Stylo, e.Bounds.X + 90, e.Bounds.Y + 30);
                    //Affichage du temps passé sur le travail
                    e.Graphics.DrawString("Temps effectif du travail :",
                       e.Font, Stylo, e.Bounds.X, e.Bounds.Y + 50);
                    e.Graphics.DrawString(ListeTravauxDisciplinaires[e.Index].MinutesEtSecondesToString(),
                       e.Font, Stylo, e.Bounds.X + 180, e.Bounds.Y + 50);
                    //Date de début
                    e.Graphics.DrawString("Date de début :",
                       e.Font, Stylo, e.Bounds.X + 300, e.Bounds.Y + 50);
                    e.Graphics.DrawString(ListeTravauxDisciplinaires[e.Index].DateDeDebut.ToString("dd/MM/yyyy"),
                       e.Font, Stylo, e.Bounds.X + 415, e.Bounds.Y + 50);
                    //Affichage Niveau
                    e.Graphics.DrawString("Niveau :",
                       e.Font, Stylo, e.Bounds.X + 345, e.Bounds.Y + 10);
                    e.Graphics.DrawString(ListeTravauxDisciplinaires[e.Index].NiveauToString(),
                       e.Font, Stylo, e.Bounds.X + 415, e.Bounds.Y + 10);

                    //Barre de progression

                    e.Graphics.DrawString("Progression :",
                       e.Font, Stylo, e.Bounds.X + 312, e.Bounds.Y + 30);
                    Rectangle BarreProgressionGris = new Rectangle(e.Bounds.X + 418, e.Bounds.Y + 30, 304, 16);
                    e.Graphics.FillRectangle(Gris, BarreProgressionGris);

                    Rectangle BarreProgressionVert = new Rectangle(e.Bounds.X + 420, e.Bounds.Y + 34, this.ListeTravauxDisciplinaires[e.Index].CalculerPoucentageEffectue() * 3, 10);
                    e.Graphics.FillRectangle(Vert, BarreProgressionVert);
                    //Temps passé sur le travail
                    //e.Graphics.DrawString("Élève :",
                    //   e.Font, stylo, e.Bounds.X, e.Bounds.Y + 30);
                    //e.Graphics.DrawString(ListeTravauxDisciplinaires[e.Index].Eleve.ToString(),
                    //   e.Font, stylo, e.Bounds.X + 90, e.Bounds.Y + 30);
                }
                else
                {
                    e.Graphics.DrawString("Fichier corrompu !", e.Font, Stylo, (e.Bounds.X / 2) + 10, (e.Bounds.Y / 2) + 2);
                }

                e.DrawFocusRectangle();
                //Contour
                e.Graphics.DrawRectangle(new Pen(Color.Black), e.Bounds);

            }
        }

        private void btnEditer_Click(object sender, EventArgs e)
        {
            //Sélectionne le travail choisi par l'utilisateur
            this.IndexTravailSelectionne = lsbListeTravaux.SelectedIndex;
            tbcPrincipale.SelectTab(0);

            //Update la vue de la page travail
            UpdateVueBouton();
            UpdateVueTexteUtilisateur();
            UpdateVueSelection(); // "true" car on veut que le texte déjà écrit s'affiche
        }

        private void tbxCopieTexte_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Si l'index est hors du tableau alors ne fait rien
            if (ListeTravauxDisciplinaires[IndexTravailSelectionne].Progression + 1 > ListeTravauxDisciplinaires[IndexTravailSelectionne].CompterCaractere() || this.ListeTravauxDisciplinaires[this.IndexTravailSelectionne].VerifierCaractere(e.KeyChar) == true)
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
            //Gère le temps à ajouté au travail en fonction de l'activité de l'utilisateur
            if (SecondesInactif >= SECONDS_AVANT_ARRET_DU_TIMER)
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
            //Ouvre l'onglet d'enregistrement et enregistre le travail à l'emplacement demandé par l'utilisateur
            if (sfdSauvegarder.ShowDialog() == DialogResult.OK)
            {
                this.ListeTravauxDisciplinaires[IndexTravailSelectionne].Serialiser(sfdSauvegarder.FileName);
            }
        }

        private void tsiOuvrir_Click(object sender, EventArgs e)
        {
            //Ajoute à la liste le fichier ouvert si celui-ci n'est pas incompatible ou corrompu
            if (ofdOuvrirFichier.ShowDialog() == DialogResult.OK)
            {
                //Si il y a une erreur au niveau de la lecture du fichier alors celui-ci est incompatible ou corrompu
                try
                {
                    TravailDisciplinaire td = new TravailDisciplinaire();
                    td = td.Deserialiser(ofdOuvrirFichier.FileName);
                    if (td.VerifierDonneeTravail())
                    {
                        ListeTravauxDisciplinaires.Add(td.Deserialiser(ofdOuvrirFichier.FileName));
                        UpdateVueList();
                        MessageBox.Show("Votre travail à bien été ajouté.");
                    }
                    else
                    {
                        MessageBox.Show("Ce fichier est incompatible ou corrompu");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ce fichier est incompatible ou corrompu");
                }

            }
        }

        private void tbxCopieTexte_TextChanged(object sender, EventArgs e)
        {
            //Scroll afin d'afficher le texte à recopier
            this.NbCaractereTapeDepuisDernierScroll += 1;
            if (NbCaractereTapeDepuisDernierScroll == 100)
            {
                tbxCopieTexte.SelectionStart = tbxCopieTexte.Text.Length;
                // scroll it automatically
                tbxCopieTexte.ScrollToCaret();
                rbxTexteExemple.SelectionStart = tbxCopieTexte.Text.Length - 100;
                rbxTexteExemple.ScrollToCaret();
                NbCaractereTapeDepuisDernierScroll = 0;
            }
        }
    }
}
