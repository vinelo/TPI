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
        private bool _estTravailSelectionne;



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
        public bool EstTravailSelectionne
        {
            get { return _estTravailSelectionne; }
            set
            {
                if(value==false)
                {
                    this.UpdateVueAucunTravail();
                }
                _estTravailSelectionne = value;
            }
        }


        //Constructeurs...


        public frmPrincipale()
        {
            InitializeComponent();
            ListeTravauxDisciplinaires = new List<TravailDisciplinaire>();
            UpdateVueBouton();
            tbcPrincipale.SelectTab(1);
            EstTravailSelectionne = false;
        }


        //Méthodes...

        #region UpdateVue
        public void UpdateVueAucunTravail()
        {
            rbxTexteExemple.Text = "";
            rbxCopieTexte.Text = "";
            lblClasse.Text = "";
            lblEleve.Text = "";
            lblNiveau.Text = "";
            lblProfesseur.Text = "";
            lblTemps.Text = "";
            lblTravailAccompli.Text = "";
        }
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

            if (this.EstTravailSelectionne)
            {
                //Surlignage du texte tapé
                this.rbxTexteExemple.SelectionStart = 0;
                this.rbxTexteExemple.SelectionLength = rbxTexteExemple.TextLength;
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
                this.lblTravailAccompli.Text = ListeTravauxDisciplinaires[IndexTravailSelectionne].ProgressionToString();

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
            rbxCopieTexte.Text = this.ListeTravauxDisciplinaires[IndexTravailSelectionne].GetTexteTapeParUtilisateur();


            //Scroll
            rbxCopieTexte.SelectionStart = this.ListeTravauxDisciplinaires[this.IndexTravailSelectionne].Progression;
            // scroll it automatically
            rbxCopieTexte.ScrollToCaret();
            rbxTexteExemple.SelectionStart = this.ListeTravauxDisciplinaires[this.IndexTravailSelectionne].Progression;
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


        public void SerialiserListeTravaux(string paramChemin)
        {
            FileStream stream = File.Create(paramChemin);
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, this.ListeTravauxDisciplinaires);
            stream.Close();
        }

        /// <summary>
        /// Créer un fichier log
        /// </summary>
        /// <param name="paramChemin"></param>
        public void JournalisationListeTravaux(string paramChemin)
        {
            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(paramChemin))
            {
                foreach (TravailDisciplinaire travail in ListeTravauxDisciplinaires)
                {
                    outputFile.WriteLine("Professeur : " + travail.Professeur.ToString() + " | Élève : " + travail.Eleve.ToString() + " | Date de début : " + travail.DateDeDebut + " | Temps effectif du travail : " + travail.MinutesEtSecondesToString() + " | Progression : " + travail.ProgressionToString() + " | Niveau du travail : " + travail.NiveauToString() + " | Fini : " + travail.EstFini());
                }
            }
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
                   e.Font, Stylo, e.Bounds.X + 310, e.Bounds.Y + 30);
                Rectangle BarreProgressionGris = new Rectangle(e.Bounds.X + 418, e.Bounds.Y + 30, 304, 16);
                e.Graphics.FillRectangle(Gris, BarreProgressionGris);

                Rectangle BarreProgressionVert = new Rectangle(e.Bounds.X + 420, e.Bounds.Y + 34, this.ListeTravauxDisciplinaires[e.Index].CalculerPoucentageEffectue() * 3, 10);
                e.Graphics.FillRectangle(Vert, BarreProgressionVert);
                //Temps passé sur le travail
                //e.Graphics.DrawString("Élève :",
                //   e.Font, stylo, e.Bounds.X, e.Bounds.Y + 30);
                //e.Graphics.DrawString(ListeTravauxDisciplinaires[e.Index].Eleve.ToString(),
                //   e.Font, stylo, e.Bounds.X + 90, e.Bounds.Y + 30);

                e.DrawFocusRectangle();
                //Contour
                e.Graphics.DrawRectangle(new Pen(Color.Black), e.Bounds);

            }
        }

        private void btnEditer_Click(object sender, EventArgs e)
        {
            this.EstTravailSelectionne = true;
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
            if (EstTravailSelectionne)
            {
                //Si c'est effacer
                if (e.KeyChar == (char)8)
                {
                    UpdateVueTexteUtilisateur();
                    UpdateVueSelection();
                }

                //Si l'index est hors du tableau alors ne fait rien
                if (ListeTravauxDisciplinaires[IndexTravailSelectionne].Progression + 1 > ListeTravauxDisciplinaires[IndexTravailSelectionne].CompterCaracteres() || this.ListeTravauxDisciplinaires[this.IndexTravailSelectionne].VerifierCaractere(e.KeyChar) == false)
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
            else
            {
                e.Handled = true;
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            //Vérifie si un travail est sélectionné
            if (lsbListeTravaux.SelectedIndex != -1)
            {
                if (lsbListeTravaux.SelectedIndex == this.IndexTravailSelectionne)
                    EstTravailSelectionne = false;
                ListeTravauxDisciplinaires.RemoveAt(lsbListeTravaux.SelectedIndex);
                this.UpdateVueBouton();
                this.UpdateVueList();

            }
        }

        private void lsbListeTravaux_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateVueBouton();
        }

        private void tmrTempsEffectif_Tick(object sender, EventArgs e)
        {
            if (EstTravailSelectionne)
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
            else
            {
                tmrTempsEffectif.Enabled = false;
            }
        }

        private void tsiEnregistrer_Click(object sender, EventArgs e)
        {
            //Ouvre l'onglet d'enregistrement et enregistre le travail à l'emplacement demandé par l'utilisateur
            if (sfdSauvegarderTravail.ShowDialog() == DialogResult.OK)
            {
                this.ListeTravauxDisciplinaires[IndexTravailSelectionne].SerialiserTravail(sfdSauvegarderTravail.FileName);
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
                    td = td.DeserialiserTravail(ofdOuvrirFichier.FileName);
                    if (td.VerifierDonneeTravail())
                    {
                        ListeTravauxDisciplinaires.Add(td);
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
                rbxCopieTexte.SelectionStart = rbxCopieTexte.Text.Length;
                // scroll it automatically
                rbxCopieTexte.ScrollToCaret();
                rbxTexteExemple.SelectionStart = rbxCopieTexte.Text.Length - 100;
                rbxTexteExemple.ScrollToCaret();
                NbCaractereTapeDepuisDernierScroll = 0;
            }

        }

        private void rbxTexteExemple_Leave(object sender, EventArgs e)
        {
            //UpdateVueTexteUtilisateur();
            UpdateVueSelection();

        }

        private void tsiExporter_Click(object sender, EventArgs e)
        {
            if (sfdSauvegarderListe.ShowDialog() == DialogResult.OK)
            {
                this.SerialiserListeTravaux(sfdSauvegarderListe.FileName);
            }
        }

        private void tsiImporter_Click(object sender, EventArgs e)
        {

        }

        private void btnSauvegarderLog_Click(object sender, EventArgs e)
        {
            if (sfdSauvegarderLog.ShowDialog() == DialogResult.OK)
            {
                this.JournalisationListeTravaux(sfdSauvegarderLog.FileName);
            }
        }

        private void rbxCopieTexte_MouseClick(object sender, MouseEventArgs e)
        {
            if (EstTravailSelectionne)
            {

                rbxCopieTexte.SelectionStart = this.ListeTravauxDisciplinaires[this.IndexTravailSelectionne].Progression;
                // scroll it automatically
                rbxCopieTexte.ScrollToCaret();
            }
        }

        private void rbxCopieTexte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                e.Handled = true;
            }
        }

    }
}
