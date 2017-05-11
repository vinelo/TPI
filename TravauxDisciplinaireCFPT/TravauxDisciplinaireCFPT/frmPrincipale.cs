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
            UpdateVueList(false);
        }
        //Méthodes...
        /// <summary>
        /// Raffraichit la liste si la valeur en paramètre est true et determine si les boutons doivent être grisé
        /// </summary>
        /// <param name="RaffraichirListe">Determine si la liste se raffraichit</param>
        public void UpdateVueList(bool RaffraichirListe)
        {
            if (RaffraichirListe == true)
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

            //Bouton Editer et Supprimer
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
        /// <summary>
        /// Affiche le travail sélectionné dans l'onglet "travail"
        /// </summary>
        /// <param name="paramUpdateVueText">Indique si on veut update le text ou pas</param>
        public void UpdateVueSelection(bool paramUpdateVueText)
        {

            if (ListeTravauxDisciplinaires != null)
            {
                //Stocke le text déjà copié dans la variable -> "TexteDejaCopie"
                string TexteDejaCopie = "";
                for (int i = 0; i < this.ListeTravauxDisciplinaires[this.IndexTravailSelectionne].Progression; i++)
                {
                    TexteDejaCopie += this.ListeTravauxDisciplinaires[this.IndexTravailSelectionne].Texte[i];
                }

                ////string TexteResteACopier = "";
                ////for (int i = 0; i < this.ListeTravauxDisciplinaires[this.IndexTravailSelectionne].Progression; i++)
                ////{
                ////    TexteDejaCopie += this.ListeTravauxDisciplinaires[this.IndexTravailSelectionne].Texte[i];
                ////}

                //Si le paramètre "UpdateVueText" est true, alors fait le nécessaire pour update le texte
                if (paramUpdateVueText == true)
                {
                    this.tbxCopieTexte.Text = "";
                    this.tbxCopieTexte.Text = TexteDejaCopie;
                }
                for (int i = 0; i < this.ListeTravauxDisciplinaires[this.IndexTravailSelectionne].Progression; i++)
                {
                    TexteDejaCopie += this.ListeTravauxDisciplinaires[this.IndexTravailSelectionne].Texte[i];
                }
                //Update du Texte Exemple
                this.rbxTexteExemple.Text = "";
                this.rbxTexteExemple.AppendText(this.ListeTravauxDisciplinaires[IndexTravailSelectionne].Texte);
                this.rbxTexteExemple.SelectionStart = 0;
                this.rbxTexteExemple.SelectionLength = this.ListeTravauxDisciplinaires[IndexTravailSelectionne].Progression;
                this.rbxTexteExemple.SelectionBackColor = Color.LightGray;
                //this.rbxTexteExemple.Text = ListeTravauxDisciplinaires[IndexTravailSelectionne].Texte;
                //Update de tout le reste
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
                    UpdateVueList(true);
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
                e.Graphics.DrawString(ListeTravauxDisciplinaires[e.Index].NomProfesseur + " " + ListeTravauxDisciplinaires[e.Index].PrenomProfesseur,
                   e.Font, stylo, e.Bounds.X + 90, e.Bounds.Y + 10);
                //Affichage élève
                e.Graphics.DrawString("Élève :",
                   e.Font, stylo, e.Bounds.X, e.Bounds.Y + 30);
                e.Graphics.DrawString(ListeTravauxDisciplinaires[e.Index].NomEleve + " " + ListeTravauxDisciplinaires[e.Index].PrenomEleve,
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

            UpdateVueList(false);
            UpdateVueSelection(true); // "true" car on veut que le text déjà écrit s'affiche
        }

        private void tbxCopieTexte_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Si l'index est hors du tableau alors ne fait rien
            if (IndexTravailSelectionne + 1 > ListeTravauxDisciplinaires.Count)
            {
                e.Handled = true;
            }
            //Si le travail est fini alors affiche une boîte de dialogue disant que l'utilisateur a terminé
            else if (this.ListeTravauxDisciplinaires[IndexTravailSelectionne].VerifierFin())
            {
                MessageBox.Show("Vous avez terminé !");
                e.Handled = true;
            }
            else
            {
                //Si le caractère tapé n'est pas le bon ne fait rien
                if (this.ListeTravauxDisciplinaires[this.IndexTravailSelectionne].VerifierCaractere(e.KeyChar) == false)
                {
                    e.Handled = true;
                }
                //Sinon Avance la progression de 1 et Update la vue du travail sélectionné
                else
                {
                    this.ListeTravauxDisciplinaires[IndexTravailSelectionne].AvancerProgression();
                    UpdateVueSelection(false); //false car on ne veut pas qu'il réaffiche le texte car il vient directement de l'utilisateur
                }
            }
            //Reverifie si le travail est fini
            if (this.ListeTravauxDisciplinaires[IndexTravailSelectionne].VerifierFin())
            {
                MessageBox.Show("Vous avez terminé !");
                e.Handled = true;
            }


        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            //Vérifie si un travail est sélectionné
            if (lsbListeTravaux.SelectedIndex != -1)
            {
                ListeTravauxDisciplinaires.RemoveAt(lsbListeTravaux.SelectedIndex);
                this.UpdateVueList(false); // false car on ne veut pas raffraîchir la liste juste grisé / dégriser les boutons
            }
        }

        private void lsbListeTravaux_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateVueList(false); // false car on ne veut pas raffraîchir la liste juste grisé / dégriser les boutons
        }



    }
}
