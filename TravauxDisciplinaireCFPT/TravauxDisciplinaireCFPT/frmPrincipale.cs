using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        private ToolTip _tlpInfoTexteExemple;
        private ToolTip _tlpInfoTexteUtilisateur;
        private ToolTip _tlpInfoProgression;
        private ToolTip _tlpInfoTravail;
        private ToolTip _tlpInfoListe;
        private ToolTip _tlpBoutonNouveau;
        private ToolTip _tlpBoutonAjouter;
        private ToolTip _tlpBoutonSupprimer;
        private ToolTip _tlpBoutonReprendre;
        private ToolTip _tlpBoutonJournaliser;


        //Propriétés...

        public int IndexTravailSelectionne
        {
            get
            {
                return _indexTravailSelectionne;
            }
            set
            {
                _indexTravailSelectionne = value;
            }
        }

        internal List<TravailDisciplinaire> ListeTravauxDisciplinaires
        {
            get
            {
                return _listeTravauxDisciplinaires;
            }
            set
            {
                _listeTravauxDisciplinaires = value;
            }
        }
        public int SecondesInactif
        {
            get
            {
                return _secondesInactif;
            }
            set
            {
                _secondesInactif = value;
            }
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
                if (value == false)
                    this.UpdateVueAucunTravail();
                _estTravailSelectionne = value;
            }
        }

        private ToolTip TlpInfoTexteExemple
        {
            get
            {
                return _tlpInfoTexteExemple;
            }

            set
            {
                _tlpInfoTexteExemple = value;
            }
        }

        public ToolTip TlpInfoTexteUtilisateur
        {
            get { return _tlpInfoTexteUtilisateur; }
            set { _tlpInfoTexteUtilisateur = value; }
        }
        public ToolTip TlpInfoProgression
        {
            get { return _tlpInfoProgression; }
            set { _tlpInfoProgression = value; }
        }
        public ToolTip TlpInfoTravail
        {
            get { return _tlpInfoTravail; }
            set { _tlpInfoTravail = value; }
        }
        public ToolTip TlpInfoListe
        {
            get { return _tlpInfoListe; }
            set { _tlpInfoListe = value; }
        }

        public ToolTip TlpBoutonNouveau
        {
            get
            {
                return _tlpBoutonNouveau;
            }

            set
            {
                _tlpBoutonNouveau = value;
            }
        }

        public ToolTip TlpBoutonAjouter
        {
            get
            {
                return _tlpBoutonAjouter;
            }

            set
            {
                _tlpBoutonAjouter = value;
            }
        }

        public ToolTip TlpBoutonSupprimer
        {
            get
            {
                return _tlpBoutonSupprimer;
            }

            set
            {
                _tlpBoutonSupprimer = value;
            }
        }

        public ToolTip TlpBoutonReprendre
        {
            get
            {
                return _tlpBoutonReprendre;
            }

            set
            {
                _tlpBoutonReprendre = value;
            }
        }

        public ToolTip TlpBoutonJournaliser
        {
            get
            {
                return _tlpBoutonJournaliser;
            }

            set
            {
                _tlpBoutonJournaliser = value;
            }
        }


        //Constructeurs...


        public frmPrincipale()
        {
            InitializeComponent();
            ListeTravauxDisciplinaires = new List<TravailDisciplinaire>();
            EstTravailSelectionne = false;
        }


        //Méthodes...

        /// <summary>
        /// 
        /// </summary>
        public void SelectionnerTravail()
        {
            this.EstTravailSelectionne = true;
            //Sélectionne le travail choisi par l'utilisateur
            this.IndexTravailSelectionne = lsbListeTravaux.SelectedIndex;
            tbcPrincipale.SelectTab(0);

            UpdateVueAfficherTextes();
            UpdateVueBouton();
            UpdateVueTexteUtilisateur();
            UpdateVueTexteExemple();
            UpdateVueProgression();
        }
        //__________________________UpdateVue__________________________\\
        /// <summary>
        /// Cache ou affiche les infosbulles
        /// </summary>
        public void UpdateVueInfosBulles()
        {
            TlpInfoListe.Active = !TlpInfoListe.Active;
            TlpInfoProgression.Active = !TlpInfoProgression.Active;
            TlpInfoTexteExemple.Active = !TlpInfoTexteExemple.Active;
            TlpInfoTexteUtilisateur.Active = !TlpInfoTexteUtilisateur.Active;
            TlpInfoTravail.Active = !TlpInfoTravail.Active;

        }
        /// <summary>
        /// Éfface les données affiché dans l'onglet travail
        /// </summary>
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

            lsbListeTravaux.Items.Clear();
            foreach (TravailDisciplinaire travail in this.ListeTravauxDisciplinaires)
            {
                lsbListeTravaux.Items.Add(travail);
            }
        }

        /// <summary>
        /// Affiche le travail sélectionné dans l'onglet "travail"
        /// </summary>
        public void UpdateVueProgression()
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
        /// <summary>
        /// Scroll jusqu'au bon endroit la zone de saisie du texte exemple
        /// </summary>
        public void UpdateVueTexteExemple()
        {
            rbxTexteExemple.SelectionStart = this.ListeTravauxDisciplinaires[this.IndexTravailSelectionne].Progression;
            rbxTexteExemple.ScrollToCaret();
        }
        /// <summary>
        /// Scroll jusqu'au bon endroit la zone de saisie du texte à recopier
        /// </summary>
        public void UpdateVueTexteUtilisateur()
        {
            rbxCopieTexte.SelectionStart = this.ListeTravauxDisciplinaires[this.IndexTravailSelectionne].Progression;
            rbxCopieTexte.ScrollToCaret();
        }

        //Affiche les texte dans les zone de saisie
        public void UpdateVueAfficherTextes()
        {
            rbxCopieTexte.Text = this.ListeTravauxDisciplinaires[IndexTravailSelectionne].GetTexteTapeParUtilisateur();
            this.rbxTexteExemple.Text = this.ListeTravauxDisciplinaires[IndexTravailSelectionne].Niveau.TexteARecopier;
        }



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

        /// <summary>
        /// Créer un fichier log
        /// </summary>
        /// <param name="paramChemin"></param>
        public void JournalisationListeTravaux(string paramChemin)
        {
            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter FichierLog = new StreamWriter(paramChemin))
            {
                string TravailToLog = "Liste de travaux disciplinaires  :";
                TravailToLog += "\r\n____________________________________________________________________ \r\n";
                foreach (TravailDisciplinaire travail in ListeTravauxDisciplinaires)
                {

                    TravailToLog += "\r\n  Travail de " + travail.Eleve.ToString();
                    TravailToLog += "\r\n  Infligé par " + travail.Professeur.ToString();
                    TravailToLog += "\r\n  Créé le " + travail.DateDeDebut.ToString("dd / MM / yyyy");
                    TravailToLog += "\r\n  Temps effectif du travail : " + travail.MinutesEtSecondesToString();
                    TravailToLog += "\r\n  Progression : " + travail.ProgressionToString();
                    TravailToLog += "\r\n  Niveau du travail : " + travail.NiveauToString();
                    TravailToLog += "\r\n  Fini : " + travail.EstFini();
                    string TexteCoupe = travail.Niveau.TexteARecopier.Replace(Environment.NewLine, "     ");
                    TexteCoupe = TexteCoupe.Substring(0, 100);
                    TravailToLog += "\r\n  Aperçu du texte : " + TexteCoupe + "...";

                    TravailToLog += "\r\n____________________________________________________________________ \r\n";

                    //FichierLog.WriteLine("Professeur : " + travail.Professeur.ToString() + " | Élève : " + travail.Eleve.ToString() + " | Date de début : " + travail.DateDeDebut + " | Temps effectif du travail : " + travail.MinutesEtSecondesToString() + " | Progression : " + travail.ProgressionToString() + " | Niveau du travail : " + travail.NiveauToString() + " | Fini : " + travail.EstFini());

                }
                FichierLog.Write(TravailToLog);
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
                if (ListeTravauxDisciplinaires != null)
                    UpdateVueList();
                tbcPrincipale.SelectTab(1);
            }
        }

        /// <summary>
        /// Dessine dans la liste de travaux les informations de chaque travail
        /// </summary>
        private void lsbListeTravaux_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            // Determine la couleur des stylos que l'on va utiliser
            Brush Fond = Brushes.White;
            Brush FondSelectionne = Brushes.Beige;
            Brush Stylo = Brushes.Black;
            Brush Vert = Brushes.Green;
            Brush Gris = Brushes.Gray;
            Brush Bleu = Brushes.DarkBlue;
            Font Police = new Font("Arial", 10, FontStyle.Italic);

            //remplis l'arrière plan d'une couleur différente en fonction de si c'est l'item sélectionné
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e.Graphics.FillRectangle(FondSelectionne, e.Bounds);
            else
                e.Graphics.FillRectangle(Fond, e.Bounds);

            //Pour chaque item de la liste dessine l'intérieur
            if (e.Index >= 0)
            {
                string CompteCaractere = ListeTravauxDisciplinaires[e.Index].ProgressionToString();

                //Affichage professeur
                e.Graphics.DrawString("Professeur :",
                   e.Font, Stylo, e.Bounds.X + 19, e.Bounds.Y + 10);
                e.Graphics.DrawString(ListeTravauxDisciplinaires[e.Index].Professeur.ToString(),
                   Police, Bleu, e.Bounds.X + 105, e.Bounds.Y + 11);
                //Affichage élève
                e.Graphics.DrawString("Élève :",
                   e.Font, Stylo, e.Bounds.X + 54, e.Bounds.Y + 40);
                e.Graphics.DrawString(ListeTravauxDisciplinaires[e.Index].Eleve.ToString(),
                   Police, Bleu, e.Bounds.X + 105, e.Bounds.Y + 41);
                //Date de début
                e.Graphics.DrawString("Date de début :",
                   e.Font, Stylo, e.Bounds.X, e.Bounds.Y + 70);
                e.Graphics.DrawString(ListeTravauxDisciplinaires[e.Index].DateDeDebut.ToString("dd/MM/yyyy"),
                   Police, Bleu, e.Bounds.X + 105, e.Bounds.Y + 71);

                //Affichage du temps passé sur le travail
                e.Graphics.DrawString("Temps effectif du travail :",
                   e.Font, Stylo, e.Bounds.X + 300, e.Bounds.Y + 70);
                e.Graphics.DrawString(ListeTravauxDisciplinaires[e.Index].MinutesEtSecondesToString(),
                   Police, Bleu, e.Bounds.X + 480, e.Bounds.Y + 71);
                //Affichage Niveau
                e.Graphics.DrawString("Niveau :",
                   e.Font, Stylo, e.Bounds.X + 410, e.Bounds.Y + 10);
                e.Graphics.DrawString(ListeTravauxDisciplinaires[e.Index].NiveauToString(),
                   Police, Bleu, e.Bounds.X + 480, e.Bounds.Y + 11);

                //Barre de progression

                e.Graphics.DrawString("Progression :",
                   e.Font, Stylo, e.Bounds.X + 377, e.Bounds.Y + 35);
                Rectangle BarreProgressionGris = new Rectangle(e.Bounds.X + 480, e.Bounds.Y + 36, 304, 16);
                e.Graphics.FillRectangle(Gris, BarreProgressionGris);

                Rectangle BarreProgressionVert = new Rectangle(e.Bounds.X + 482, e.Bounds.Y + 39, this.ListeTravauxDisciplinaires[e.Index].CalculerPoucentageEffectue() * 3, 10);
                e.Graphics.FillRectangle(Vert, BarreProgressionVert);
                SizeF LargeurString = new SizeF();
                LargeurString = e.Graphics.MeasureString(CompteCaractere, new Font("Arial", 16), 400);
                e.Graphics.DrawString(CompteCaractere,
                Police, Bleu, e.Bounds.X + 550, e.Bounds.Y + 55);


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
            this.SelectionnerTravail();
        }

        private void tbxCopieTexte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (EstTravailSelectionne)
            {
                //Si c'est effacer
                if (e.KeyChar == (char)8)
                {
                    UpdateVueTexteUtilisateur();
                    UpdateVueProgression();
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
                    UpdateVueProgression();
                    SecondesInactif = 0;
                    if (NbCaractereTapeDepuisDernierScroll < 100)
                        NbCaractereTapeDepuisDernierScroll += 1;
                    NbCaractereTapeDepuisDernierScroll = 0;
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
                //Verifie si le travail supprimer correspond au travail dans l'onglet travail
                if (lsbListeTravaux.SelectedIndex == this.IndexTravailSelectionne)
                    EstTravailSelectionne = false;
                ListeTravauxDisciplinaires.RemoveAt(lsbListeTravaux.SelectedIndex);
            }

            this.UpdateVueList();
            this.UpdateVueBouton();
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
                    UpdateVueProgression();
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
            int TravailASauvegarder = -1;
            if (tbcPrincipale.SelectedIndex == 0)
            {
                if (EstIndexSelectionne())
                    TravailASauvegarder = IndexTravailSelectionne;
                //Ouvre l'onglet d'enregistrement et enregistre le travail à l'emplacement demandé par l'utilisateur
            }
            else
            {
                if (lsbListeTravaux.SelectedIndex != -1)
                    TravailASauvegarder = lsbListeTravaux.SelectedIndex;
            }
            if (TravailASauvegarder != -1)
            {
                if (this.ListeTravauxDisciplinaires[TravailASauvegarder].DernierEmplacement != null && File.Exists(this.ListeTravauxDisciplinaires[IndexTravailSelectionne].DernierEmplacement))
                    this.ListeTravauxDisciplinaires[IndexTravailSelectionne].SerialiserTravail(this.ListeTravauxDisciplinaires[IndexTravailSelectionne].DernierEmplacement);
                else if (sfdSauvegarderTravail.ShowDialog() == DialogResult.OK)
                    this.ListeTravauxDisciplinaires[IndexTravailSelectionne].SerialiserTravail(sfdSauvegarderTravail.FileName);
                else
                    MessageBox.Show("Veuillez choisir un travail à enregistrer.", "Enregistrer un travail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Ouvrir_Click(object sender, EventArgs e)
        {
            //Ajoute à la liste le fichier ouvert si celui-ci n'est pas incompatible ou corrompu
            if (ofdOuvrirFichier.ShowDialog() == DialogResult.OK)
            {
                foreach (string fichier in ofdOuvrirFichier.FileNames)
                {
                    //Si il y a une erreur au niveau de la lecture du fichier alors celui-ci est incompatible ou corrompu
                    try
                    {
                        TravailDisciplinaire td = new TravailDisciplinaire();
                        td = td.DeserialiserTravail(fichier);
                        if (td.VerifierDonneeTravail())
                        {
                            ListeTravauxDisciplinaires.Add(td);
                            UpdateVueList();
                            MessageBox.Show("Le travail : \"" + fichier + "\" à bien été ajouté.", "État du travail", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Le fichier : \"" + fichier + "\" fichier est incompatible ou corrompu", "État du travail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Le fichier : \"" + fichier + "\" fichier est incompatible ou corrompu", "État du travail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

        private void btnSauvegarderLog_Click(object sender, EventArgs e)
        {
            //Créer un fichier Log
            if (sfdSauvegarderLog.ShowDialog() == DialogResult.OK)
            {
                this.JournalisationListeTravaux(sfdSauvegarderLog.FileName);
            }
            MessageBox.Show("Zer");
        }

        private void rbxCopieTexte_MouseClick(object sender, MouseEventArgs e)
        {
            //
            if (EstTravailSelectionne)
            {
                UpdateVueTexteUtilisateur();
            }
        }

        private void rbxCopieTexte_KeyDown(object sender, KeyEventArgs e)
        {
            //Empêche l'utilisateur de se déplacer dans la forme
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                e.Handled = true;
            }
        }

        //Événement Drop
        private void lsbListeTravaux_DragDrop(object sender, DragEventArgs e)
        {
            //Ajoute un à un les fichier si ceux-ci sont compatible
            string[] fichiers = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string fichier in fichiers)
            {
                try
                {
                    TravailDisciplinaire td = new TravailDisciplinaire();
                    td = td.DeserialiserTravail(fichier);
                    if (td.VerifierDonneeTravail())
                    {
                        ListeTravauxDisciplinaires.Add(td);
                        UpdateVueList();
                        MessageBox.Show("Le travail : \"" + fichier + "\" à bien été ajouté.","État du travail",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Le fichier : \"" + fichier + "\" fichier est incompatible ou corrompu", "État du travail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Le fichier : \"" + fichier + "\" fichier est incompatible ou corrompu", "État du travail", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            UpdateVueList();
        }

        private void lsbListeTravaux_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void frmPrincipale_Load(object sender, EventArgs e)
        {
            tbcPrincipale.SelectTab(1);
            //try
            //{
            //    //si le chemin du fichier est passé en argument
            //    if (Environment.GetCommandLineArgs().Length == 2)
            //    {
            //        MessageBox.Show("Chargement du fichier: " + Environment.GetCommandLineArgs()[1]);
            //        string fileContents;
            //        //lecture du contenu du fichier
            //        using (System.IO.StreamReader sr = new System.IO.StreamReader(Environment.GetCommandLineArgs()[1]))
            //        {
            //            fileContents = sr.ReadToEnd();
            //        }
            //        //on met le contenu du fichier dans la textbox
            //        rbxCopieTexte.Text = fileContents;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Erreur lors du chargement: " + ex.Message);
            //}
            //Si il y a une erreur au niveau de la lecture du fichier alors celui-ci est incompatible ou corrompu
            try
            {
                TravailDisciplinaire td = new TravailDisciplinaire();
                td = td.DeserialiserTravail(Environment.GetCommandLineArgs()[1]);
                if (td.VerifierDonneeTravail())
                {
                    ListeTravauxDisciplinaires.Add(td);
                    UpdateVueList();
                    MessageBox.Show("Le travail : \"" + Environment.GetCommandLineArgs()[1] + "\" à bien été ajouté.", "État du travail", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Le fichier : \"" + Environment.GetCommandLineArgs()[1] + "\" fichier est incompatible ou corrompu", "État du travail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Le fichier : \"" + fichier + "\" fichier est incompatible ou corrompu", "État du travail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateVueBouton();

            //Création des infosbulles

            TlpInfoTexteExemple = new ToolTip();
            TlpInfoTexteExemple.IsBalloon = true;
            TlpInfoTexteExemple.ReshowDelay = 1;
            TlpInfoTexteExemple.SetToolTip(rbxTexteExemple, "C'est ici que s'affiche le texte à recopier.");
            TlpInfoTexteExemple.ToolTipIcon = ToolTipIcon.Info;
            TlpInfoTexteExemple.ToolTipTitle = "Texte à recopier";
            TlpInfoTexteExemple.Active = true;

            TlpBoutonAjouter = new ToolTip();
            TlpBoutonAjouter.IsBalloon = true;
            TlpBoutonAjouter.ReshowDelay = 1;
            TlpBoutonAjouter.SetToolTip(btnOuvrir, "Cliquez sur ce bouton pour ajouter un travail disciplinaire déjà créer à la liste.");
            TlpBoutonAjouter.ToolTipIcon = ToolTipIcon.Info;
            TlpBoutonAjouter.ToolTipTitle = "Ajouter un travail disciplinaire";
            TlpBoutonAjouter.Active = true;

            TlpBoutonJournaliser = new ToolTip();
            TlpBoutonJournaliser.IsBalloon = true;
            TlpBoutonJournaliser.ReshowDelay = 1;
            TlpBoutonJournaliser.SetToolTip(btnSauvegarderLog, "Enregistre sous forme de fichier texte les données importante de la liste de travaux disciplinaires.");
            TlpBoutonJournaliser.ToolTipIcon = ToolTipIcon.Info;
            TlpBoutonJournaliser.ToolTipTitle = "Journalisation de la liste";
            TlpBoutonJournaliser.Active = true;

            TlpBoutonNouveau = new ToolTip();
            TlpBoutonNouveau.IsBalloon = true;
            TlpBoutonNouveau.ReshowDelay = 1;
            TlpBoutonNouveau.SetToolTip(btnNouveau, "Enregistre sous forme de fichier texte les informations importante de la liste de travaux disciplinaire.");
            TlpBoutonNouveau.ToolTipIcon = ToolTipIcon.Info;
            TlpBoutonNouveau.ToolTipTitle = "Journalisation de la liste";
            TlpBoutonNouveau.Active = true;

            TlpBoutonReprendre = new ToolTip();
            TlpBoutonReprendre.IsBalloon = true;
            TlpBoutonReprendre.ReshowDelay = 1;
            TlpBoutonReprendre.SetToolTip(btnEditer, "Affiche le travail disciplinaire sélectionné dans l'onglet \"travail\" afin que vous puissiez continuer celui-ci.");
            TlpBoutonReprendre.ToolTipIcon = ToolTipIcon.Info;
            TlpBoutonReprendre.ToolTipTitle = "Reprendre le travail disciplinaire";
            TlpBoutonReprendre.Active = true;

            TlpBoutonSupprimer = new ToolTip();
            TlpBoutonSupprimer.IsBalloon = true;
            TlpBoutonSupprimer.ReshowDelay = 1;
            TlpBoutonSupprimer.SetToolTip(btnSupprimer, "Supprime de la liste le travail disciplinaire sélectionné");
            TlpBoutonSupprimer.ToolTipIcon = ToolTipIcon.Info;
            TlpBoutonSupprimer.ToolTipTitle = "Suppression du travail disciplinaire";
            TlpBoutonSupprimer.Active = true;

            TlpInfoTexteUtilisateur = new ToolTip();
            TlpInfoTexteUtilisateur.IsBalloon = true;
            TlpInfoTexteUtilisateur.ReshowDelay = 1;
            TlpInfoTexteUtilisateur.SetToolTip(rbxCopieTexte, "C'est ici que vous devez recopier le texte.");
            TlpInfoTexteUtilisateur.ToolTipIcon = ToolTipIcon.Info;
            TlpInfoTexteUtilisateur.ToolTipTitle = "Texte tapé par l'utilisateur";
            TlpInfoTexteUtilisateur.Active = true;

            TlpInfoTravail = new ToolTip();
            TlpInfoTravail.IsBalloon = true;
            TlpInfoTravail.ReshowDelay = 1;
            TlpInfoTravail.SetToolTip(gbxDetails, "C'est ici que s'affichera les informations dit \"statiques\"sur le travail disciplinaire.\r\nOn peut y voir les informations sur l'élève, le professeur et le texte ");
            TlpInfoTravail.ToolTipIcon = ToolTipIcon.Info;
            TlpInfoTravail.ToolTipTitle = "Informations concernant le travail disciplinaire";
            TlpInfoTravail.Active = true;

            TlpInfoProgression = new ToolTip();
            TlpInfoProgression.IsBalloon = true;
            TlpInfoProgression.ReshowDelay = 1;
            TlpInfoProgression.SetToolTip(gbxProgression, "C'est ici que s'affichera le \"suivi\" de la progression de votre travail disciplinaire. \r\nOn peut y voir la durée effective ou l'avancé du travail disciplinaire.");
            TlpInfoProgression.ToolTipIcon = ToolTipIcon.Info;
            TlpInfoProgression.ToolTipTitle = "Informations concernant la progression du travail disciplinaire";
            TlpInfoProgression.Active = true;

            TlpInfoListe = new ToolTip();
            TlpInfoListe.IsBalloon = true;
            TlpInfoListe.ReshowDelay = 1;
            TlpInfoListe.SetToolTip(lsbListeTravaux, "Ceci est la liste de travaux disciplinaires. C'est ici que s'affichent les travaux disciplinaires actuellement gérés par l'application.");
            TlpInfoListe.ToolTipIcon = ToolTipIcon.Info;
            TlpInfoListe.ToolTipTitle = "Liste des travaux disciplinaires ajoutés ou créés";
            TlpInfoListe.AutomaticDelay = 1500;
            TlpInfoListe.Active = true;
        }

        private void tsiDesactiverInfosBulles_Click(object sender, EventArgs e)
        {
            UpdateVueInfosBulles();
            if (TlpInfoTravail.Active == true)
                tsiInfosbulles.Text = "Désactiver les infosbulles";
            else
                tsiInfosbulles.Text = "Activer les infosbulles";
        }

        private void tsiAPropos_Click(object sender, EventArgs e)
        {
            frmAPropos APropos = new frmAPropos();
            APropos.ShowDialog();
        }

        private void lsbListeTravaux_DoubleClick(object sender, EventArgs e)
        {
            if (lsbListeTravaux.SelectedIndex != -1)
                SelectionnerTravail();
        }

        private void tsiEnregistrerSous_Click(object sender, EventArgs e)
        {
            if (sfdSauvegarderTravail.ShowDialog() == DialogResult.OK)
            {
                this.ListeTravauxDisciplinaires[IndexTravailSelectionne].SerialiserTravail(sfdSauvegarderTravail.FileName);
            }
        }

        private void tsiAide_Click(object sender, EventArgs e)
        {
            string locationToSavePdf = Path.Combine(Path.GetTempPath(), "manuel.pdf");  // select other location if you want
            File.WriteAllBytes(locationToSavePdf, Properties.Resources.NAEF_PlanningTPIV2);    // write the file from the resources to the location you want
            Process.Start(locationToSavePdf);
        }
    }
}
