﻿namespace TravauxDisciplinaireCFPT
{
    partial class frmPrincipale
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mspMenu = new System.Windows.Forms.MenuStrip();
            this.tsmFichier = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiNouveau = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsiOuvrir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsiEnregistrer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiEnregistrerSous = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiAide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsiAPropos = new System.Windows.Forms.ToolStripMenuItem();
            this.tbcPrincipale = new System.Windows.Forms.TabControl();
            this.tbpTravail = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbxCopieTexte = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbxTexteExemple = new System.Windows.Forms.RichTextBox();
            this.gbxDetails = new System.Windows.Forms.GroupBox();
            this.lblNiveau = new System.Windows.Forms.Label();
            this.lblClasse = new System.Windows.Forms.Label();
            this.lblProfesseur = new System.Windows.Forms.Label();
            this.lblEleve = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbxProgression = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTravailAccompli = new System.Windows.Forms.Label();
            this.lblTemps = new System.Windows.Forms.Label();
            this.pgbBarreProgression = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbpGestion = new System.Windows.Forms.TabPage();
            this.btnOuvrir = new System.Windows.Forms.Button();
            this.btnNouveau = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnEditer = new System.Windows.Forms.Button();
            this.lsbListeTravaux = new System.Windows.Forms.ListBox();
            this.tmrTempsEffectif = new System.Windows.Forms.Timer(this.components);
            this.sfdSauvegarder = new System.Windows.Forms.SaveFileDialog();
            this.ofdOuvrirFichier = new System.Windows.Forms.OpenFileDialog();
            this.mspMenu.SuspendLayout();
            this.tbcPrincipale.SuspendLayout();
            this.tbpTravail.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbxDetails.SuspendLayout();
            this.gbxProgression.SuspendLayout();
            this.tbpGestion.SuspendLayout();
            this.SuspendLayout();
            // 
            // mspMenu
            // 
            this.mspMenu.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.mspMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFichier,
            this.toolStripMenuItem1});
            this.mspMenu.Location = new System.Drawing.Point(0, 0);
            this.mspMenu.Name = "mspMenu";
            this.mspMenu.Size = new System.Drawing.Size(924, 28);
            this.mspMenu.TabIndex = 0;
            this.mspMenu.Text = "mspMenu";
            // 
            // tsmFichier
            // 
            this.tsmFichier.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiNouveau,
            this.toolStripSeparator3,
            this.tsiOuvrir,
            this.toolStripSeparator1,
            this.tsiEnregistrer,
            this.tsiEnregistrerSous});
            this.tsmFichier.Name = "tsmFichier";
            this.tsmFichier.Size = new System.Drawing.Size(64, 24);
            this.tsmFichier.Text = "Fichier";
            // 
            // tsiNouveau
            // 
            this.tsiNouveau.Name = "tsiNouveau";
            this.tsiNouveau.Size = new System.Drawing.Size(191, 24);
            this.tsiNouveau.Text = "Nouveau";
            this.tsiNouveau.Click += new System.EventHandler(this.tsiNouveau_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(188, 6);
            // 
            // tsiOuvrir
            // 
            this.tsiOuvrir.Name = "tsiOuvrir";
            this.tsiOuvrir.Size = new System.Drawing.Size(191, 24);
            this.tsiOuvrir.Text = "Ouvrir";
            this.tsiOuvrir.Click += new System.EventHandler(this.tsiOuvrir_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // tsiEnregistrer
            // 
            this.tsiEnregistrer.Name = "tsiEnregistrer";
            this.tsiEnregistrer.Size = new System.Drawing.Size(191, 24);
            this.tsiEnregistrer.Text = "Enregistrer";
            this.tsiEnregistrer.Click += new System.EventHandler(this.tsiEnregistrer_Click);
            // 
            // tsiEnregistrerSous
            // 
            this.tsiEnregistrerSous.Name = "tsiEnregistrerSous";
            this.tsiEnregistrerSous.Size = new System.Drawing.Size(191, 24);
            this.tsiEnregistrerSous.Text = "Enregistrer sous...";
            this.tsiEnregistrerSous.Click += new System.EventHandler(this.tsiEnregistrerSous_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiAide,
            this.toolStripSeparator2,
            this.tsiAPropos});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(28, 24);
            this.toolStripMenuItem1.Text = "?";
            // 
            // tsiAide
            // 
            this.tsiAide.Name = "tsiAide";
            this.tsiAide.Size = new System.Drawing.Size(204, 24);
            this.tsiAide.Text = "Aide";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(201, 6);
            // 
            // tsiAPropos
            // 
            this.tsiAPropos.Name = "tsiAPropos";
            this.tsiAPropos.Size = new System.Drawing.Size(204, 24);
            this.tsiAPropos.Text = "À propos de nous...";
            // 
            // tbcPrincipale
            // 
            this.tbcPrincipale.Controls.Add(this.tbpTravail);
            this.tbcPrincipale.Controls.Add(this.tbpGestion);
            this.tbcPrincipale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tbcPrincipale.Location = new System.Drawing.Point(0, 42);
            this.tbcPrincipale.Name = "tbcPrincipale";
            this.tbcPrincipale.SelectedIndex = 0;
            this.tbcPrincipale.Size = new System.Drawing.Size(924, 491);
            this.tbcPrincipale.TabIndex = 1;
            this.tbcPrincipale.TabStop = false;
            // 
            // tbpTravail
            // 
            this.tbpTravail.Controls.Add(this.groupBox2);
            this.tbpTravail.Controls.Add(this.groupBox1);
            this.tbpTravail.Controls.Add(this.gbxDetails);
            this.tbpTravail.Controls.Add(this.gbxProgression);
            this.tbpTravail.Location = new System.Drawing.Point(4, 27);
            this.tbpTravail.Name = "tbpTravail";
            this.tbpTravail.Padding = new System.Windows.Forms.Padding(3);
            this.tbpTravail.Size = new System.Drawing.Size(916, 460);
            this.tbpTravail.TabIndex = 0;
            this.tbpTravail.Text = "Travail";
            this.tbpTravail.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbxCopieTexte);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(9, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(898, 147);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Votre saisie  :";
            // 
            // tbxCopieTexte
            // 
            this.tbxCopieTexte.Font = new System.Drawing.Font("Consolas", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCopieTexte.Location = new System.Drawing.Point(7, 24);
            this.tbxCopieTexte.Multiline = true;
            this.tbxCopieTexte.Name = "tbxCopieTexte";
            this.tbxCopieTexte.Size = new System.Drawing.Size(885, 117);
            this.tbxCopieTexte.TabIndex = 0;
            this.tbxCopieTexte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCopieTexte_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbxTexteExemple);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(898, 147);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Texte à recopier :";
            // 
            // rbxTexteExemple
            // 
            this.rbxTexteExemple.Font = new System.Drawing.Font("Consolas", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbxTexteExemple.Location = new System.Drawing.Point(7, 24);
            this.rbxTexteExemple.Name = "rbxTexteExemple";
            this.rbxTexteExemple.ReadOnly = true;
            this.rbxTexteExemple.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rbxTexteExemple.Size = new System.Drawing.Size(885, 117);
            this.rbxTexteExemple.TabIndex = 0;
            this.rbxTexteExemple.TabStop = false;
            this.rbxTexteExemple.Text = "";
            // 
            // gbxDetails
            // 
            this.gbxDetails.Controls.Add(this.lblNiveau);
            this.gbxDetails.Controls.Add(this.lblClasse);
            this.gbxDetails.Controls.Add(this.lblProfesseur);
            this.gbxDetails.Controls.Add(this.lblEleve);
            this.gbxDetails.Controls.Add(this.label9);
            this.gbxDetails.Controls.Add(this.label8);
            this.gbxDetails.Controls.Add(this.label5);
            this.gbxDetails.Controls.Add(this.label3);
            this.gbxDetails.Controls.Add(this.label4);
            this.gbxDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDetails.Location = new System.Drawing.Point(520, 313);
            this.gbxDetails.Name = "gbxDetails";
            this.gbxDetails.Size = new System.Drawing.Size(387, 139);
            this.gbxDetails.TabIndex = 5;
            this.gbxDetails.TabStop = false;
            this.gbxDetails.Text = "Détails du travail";
            // 
            // lblNiveau
            // 
            this.lblNiveau.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNiveau.ForeColor = System.Drawing.Color.Blue;
            this.lblNiveau.Location = new System.Drawing.Point(156, 97);
            this.lblNiveau.Name = "lblNiveau";
            this.lblNiveau.Size = new System.Drawing.Size(225, 20);
            this.lblNiveau.TabIndex = 9;
            this.lblNiveau.Text = "Niveau 1 ( environ 20 minutes)";
            // 
            // lblClasse
            // 
            this.lblClasse.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClasse.ForeColor = System.Drawing.Color.Blue;
            this.lblClasse.Location = new System.Drawing.Point(156, 77);
            this.lblClasse.Name = "lblClasse";
            this.lblClasse.Size = new System.Drawing.Size(228, 20);
            this.lblClasse.TabIndex = 8;
            this.lblClasse.Text = "I.IN-P4B";
            // 
            // lblProfesseur
            // 
            this.lblProfesseur.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfesseur.ForeColor = System.Drawing.Color.Blue;
            this.lblProfesseur.Location = new System.Drawing.Point(156, 56);
            this.lblProfesseur.Name = "lblProfesseur";
            this.lblProfesseur.Size = new System.Drawing.Size(222, 20);
            this.lblProfesseur.TabIndex = 7;
            this.lblProfesseur.Text = "Alec Beney";
            // 
            // lblEleve
            // 
            this.lblEleve.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEleve.ForeColor = System.Drawing.Color.Blue;
            this.lblEleve.Location = new System.Drawing.Point(156, 34);
            this.lblEleve.Name = "lblEleve";
            this.lblEleve.Size = new System.Drawing.Size(225, 20);
            this.lblEleve.TabIndex = 6;
            this.lblEleve.Text = "Maxence Menier";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(25, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 20);
            this.label9.TabIndex = 5;
            this.label9.Text = "Niveau du travail : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(82, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "Classe : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(58, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Professeur : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 18);
            this.label3.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(88, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Élève : ";
            // 
            // gbxProgression
            // 
            this.gbxProgression.Controls.Add(this.label1);
            this.gbxProgression.Controls.Add(this.lblTravailAccompli);
            this.gbxProgression.Controls.Add(this.lblTemps);
            this.gbxProgression.Controls.Add(this.pgbBarreProgression);
            this.gbxProgression.Controls.Add(this.label7);
            this.gbxProgression.Controls.Add(this.label6);
            this.gbxProgression.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.gbxProgression.ForeColor = System.Drawing.Color.Black;
            this.gbxProgression.Location = new System.Drawing.Point(16, 313);
            this.gbxProgression.Name = "gbxProgression";
            this.gbxProgression.Size = new System.Drawing.Size(498, 139);
            this.gbxProgression.TabIndex = 4;
            this.gbxProgression.TabStop = false;
            this.gbxProgression.Text = "Progression du travail ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(97, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Progression : ";
            // 
            // lblTravailAccompli
            // 
            this.lblTravailAccompli.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTravailAccompli.ForeColor = System.Drawing.Color.Blue;
            this.lblTravailAccompli.Location = new System.Drawing.Point(199, 72);
            this.lblTravailAccompli.Name = "lblTravailAccompli";
            this.lblTravailAccompli.Size = new System.Drawing.Size(272, 20);
            this.lblTravailAccompli.TabIndex = 4;
            this.lblTravailAccompli.Text = "20000 caractères sur 20000";
            // 
            // lblTemps
            // 
            this.lblTemps.AutoSize = true;
            this.lblTemps.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemps.ForeColor = System.Drawing.Color.Blue;
            this.lblTemps.Location = new System.Drawing.Point(199, 36);
            this.lblTemps.Name = "lblTemps";
            this.lblTemps.Size = new System.Drawing.Size(63, 20);
            this.lblTemps.TabIndex = 3;
            this.lblTemps.Text = "0 minute";
            // 
            // pgbBarreProgression
            // 
            this.pgbBarreProgression.Location = new System.Drawing.Point(203, 110);
            this.pgbBarreProgression.Name = "pgbBarreProgression";
            this.pgbBarreProgression.Size = new System.Drawing.Size(268, 23);
            this.pgbBarreProgression.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(71, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Travail accompli : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(18, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Durée effective du travail : ";
            // 
            // tbpGestion
            // 
            this.tbpGestion.Controls.Add(this.btnOuvrir);
            this.tbpGestion.Controls.Add(this.btnNouveau);
            this.tbpGestion.Controls.Add(this.btnSupprimer);
            this.tbpGestion.Controls.Add(this.btnEditer);
            this.tbpGestion.Controls.Add(this.lsbListeTravaux);
            this.tbpGestion.Location = new System.Drawing.Point(4, 27);
            this.tbpGestion.Name = "tbpGestion";
            this.tbpGestion.Padding = new System.Windows.Forms.Padding(3);
            this.tbpGestion.Size = new System.Drawing.Size(916, 460);
            this.tbpGestion.TabIndex = 1;
            this.tbpGestion.Text = "Gestion de travaux";
            this.tbpGestion.UseVisualStyleBackColor = true;
            // 
            // btnOuvrir
            // 
            this.btnOuvrir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOuvrir.Location = new System.Drawing.Point(277, 395);
            this.btnOuvrir.Name = "btnOuvrir";
            this.btnOuvrir.Size = new System.Drawing.Size(178, 55);
            this.btnOuvrir.TabIndex = 4;
            this.btnOuvrir.Text = "Ouvrir";
            this.btnOuvrir.UseVisualStyleBackColor = true;
            // 
            // btnNouveau
            // 
            this.btnNouveau.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNouveau.Location = new System.Drawing.Point(93, 395);
            this.btnNouveau.Name = "btnNouveau";
            this.btnNouveau.Size = new System.Drawing.Size(178, 55);
            this.btnNouveau.TabIndex = 3;
            this.btnNouveau.Text = "Nouveau";
            this.btnNouveau.UseVisualStyleBackColor = true;
            this.btnNouveau.Click += new System.EventHandler(this.tsiNouveau_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.Location = new System.Drawing.Point(461, 395);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(178, 55);
            this.btnSupprimer.TabIndex = 2;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnEditer
            // 
            this.btnEditer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditer.Location = new System.Drawing.Point(645, 395);
            this.btnEditer.Name = "btnEditer";
            this.btnEditer.Size = new System.Drawing.Size(178, 55);
            this.btnEditer.TabIndex = 1;
            this.btnEditer.Text = "Continuer";
            this.btnEditer.UseVisualStyleBackColor = true;
            this.btnEditer.Click += new System.EventHandler(this.btnEditer_Click);
            // 
            // lsbListeTravaux
            // 
            this.lsbListeTravaux.AllowDrop = true;
            this.lsbListeTravaux.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lsbListeTravaux.FormattingEnabled = true;
            this.lsbListeTravaux.ItemHeight = 55;
            this.lsbListeTravaux.Location = new System.Drawing.Point(8, 6);
            this.lsbListeTravaux.Name = "lsbListeTravaux";
            this.lsbListeTravaux.Size = new System.Drawing.Size(900, 334);
            this.lsbListeTravaux.TabIndex = 0;
            this.lsbListeTravaux.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lsbListeTravaux_DrawItem);
            this.lsbListeTravaux.SelectedIndexChanged += new System.EventHandler(this.lsbListeTravaux_SelectedIndexChanged);
            // 
            // tmrTempsEffectif
            // 
            this.tmrTempsEffectif.Interval = 1000;
            this.tmrTempsEffectif.Tick += new System.EventHandler(this.tmrTempsEffectif_Tick);
            // 
            // sfdSauvegarder
            // 
            this.sfdSauvegarder.DefaultExt = "td";
            this.sfdSauvegarder.FileName = "travail.td";
            this.sfdSauvegarder.Filter = "Fichier Travaux Disciplinaire au CFPT|*.td";
            // 
            // ofdOuvrirFichier
            // 
            this.ofdOuvrirFichier.FileName = "travail.td";
            this.ofdOuvrirFichier.Filter = "Travaux Disciplinaire au CFPT|*.td";
            // 
            // frmPrincipale
            // 
            this.AcceptButton = this.btnEditer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 533);
            this.Controls.Add(this.tbcPrincipale);
            this.Controls.Add(this.mspMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.mspMenu;
            this.MaximizeBox = false;
            this.Name = "frmPrincipale";
            this.Text = "Travaux disciplinaires au CFPT";
            this.mspMenu.ResumeLayout(false);
            this.mspMenu.PerformLayout();
            this.tbcPrincipale.ResumeLayout(false);
            this.tbpTravail.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.gbxDetails.ResumeLayout(false);
            this.gbxDetails.PerformLayout();
            this.gbxProgression.ResumeLayout(false);
            this.gbxProgression.PerformLayout();
            this.tbpGestion.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mspMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmFichier;
        private System.Windows.Forms.ToolStripMenuItem tsiOuvrir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsiEnregistrer;
        private System.Windows.Forms.ToolStripMenuItem tsiEnregistrerSous;
        private System.Windows.Forms.TabControl tbcPrincipale;
        private System.Windows.Forms.TabPage tbpTravail;
        private System.Windows.Forms.TabPage tbpGestion;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsiAide;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsiAPropos;
        private System.Windows.Forms.GroupBox gbxDetails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbxProgression;
        private System.Windows.Forms.ProgressBar pgbBarreProgression;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblNiveau;
        private System.Windows.Forms.Label lblClasse;
        private System.Windows.Forms.Label lblProfesseur;
        private System.Windows.Forms.Label lblEleve;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTravailAccompli;
        private System.Windows.Forms.Label lblTemps;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnEditer;
        private System.Windows.Forms.ListBox lsbListeTravaux;
        private System.Windows.Forms.ToolStripMenuItem tsiNouveau;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rbxTexteExemple;
        private System.Windows.Forms.Button btnNouveau;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.TextBox tbxCopieTexte;
        private System.Windows.Forms.Timer tmrTempsEffectif;
        private System.Windows.Forms.Button btnOuvrir;
        private System.Windows.Forms.SaveFileDialog sfdSauvegarder;
        private System.Windows.Forms.OpenFileDialog ofdOuvrirFichier;
    }
}

