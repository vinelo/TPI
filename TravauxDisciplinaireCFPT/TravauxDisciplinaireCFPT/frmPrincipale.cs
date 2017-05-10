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
        //Variables...
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
        }
        //Méthodes...
        /// <summary>
        /// Affiche dans la listebox les éléments de la liste de travaux
        /// </summary>
        public void UpdateVueList()
        {
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
                string TexteCopie = "";
                for (int i = 0; i < this.ListeTravauxDisciplinaires[this.IndexTravailSelectionne].Progression; i++)
                {
                    TexteCopie += this.ListeTravauxDisciplinaires[this.IndexTravailSelectionne].Texte;
                }

                this.rbxCopieTexte.Text = TexteCopie;
                this.rbxTexteExemple.Text = ListeTravauxDisciplinaires[IndexTravailSelectionne].Texte;
                this.lblClasse.Text = ListeTravauxDisciplinaires[IndexTravailSelectionne].Classe;
                this.lblProfesseur.Text = ListeTravauxDisciplinaires[IndexTravailSelectionne].NomProfesseur + " " + ListeTravauxDisciplinaires[IndexTravailSelectionne].PrenomProfesseur;
                this.lblEleve.Text = ListeTravauxDisciplinaires[IndexTravailSelectionne].NomEleve + " " + ListeTravauxDisciplinaires[IndexTravailSelectionne].PrenomEleve;
                this.lblNiveau.Text = Convert.ToString(ListeTravauxDisciplinaires[IndexTravailSelectionne].Niveau) + " (environ " + "AMettre" + " minutes)";
                this.lblTravailAccompli.Text = Convert.ToString(ListeTravauxDisciplinaires[IndexTravailSelectionne].Progression) + " caractère(s) sur " + Convert.ToString(ListeTravauxDisciplinaires[IndexTravailSelectionne].TotalCaractere);
                this.lblTemps.Text = Convert.ToString(ListeTravauxDisciplinaires[IndexTravailSelectionne].Temps);

            }
        }
        private void tbxCopie_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblDuree_Click(object sender, EventArgs e)
        {

        }

        private void tsiNouveau_Click(object sender, EventArgs e)
        {
            frmCreation Creation = new frmCreation();

            if (Creation.ShowDialog() == DialogResult.OK)
            {
                if (Creation.VerifierChamps() == true)
                {
                    bool Verification = Creation.VerifierChamps();
                    ListeTravauxDisciplinaires.Add(Creation.CreerTravail());
                    UpdateVueList();
                }
            }

        }

        private void lsbListeTravaux_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Define the default color of the brush as black.
            Brush fond = Brushes.White;
            Brush fondSelectionne = Brushes.LightGray;
            Brush stylo = Brushes.Black;

            // Determine the color of the brush to draw each item based 
            // on the index of the item to draw.
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e.Graphics.FillRectangle(fondSelectionne, e.Bounds);
            else
                e.Graphics.FillRectangle(fond, e.Bounds);


            // Draw the current item text based on the current Font 
            // and the custom brush settings.
            if (e.Index >= 0)
            {
                //Affichage professeur
                e.Graphics.DrawString("Professeur :",
                   e.Font, stylo, e.Bounds.X, e.Bounds.Y + 10);
                e.Graphics.DrawString(ListeTravauxDisciplinaires[e.Index].NomProfesseur + " " + ListeTravauxDisciplinaires[e.Index].PrenomProfesseur,
                   e.Font, stylo, e.Bounds.X + 90, e.Bounds.Y + 10);
                //Affichage élève
                e.Graphics.DrawString("Élève :",
                   e.Font, stylo, e.Bounds.X, e.Bounds.Y + 30);
                e.Graphics.DrawString(ListeTravauxDisciplinaires[e.Index].NomEleve + " " + ListeTravauxDisciplinaires[e.Index].PrenomEleve,
                   e.Font, stylo, e.Bounds.X + 90, e.Bounds.Y + 30);


                // If the ListBox has focus, draw a focus rectangle around the selected item.
                e.DrawFocusRectangle();
                e.Graphics.DrawRectangle(new Pen(Color.Black), e.Bounds);

            }
        }

        private void btnEditer_Click(object sender, EventArgs e)
        {
            this.IndexTravailSelectionne = lsbListeTravaux.SelectedIndex;
            tbcPrincipale.SelectTab(0);

            UpdateVueList();
            UpdateVueSelection();
        }



    }
}
