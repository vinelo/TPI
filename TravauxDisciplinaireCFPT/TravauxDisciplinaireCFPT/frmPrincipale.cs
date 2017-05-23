/*
 * Auteur : Vincent Naef 
 * Application : Travaux Disciplinaires au CFPT
 * Nom de la forme : frmPrincipale
 * Description de la forme : Ceci est la forme principale de l'application. C'est ici que l'utilisateur pourra continuer son travail disciplinaire ou encore gérer une liste de travaux.
 * Date de dernière modification : 23 mai 2017
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        private int _FausseTape;

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
            get
            {
                return _tlpInfoTexteUtilisateur;
            }
            set
            {
                _tlpInfoTexteUtilisateur = value;
            }
        }
        public ToolTip TlpInfoProgression
        {
            get
            {
                return _tlpInfoProgression;
            }
            set
            {
                _tlpInfoProgression = value;
            }
        }
        public ToolTip TlpInfoTravail
        {
            get
            {
                return _tlpInfoTravail;
            }
            set
            {
                _tlpInfoTravail = value;
            }
        }
        public ToolTip TlpInfoListe
        {
            get
            {
                return _tlpInfoListe;
            }
            set
            {
                _tlpInfoListe = value;
            }
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

        public int FausseTape
        {
            get
            {
                return _FausseTape;
            }

            set
            {
                _FausseTape = value;
            }
        }


        //Constructeurs...


        public frmPrincipale()
        {
            InitializeComponent();
            ListeTravauxDisciplinaires = new List<TravailDisciplinaire>();
            EstTravailSelectionne = false;
            FausseTape = 0;
        }


        //Méthodes...

        /// <summary>
        /// Affiche le travail sélectionné
        /// </summary>
        public void SelectionnerTravail()
        {
            FausseTape = 0;
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
            TlpBoutonAjouter.Active = !TlpBoutonAjouter.Active;
            TlpBoutonJournaliser.Active = !TlpBoutonJournaliser.Active;
            TlpBoutonNouveau.Active = !TlpBoutonNouveau.Active;
            TlpBoutonReprendre.Active = !TlpBoutonReprendre.Active;
            TlpBoutonSupprimer.Active = !TlpBoutonSupprimer.Active;

        }
        /// <summary>
        /// Éfface les données affiché dans l'onglet travail
        /// </summary>
        public void UpdateVueAucunTravail()
        {
            rbxTexteExemple.Text = "Veuillez sélectionner un travail afin de pouvoir commencer.";
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
            this.btnReprendre.Enabled = EstIndexSelectionne();
            this.btnEnregistrer.Enabled = EstIndexSelectionne();
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
                UpdateVueBouton();
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



                e.Graphics.DrawString("Progression :",
                   e.Font, Stylo, e.Bounds.X + 377, e.Bounds.Y + 35);
                //Barre de progression
                Rectangle BarreProgressionGris = new Rectangle(e.Bounds.X + 480, e.Bounds.Y + 36, 304, 16);
                e.Graphics.FillRectangle(Gris, BarreProgressionGris);
                Rectangle BarreProgressionVert = new Rectangle(e.Bounds.X + 482, e.Bounds.Y + 39, this.ListeTravauxDisciplinaires[e.Index].CalculerPoucentageEffectue() * 3, 10);
                e.Graphics.FillRectangle(Vert, BarreProgressionVert);

                //Affichage du compte du nombre de caractères tapés sur le nombre de caractères totaux
                e.Graphics.DrawString(CompteCaractere,
                Police, Bleu, e.Bounds.X + 550, e.Bounds.Y + 55);
                //Affiche la bonne image en fontion de
                if (ListeTravauxDisciplinaires[e.Index].EstFini())
                    e.Graphics.DrawImage(Properties.Resources.Travail_fini, e.Bounds.Width - 82, e.Bounds.Y + 11, 80, 80);
                else
                    e.Graphics.DrawImage(Properties.Resources.TravailEnCours, e.Bounds.Width - 82, e.Bounds.Y + 11, 80, 80);


                e.DrawFocusRectangle();
                //Contour
                e.Graphics.DrawRectangle(new Pen(Color.Black), e.Bounds);

            }
        }

        /// <summary>
        /// Cet événement est appelé lorsque l'utilisateur clique sur le bouton "Reprendre". Il affiche le travail séléctionné dans la page de travail
        /// </summary>
        private void btnReprendre_Click(object sender, EventArgs e)
        {
            this.SelectionnerTravail();
        }

        /// <summary>
        /// Cet événement est appelé lorsque l'utilisateur tape un caractère dans la zone de saisie "Votre saisie". Il se charge d'avancer la progression si celle-ci doit être avancé
        /// </summary>
        private void tbxCopieTexte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (EstTravailSelectionne)
            {
                //Ne laisse pas l'utilisateur effacer du texte
                if (e.KeyChar == (char)8)
                {
                    //Réaffiche le texte correspondant à la progression du travail.
                    UpdateVueTexteUtilisateur();
                    UpdateVueProgression();
                }

                //Avance la progression de 1 pour autant que le caractère tapé soit le bon
                if (ListeTravauxDisciplinaires[IndexTravailSelectionne].Progression + 1 > ListeTravauxDisciplinaires[IndexTravailSelectionne].CompterCaracteres() || this.ListeTravauxDisciplinaires[this.IndexTravailSelectionne].VerifierCaractere(e.KeyChar) == false)
                {
                    e.Handled = true;
                    FausseTape += 1;
                    if (FausseTape > 3)
                    {
                        FausseTape = 0;
                        MessageBox.Show("Si vous n'arrivez pas à trouver le caractère, restez appuyé sur \"Alt\" et composer le numéro " + ListeTravauxDisciplinaires[IndexTravailSelectionne].AsciiDuCaractereATaperToString() + " avec le pavé numérique.", "Caractère à taper", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    FausseTape = 0;
                    this.ListeTravauxDisciplinaires[IndexTravailSelectionne].AvancerProgression();
                    UpdateVueProgression();
                    SecondesInactif = 0;
                    if (NbCaractereTapeDepuisDernierScroll < 100)
                        NbCaractereTapeDepuisDernierScroll += 1;
                    NbCaractereTapeDepuisDernierScroll = 0;
                }

                //Verifie si le travail est fini
                if (this.ListeTravauxDisciplinaires[IndexTravailSelectionne].EstFini())
                {
                    MessageBox.Show("Ce travail disciplinaire est terminé.", "Travail fini", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tmrTempsEffectif.Enabled = false;
                }


                //Activation du timer
                tmrTempsEffectif.Enabled = true;
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Cet événement est appelé lorsque l'utilisateur clique sur le bouton supprimer
        /// </summary>
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

        /// <summary>
        /// Cet événement est appelé lorsque l'index sélectionné de la liste change. Il raffraîchit les boutons de la liste.
        /// </summary>
        private void lsbListeTravaux_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateVueBouton();
        }

        /// <summary>
        /// Cet événement est appelé chaque seconde que l'utilisateur passe à taper son texte. Ajoute une seconde au temps du travail pour chaque secondes que celui-ci passe à recopier son texte.
        /// </summary>
        private void tmrTempsEffectif_Tick(object sender, EventArgs e)
        {
            if (EstTravailSelectionne)
            {
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

        /// <summary>
        /// Cet événement est appelé lorsque l'utilisateur clique sur un des deux boutons enregistrer. Il enregistre le travail séléctionné dans sa denière location.
        /// </summary>
        private void Enregistrer_Click(object sender, EventArgs e)
        {
            
            int TravailASauvegarder = -1; //index du travail à enregistrer
            //Obtient le
            if (tbcPrincipale.SelectedIndex == 0)
            {
                if (EstIndexSelectionne())
                    TravailASauvegarder = IndexTravailSelectionne;
            }
            else
            {
                if (lsbListeTravaux.SelectedIndex != -1)
                    TravailASauvegarder = lsbListeTravaux.SelectedIndex;
            }
            if (TravailASauvegarder != -1)
            {
                if (this.ListeTravauxDisciplinaires[TravailASauvegarder].DernierEmplacement != "" && File.Exists(this.ListeTravauxDisciplinaires[IndexTravailSelectionne].DernierEmplacement))
                    this.ListeTravauxDisciplinaires[IndexTravailSelectionne].SerialiserTravail(this.ListeTravauxDisciplinaires[IndexTravailSelectionne].DernierEmplacement);
                else if (sfdSauvegarderTravail.ShowDialog() == DialogResult.OK)
                    this.ListeTravauxDisciplinaires[IndexTravailSelectionne].SerialiserTravail(sfdSauvegarderTravail.FileName);

            }
            else
                MessageBox.Show("Veuillez choisir un travail à enregistrer.", "Enregistrer un travail", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Cet événement est appelé lorsque l'utilisateur clique sur le bouton ouvrir ou ajouter. Ajoute à la liste de travaux les travaux séléctionnés dans la boîte de dialogue prévu à cet effet.
        /// </summary>
        private void Ouvrir_Click(object sender, EventArgs e)
        {
            if (ofdOuvrirFichier.ShowDialog() == DialogResult.OK)
            {
                //Pour chaque travail sélectionné, un teste est effectué afin de voir si le travail est compatible et il n'a pas été modifié sans l'aide du programme Travail Disciplinaire au CFPT
                foreach (string fichier in ofdOuvrirFichier.FileNames)
                {
                    try
                    {
                        TravailDisciplinaire td = new TravailDisciplinaire();
                        td = td.DeserialiserTravail(fichier);
                        if (td.VerifierDonneeTravail())
                        {
                            ListeTravauxDisciplinaires.Add(td);
                            MessageBox.Show("Le travail : \"" + fichier + "\" à bien été ajouté.", "État du travail", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Le fichier : \"" + fichier + "\"  est incompatible ou corrompu", "État du travail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Le fichier : \"" + fichier + "\" est incompatible ou corrompu", "État du travail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                UpdateVueList();
                UpdateVueBouton();

            }
        }

        /// <summary>
        /// Cet événement est appelé lorsque l'utilisateur tape du texte. Il s'occupe de l'affichage du texte à recopier ainsi que du texte copié par l'utilisateur.
        /// </summary>
        private void tbxCopieTexte_TextChanged(object sender, EventArgs e)
        {
            //Scroll afin d'afficher le texte à recopier
            this.NbCaractereTapeDepuisDernierScroll += 1;
            if (NbCaractereTapeDepuisDernierScroll == 100)
            {
                rbxCopieTexte.SelectionStart = rbxCopieTexte.Text.Length;
                rbxCopieTexte.ScrollToCaret();
                rbxTexteExemple.SelectionStart = rbxCopieTexte.Text.Length - 100;
                rbxTexteExemple.ScrollToCaret();
                NbCaractereTapeDepuisDernierScroll = 0;
            }

        }

        /// <summary>
        /// Cet événement est appelé lorsque l'utilisateur clique sur le bouton "Journalisation". Il enregistre un fichier log sous format texte sur le chemin spécifié dans la boîte de dialogue prévu à cet effet.
        /// </summary>
        private void btnSauvegarderLog_Click(object sender, EventArgs e)
        {
            if (sfdSauvegarderLog.ShowDialog() == DialogResult.OK)
            {
                this.JournalisationListeTravaux(sfdSauvegarderLog.FileName);
            }
        }

        /// <summary>
        /// Cet événement est appelé lorsque l'utilisateur clique sur la zone de saisie dans "Votre texte". Il réaffiche le texte afin que l'utilisateur puisse reprendre sa progression.
        /// </summary>
        private void rbxCopieTexte_MouseClick(object sender, MouseEventArgs e)
        {
            if (EstTravailSelectionne)
            {
                UpdateVueTexteUtilisateur();
            }
        }
        /// <summary>
        /// Cet événement est appelé lorsque l'utilisateur tape un caractère dans la zone de saisie "Votre saisie". Il empêche que l'utilisateur puisse utiliser les touches directionnel.
        /// </summary>
        private void rbxCopieTexte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                e.Handled = true;
            }
        }


        /// <summary>
        /// Cet événement est appelé lorsque l'utilisateur drag and drop un ou plusieurs fichiers fans la liste. Il ajoute à la liste de travaux les travaux glissé dans la liste.
        /// </summary>
        private void lsbListeTravaux_DragDrop(object sender, DragEventArgs e)
        {
            //Ajoute un à un les fichier si ceux-ci sont compatible
            string[] fichiers = (string[])e.Data.GetData(DataFormats.FileDrop);
            //Pour chaque travail sélectionné, un teste est effectué afin de voir si le travail est compatible et il n'a pas été modifié sans l'aide du programme Travail Disciplinaire au CFPT
            foreach (string fichier in ofdOuvrirFichier.FileNames)
            {
                try
                {
                    TravailDisciplinaire td = new TravailDisciplinaire();
                    td = td.DeserialiserTravail(fichier);
                    if (td.VerifierDonneeTravail())
                    {
                        ListeTravauxDisciplinaires.Add(td);
                        MessageBox.Show("Le travail : \"" + fichier + "\" à bien été ajouté.", "État du travail", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Le fichier : \"" + fichier + "\"  est incompatible ou corrompu", "État du travail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Le fichier : \"" + fichier + "\" est incompatible ou corrompu", "État du travail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            UpdateVueList();
            UpdateVueBouton();
        }

        /// <summary>
        /// Cet événement est appelé lorsque l'utilisateur entre dans la liste avec un fichier. Le curseur de la souris affiche une icone de copie
        /// </summary>
        private void lsbListeTravaux_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        /// <summary>
        /// Cet événement est appelé lorsque la form de charge. Si l'application à été ouverte depuis un fichier personnalisé, celle-ci le fichier depuis lequel il a été ouvert. Il créer aussi les infosbulles qui serviront à guider l'utilisateur.
        /// </summary>
        private void frmPrincipale_Load(object sender, EventArgs e)
        {
            tbcPrincipale.SelectTab(1);
            try
            {
                if (Environment.GetCommandLineArgs().Length == 2)
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
                        MessageBox.Show("Le fichier : \"" + Environment.GetCommandLineArgs()[1] + "\" est incompatible ou corrompu", "État du travail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Le fichier : \"" + Environment.GetCommandLineArgs()[1] + "\" est incompatible ou corrompu", "État du travail", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            TlpBoutonJournaliser.SetToolTip(btnSauvegarderLog, "Ce bouton vous permet de mettre sous forme de fichier texte les données importantes de la liste de travaux disciplinaires.");
            TlpBoutonJournaliser.ToolTipIcon = ToolTipIcon.Info;
            TlpBoutonJournaliser.ToolTipTitle = "Journalisation de la liste";
            TlpBoutonJournaliser.Active = true;

            TlpBoutonNouveau = new ToolTip();
            TlpBoutonNouveau.IsBalloon = true;
            TlpBoutonNouveau.ReshowDelay = 1;
            TlpBoutonNouveau.SetToolTip(btnNouveau, "Ce bouton vous permet de créer un nouveau travail.");
            TlpBoutonNouveau.ToolTipIcon = ToolTipIcon.Info;
            TlpBoutonNouveau.ToolTipTitle = "Nouveau travail disciplinaire";
            TlpBoutonNouveau.Active = true;

            TlpBoutonReprendre = new ToolTip();
            TlpBoutonReprendre.IsBalloon = true;
            TlpBoutonReprendre.ReshowDelay = 1;
            TlpBoutonReprendre.SetToolTip(btnReprendre, "Ce bouton permet d'afficher le travail disciplinaire sélectionné dans l'onglet \"travail\" afin que vous puissiez continuer celui-ci.");
            TlpBoutonReprendre.ToolTipIcon = ToolTipIcon.Info;
            TlpBoutonReprendre.ToolTipTitle = "Reprendre le travail disciplinaire";
            TlpBoutonReprendre.Active = true;

            TlpBoutonSupprimer = new ToolTip();
            TlpBoutonSupprimer.IsBalloon = true;
            TlpBoutonSupprimer.ReshowDelay = 1;
            TlpBoutonSupprimer.SetToolTip(btnSupprimer, "Ce bouton vous permet de supprimer le travail sélectionné dans la liste.");
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
            TlpInfoTravail.SetToolTip(gbxDetails, "C'est ici que s'affichera les informations dit \"statiques\"sur le travail disciplinaire.\r\nOn peut y voir les informations sur l'élève, le professeur et le texte ");
            TlpInfoTravail.ToolTipIcon = ToolTipIcon.Info;
            TlpInfoTravail.ToolTipTitle = "Informations concernant le travail disciplinaire";
            TlpInfoTravail.Active = true;

            TlpInfoProgression = new ToolTip();
            TlpInfoProgression.IsBalloon = true;
            TlpInfoProgression.SetToolTip(gbxProgression, "C'est ici que s'affichera le \"suivi\" de la progression de votre travail disciplinaire. \r\nOn peut y voir la durée effective ou l'avancé du travail disciplinaire.");
            TlpInfoProgression.ToolTipIcon = ToolTipIcon.Info;
            TlpInfoProgression.ToolTipTitle = "Informations concernant la progression du travail disciplinaire";
            TlpInfoProgression.Active = true;

            TlpInfoListe = new ToolTip();
            TlpInfoListe.IsBalloon = true;
            TlpInfoListe.SetToolTip(lsbListeTravaux, "Ceci est la liste de travaux disciplinaires. C'est ici que s'affichent les travaux disciplinaires actuellement gérés par l'application.");
            TlpInfoListe.ToolTipIcon = ToolTipIcon.Info;
            TlpInfoListe.ToolTipTitle = "Liste des travaux disciplinaires ajoutés ou créés";
            TlpInfoListe.Active = true;
        }

        /// <summary>
        /// Cette événement est appelé lorsque l'utilisateur clique sur le bouton d'activation / de désactivation d'infosbulles. 
        /// </summary>
        private void tsiInfosBulles_Click(object sender, EventArgs e)
        {
            UpdateVueInfosBulles();
            if (TlpInfoTravail.Active == true)
                tsiInfosbulles.Text = "Désactiver les infosbulles";
            else
                tsiInfosbulles.Text = "Activer les infosbulles";
        }

        /// <summary>
        /// Cette événement est appelé lorsque l'utilisateur clique sur le bouton "à propos de". Il affiche une fenêtre à propos.
        /// </summary>
        private void tsiAPropos_Click(object sender, EventArgs e)
        {
            frmAPropos APropos = new frmAPropos();
            APropos.ShowDialog();
        }

        /// <summary>
        /// Cette événement est appelé lorsque l'utilisateur double clique sur la liste de travaux. Il séléctionne le travail.
        /// </summary>
        private void lsbListeTravaux_DoubleClick(object sender, EventArgs e)
        {
            if (lsbListeTravaux.SelectedIndex != -1)
                SelectionnerTravail();
        }

        /// <summary>
        /// Cet événement est appelé lorsque l'utilisateur clique sur un des deux boutons enregistrer. Il enregistre le travail séléctionné dans le répertoire sélectionné dans la boîte de dialogue prévue à cette effet.
        /// </summary>
        private void tsiEnregistrerSous_Click(object sender, EventArgs e)
        {
            if (tbcPrincipale.SelectedIndex == 0)
            {
                if (EstIndexSelectionne())
                {
                    if (sfdSauvegarderTravail.ShowDialog() == DialogResult.OK)
                        this.ListeTravauxDisciplinaires[IndexTravailSelectionne].SerialiserTravail(sfdSauvegarderTravail.FileName);
                }
                else
                    MessageBox.Show("Veuillez choisir un travail à enregistrer.", "Enregistrer un travail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (lsbListeTravaux.SelectedIndex != -1)
                {
                    if (sfdSauvegarderTravail.ShowDialog() == DialogResult.OK)
                        this.ListeTravauxDisciplinaires[IndexTravailSelectionne].SerialiserTravail(sfdSauvegarderTravail.FileName);
                }
                else
                    MessageBox.Show("Veuillez choisir un travail à enregistrer.", "Enregistrer un travail", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        /// <summary>
        /// Cet événement est appelé lorsque l'utilisateur clique sur le bouton "Aide". Il affiche le manuel utilisateur.
        /// </summary>
        private void tsiAide_Click(object sender, EventArgs e)
        {
            string locationToSavePdf = Path.Combine(Path.GetTempPath(), "manuel.pdf");
            File.WriteAllBytes(locationToSavePdf, Properties.Resources.ManuelUtilisateur);
            Process.Start(locationToSavePdf);
        }

        /// <summary>
        /// Cet événement est appelé lorsque l'application se ferme. Il enregistre les travaux si l'utilisateur veut qu'il en soit ainsi.
        /// </summary>
        private void frmPrincipale_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ListeTravauxDisciplinaires.Count != 0)
            {
                DialogResult DR = MessageBox.Show("Voulez-vous enregistrer les travaux disciplinaires de la liste avant de fermer l'application ?", "Enregistrer les travaux", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (DialogResult.Yes == DR)
                {
                    foreach (TravailDisciplinaire td in ListeTravauxDisciplinaires)
                    {
                        if (td.DernierEmplacement != "" && File.Exists(td.DernierEmplacement))
                            td.SerialiserTravail(td.DernierEmplacement);
                        else if (sfdSauvegarderTravail.ShowDialog() == DialogResult.OK)
                            td.SerialiserTravail(sfdSauvegarderTravail.FileName);
                    }
                }
                else if (DialogResult.Cancel == DR)
                    e.Cancel = true;
            }
        }
    }
}