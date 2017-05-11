using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        //Constructeurs...
        public frmPrincipale()
        {
            InitializeComponent();
            ListeTravauxDisciplinaires = new List<TravailDisciplinaire>();
            UpdateVueBouton();
            tbcPrincipale.SelectTab(1);
        }
        public void UpdateVueBouton()
        {
            if (lsbListeTravaux.SelectedIndex != -1)
            {
                this.btnSupprimer.Enabled = true;
                this.btnEditer.Enabled = true;
            }
            else
            {
                this.btnSupprimer.Enabled = false;
                this.btnEditer.Enabled = false;
            }
        }

        //Méthodes...
        /// <summary>
        /// Raffraichit la liste si la valeur en paramètre est true et determine si les boutons doivent être grisé
        /// </summary>
        /// <param name="RaffraichirListe">Determine si la liste se raffraichit</param>
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
        public void UpdateVueTexteUtilisateur()
        {
            string TexteDejaCopie = "";
            for (int i = 0; i < this.ListeTravauxDisciplinaires[this.IndexTravailSelectionne].Progression; i++)
            {
                TexteDejaCopie += this.ListeTravauxDisciplinaires[this.IndexTravailSelectionne].Texte[i];
            }
            this.tbxCopieTexte.Text = TexteDejaCopie;
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
                this.rbxTexteExemple.AppendText(this.ListeTravauxDisciplinaires[IndexTravailSelectionne].Texte);
                this.rbxTexteExemple.SelectionStart = 0;
                this.rbxTexteExemple.SelectionLength = this.ListeTravauxDisciplinaires[IndexTravailSelectionne].Progression;
                this.rbxTexteExemple.SelectionBackColor = Color.LightGray;

                //Affichage du reste
                this.lblClasse.Text = ListeTravauxDisciplinaires[IndexTravailSelectionne].Eleve.Classe;
                this.lblProfesseur.Text = ListeTravauxDisciplinaires[IndexTravailSelectionne].Professeur.ToString();
                this.lblEleve.Text = ListeTravauxDisciplinaires[IndexTravailSelectionne].Eleve.ToString();
                this.lblTravailAccompli.Text = Convert.ToString(ListeTravauxDisciplinaires[IndexTravailSelectionne].Progression) + " caractère(s) sur " + Convert.ToString(ListeTravauxDisciplinaires[IndexTravailSelectionne].CompterCaractere());


                //Choisi le nombre de minutes à affiché

                // ___________________________________________ /!\ A REFAIRE

                //switch (ListeTravauxDisciplinaires[IndexTravailSelectionne].Niveau)
                //{
                //    case 1:
                //        this.lblNiveau.Text = Convert.ToString(ListeTravauxDisciplinaires[IndexTravailSelectionne].Niveau) + " (environ " + "20" + " minutes)";
                //        break;
                //    case 2:
                //        this.lblNiveau.Text = Convert.ToString(ListeTravauxDisciplinaires[IndexTravailSelectionne].Niveau) + " (environ " + "40" + " minutes)";
                //        break;
                //    case 3:
                //        this.lblNiveau.Text = Convert.ToString(ListeTravauxDisciplinaires[IndexTravailSelectionne].Niveau) + " (environ " + "60" + " minutes)";
                //        break;
                //    case 4:
                //        this.lblNiveau.Text = Convert.ToString(ListeTravauxDisciplinaires[IndexTravailSelectionne].Niveau) + " (environ " + "120" + " minutes)";
                //        break;
                //    case 5:
                //        this.lblNiveau.Text = Convert.ToString(ListeTravauxDisciplinaires[IndexTravailSelectionne].Niveau) + " (environ " + "150" + " minutes)";
                //        break;
                //    case 6:
                //        this.lblNiveau.Text = "Texte personnalisé";
                //        break;
                //}

                //Update de tout le reste


            }
        }
        //Affiche le formulaire de création et nous renvoie le résultat de celui-ci
        private void tsiNouveau_Click(object sender, EventArgs e)
        {
            frmCreation Creation = new frmCreation();
            //Si l'utilisateur a cliqué sur "OK", Récupère le travail créer dans le formulaire de création et l'ajoute dans la liste
            if (Creation.ShowDialog() == DialogResult.OK)
            {
                if (Creation.VerifierChamps() == true)
                {
                    bool Verification = Creation.VerifierChamps();
                    ListeTravauxDisciplinaires.Add(Creation.CreerTravail());
                    UpdateVueList();
                    tbcPrincipale.SelectTab(1);
                }
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
                UpdateVueSelection(); //false car on ne veut pas qu'il réaffiche le texte car il vient directement de l'utilisateur
            }

            //Reverifie si le travail est fini
            if (this.ListeTravauxDisciplinaires[IndexTravailSelectionne].EstFini())
            {
                MessageBox.Show("Vous avez terminé !");
            }
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
    }
}
