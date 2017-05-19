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

        private ToolTip _tlpInfoTexteExemple;
        private ToolTip _tlpInfoTexteUtilisateur;
        private ToolTip _tlpInfoProgression;
        private ToolTip _tlpInfoTravail;
        private ToolTip _tlpInfoListe;
        

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


        //Constructeurs...


        public frmPrincipale()
        {
            InitializeComponent();
            ListeTravauxDisciplinaires = new List<TravailDisciplinaire>();
            EstTravailSelectionne = false;
        }


        //Méthodes...

        //__________________________UpdateVue__________________________\\
        public void UpdateVueInfosBulles()
        {
            TlpInfoListe.Active = !TlpInfoListe.Active;
            TlpInfoProgression.Active = !TlpInfoProgression.Active;
            TlpInfoTexteExemple.Active = !TlpInfoTexteExemple.Active;
            TlpInfoTexteUtilisateur.Active = !TlpInfoTexteUtilisateur.Active;
            TlpInfoTravail.Active = !TlpInfoTravail.Active;

        }
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
        /// Sauvegarde la liste de travaux sur le chemin spécifier
        /// </summary>
        /// <param name="paramChemin">Chemin ou l'on veut enregistrer la liste</param>
        public void SerialiserListeTravaux(string paramChemin)
        {
            FileStream stream = File.Create(paramChemin);
            var formatter = new BinaryFormatter();
            foreach (TravailDisciplinaire td in ListeTravauxDisciplinaires)
            {
                td.CryptageTravail();
            }
            formatter.Serialize(stream, this.ListeTravauxDisciplinaires);
            stream.Close();
        }

        public void DeserialiserListeTravaux(string paramFichier)
        {
            var formatter = new BinaryFormatter();
            FileStream stream = File.OpenRead(paramFichier);

            try
            {
                List<TravailDisciplinaire> listeTravaux = (List<TravailDisciplinaire>)formatter.Deserialize(stream);
                bool Verification = true;
                foreach (TravailDisciplinaire td in listeTravaux)
                {
                    if (!td.VerifierDonneeTravail())
                    {
                        Verification = false;
                    }
                }
                if (Verification)
                    this.ListeTravauxDisciplinaires = listeTravaux;
                else
                    MessageBox.Show("Ce fichier est incompatible ou corrompu");
            }
            catch (Exception)
            {
                MessageBox.Show("Ce fichier est incompatible ou corrompu");

            }
            finally
            {
                stream.Close();
            }

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

            UpdateVueAfficherTextes();
            UpdateVueBouton();
            UpdateVueTexteUtilisateur();
            UpdateVueTexteExemple();
            UpdateVueProgression();

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
            //Ouvre l'onglet d'enregistrement et enregistre le travail à l'emplacement demandé par l'utilisateur
            if (sfdSauvegarderTravail.ShowDialog() == DialogResult.OK)
            {
                this.ListeTravauxDisciplinaires[IndexTravailSelectionne].SerialiserTravail(sfdSauvegarderTravail.FileName);
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
                            MessageBox.Show("Le travail : \"" + fichier + "\" à bien été ajouté.");
                        }
                        else
                        {
                            MessageBox.Show("Le fichier : \"" + fichier + "\" fichier est incompatible ou corrompu");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Le fichier : \"" + fichier + "\" fichier est incompatible ou corrompu");
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

        private void tsiExporter_Click(object sender, EventArgs e)
        {
            if (sfdSauvegarderListe.ShowDialog() == DialogResult.OK)
            {
                this.SerialiserListeTravaux(sfdSauvegarderListe.FileName);
            }
        }

        private void tsiImporter_Click(object sender, EventArgs e)
        {
            //Importe la liste choisie
            if (ofdOuvrirListe.ShowDialog() == DialogResult.OK)
                this.DeserialiserListeTravaux(ofdOuvrirListe.FileName);
            UpdateVueList();
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
                        MessageBox.Show("Le travail : \"" + fichier + "\" à bien été ajouté.");
                    }
                    else
                    {
                        MessageBox.Show("Le fichier : \"" + fichier + "\" fichier est incompatible ou corrompu");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Le fichier : \"" + fichier + "\" fichier est incompatible ou corrompu");
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
            try
            {
                //si le chemin du fichier est passé en argument
                if (Environment.GetCommandLineArgs().Length == 2)
                {
                    MessageBox.Show("Chargement du fichier: " + Environment.GetCommandLineArgs()[1]);
                    string fileContents;
                    //lecture du contenu du fichier
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(Environment.GetCommandLineArgs()[1]))
                    {
                        fileContents = sr.ReadToEnd();
                    }
                    //on met le contenu du fichier dans la textbox
                    rbxCopieTexte.Text = fileContents;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement: " + ex.Message);
            }
            MessageBox.Show("zer");
            rbxCopieTexte.Text = "Zer";
            //}
            //rbxCopieTexte.Text = Environment.GetCommandLineArgs()[1];


            string contenu;
            TlpInfoTexteExemple = new ToolTip();
            TlpInfoTexteExemple.IsBalloon = true;
            TlpInfoTexteExemple.ReshowDelay = 1;
            TlpInfoTexteExemple.SetToolTip(rbxTexteExemple, "C'est ici que s'affiche le texte à recopier.");
            TlpInfoTexteExemple.ToolTipIcon = ToolTipIcon.Info;
            TlpInfoTexteExemple.ToolTipTitle = "Texte à recopier";
            TlpInfoTexteExemple.Active = true;

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
            TlpInfoTravail.SetToolTip(gbxDetails, "C'est ici que s'affichera les informations dit \"statiques\"sur le travail.\r\nOn peut y voir les informations sur l'élève, le professeur et le texte ");
            TlpInfoTravail.ToolTipIcon = ToolTipIcon.Info;
            TlpInfoTravail.ToolTipTitle = "Informations concernant le travail";
            TlpInfoTravail.Active = true;

            TlpInfoProgression = new ToolTip();
            TlpInfoProgression.IsBalloon = true;
            TlpInfoProgression.ReshowDelay = 1;
            TlpInfoProgression.SetToolTip(gbxProgression, "C'est ici que s'affichera le \"suivi\" de la progression de votre travail. \r\nOn peut y voir la durée effective ou l'avancé du travail.");
            TlpInfoProgression.ToolTipIcon = ToolTipIcon.Info;
            TlpInfoProgression.ToolTipTitle = "Informations concernant la progression du travail";
            TlpInfoProgression.Active = true;

            TlpInfoListe = new ToolTip();
            TlpInfoListe.IsBalloon = true;
            TlpInfoListe.ReshowDelay = 1;
            contenu = "C'est ici que les travaux que vous créez ou que vous ajoutez s'affiche. Sur cette liste vous pouvez :\r\n";
            contenu += " - Créer un nouveau travail en appuyant sur le bouton \"Nouveau\" \r\n";
            contenu += " - Ajouter un travail en appuyant sur le bouton \"Ajouter\" ou en glissant le fichier dans la liste \r\n";
            contenu += " - Enlever un travail de la liste en le sélectionnant avant de cliquer sur le bouton \"Supprimer\" \r\n";
            contenu += " - Reprendre le travail la où il a été laissé la dernière fois en le sélectionnant avant de cliquer sur le bouton \"Reprendre\" \r\n";
            contenu += " - Créer un fichier contenant la journalisation de la liste en cliquant sur le bouton \"Journaliser\" \r\n";
            TlpInfoListe.SetToolTip(lsbListeTravaux, contenu);
            TlpInfoListe.ToolTipIcon = ToolTipIcon.Info;
            TlpInfoListe.ToolTipTitle = "Liste des travaux ajoutés ou créés";
            TlpInfoListe.AutomaticDelay = 1500;
            TlpInfoListe.Active = true;
        }

        private void tsiDesactiverInfosBulles_Click(object sender, EventArgs e)
        {
            UpdateVueInfosBulles();
            if (TlpInfoTravail.Active == true)
                tsiDesactiverInfosBulles.Text = "Désactiver les infosbulles";
            else
                tsiDesactiverInfosBulles.Text = "Activer les infosbulles";
        }

        private void tsiAPropos_Click(object sender, EventArgs e)
        {
            frmAPropos APropos = new frmAPropos();
            APropos.ShowDialog();
        }
    }
}
