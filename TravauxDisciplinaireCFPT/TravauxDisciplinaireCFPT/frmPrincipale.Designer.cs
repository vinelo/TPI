namespace TravauxDisciplinaireCFPT
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
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsiExporter = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiImporter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiAide = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiDesactiverInfosBulles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsiAPropos = new System.Windows.Forms.ToolStripMenuItem();
            this.tbcPrincipale = new System.Windows.Forms.TabControl();
            this.tbpTravail = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbxCopieTexte = new System.Windows.Forms.RichTextBox();
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
            this.label6 = new System.Windows.Forms.Label();
            this.tbpGestion = new System.Windows.Forms.TabPage();
            this.btnSauvegarderLog = new System.Windows.Forms.Button();
            this.btnOuvrir = new System.Windows.Forms.Button();
            this.btnNouveau = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnEditer = new System.Windows.Forms.Button();
            this.lsbListeTravaux = new System.Windows.Forms.ListBox();
            this.tmrTempsEffectif = new System.Windows.Forms.Timer(this.components);
            this.sfdSauvegarderTravail = new System.Windows.Forms.SaveFileDialog();
            this.ofdOuvrirFichier = new System.Windows.Forms.OpenFileDialog();
            this.sfdSauvegarderListe = new System.Windows.Forms.SaveFileDialog();
            this.sfdSauvegarderLog = new System.Windows.Forms.SaveFileDialog();
            this.ofdOuvrirListe = new System.Windows.Forms.OpenFileDialog();
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
            this.tsiEnregistrerSous,
            this.toolStripSeparator4,
            this.tsiExporter,
            this.tsiImporter});
            this.tsmFichier.Name = "tsmFichier";
            this.tsmFichier.Size = new System.Drawing.Size(64, 24);
            this.tsmFichier.Text = "Fichier";
            // 
            // tsiNouveau
            // 
            this.tsiNouveau.Name = "tsiNouveau";
            this.tsiNouveau.Size = new System.Drawing.Size(195, 24);
            this.tsiNouveau.Text = "Nouveau";
            this.tsiNouveau.Click += new System.EventHandler(this.tsiNouveau_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(192, 6);
            // 
            // tsiOuvrir
            // 
            this.tsiOuvrir.Name = "tsiOuvrir";
            this.tsiOuvrir.Size = new System.Drawing.Size(195, 24);
            this.tsiOuvrir.Text = "Ouvrir";
            this.tsiOuvrir.Click += new System.EventHandler(this.Ouvrir_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(192, 6);
            // 
            // tsiEnregistrer
            // 
            this.tsiEnregistrer.Name = "tsiEnregistrer";
            this.tsiEnregistrer.Size = new System.Drawing.Size(195, 24);
            this.tsiEnregistrer.Text = "Enregistrer";
            this.tsiEnregistrer.Click += new System.EventHandler(this.tsiEnregistrer_Click);
            // 
            // tsiEnregistrerSous
            // 
            this.tsiEnregistrerSous.Name = "tsiEnregistrerSous";
            this.tsiEnregistrerSous.Size = new System.Drawing.Size(195, 24);
            this.tsiEnregistrerSous.Text = "Enregistrer sous...";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(192, 6);
            // 
            // tsiExporter
            // 
            this.tsiExporter.Name = "tsiExporter";
            this.tsiExporter.Size = new System.Drawing.Size(195, 24);
            this.tsiExporter.Text = "Exporter la liste";
            this.tsiExporter.Click += new System.EventHandler(this.tsiExporter_Click);
            // 
            // tsiImporter
            // 
            this.tsiImporter.Name = "tsiImporter";
            this.tsiImporter.Size = new System.Drawing.Size(195, 24);
            this.tsiImporter.Text = "Importer une liste";
            this.tsiImporter.Click += new System.EventHandler(this.tsiImporter_Click);
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
            this.tsiAide.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiDesactiverInfosBulles});
            this.tsiAide.Name = "tsiAide";
            this.tsiAide.Size = new System.Drawing.Size(363, 24);
            this.tsiAide.Text = "Aide";
            // 
            // tsiDesactiverInfosBulles
            // 
            this.tsiDesactiverInfosBulles.Name = "tsiDesactiverInfosBulles";
            this.tsiDesactiverInfosBulles.Size = new System.Drawing.Size(244, 24);
            this.tsiDesactiverInfosBulles.Text = "Désactiver les infosbulles";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(360, 6);
            // 
            // tsiAPropos
            // 
            this.tsiAPropos.Name = "tsiAPropos";
            this.tsiAPropos.Size = new System.Drawing.Size(363, 24);
            this.tsiAPropos.Text = "À propos de Travaux Disciplinaires au CFPT";
            // 
            // tbcPrincipale
            // 
            this.tbcPrincipale.Controls.Add(this.tbpTravail);
            this.tbcPrincipale.Controls.Add(this.tbpGestion);
            this.tbcPrincipale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tbcPrincipale.Location = new System.Drawing.Point(0, 42);
            this.tbcPrincipale.Name = "tbcPrincipale";
            this.tbcPrincipale.SelectedIndex = 0;
            this.tbcPrincipale.Size = new System.Drawing.Size(924, 511);
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
            this.tbpTravail.Size = new System.Drawing.Size(916, 480);
            this.tbpTravail.TabIndex = 0;
            this.tbpTravail.Text = "Travail";
            this.tbpTravail.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbxCopieTexte);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(9, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(898, 147);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Votre saisie  :";
            // 
            // rbxCopieTexte
            // 
            this.rbxCopieTexte.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rbxCopieTexte.Font = new System.Drawing.Font("Consolas", 12.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbxCopieTexte.Location = new System.Drawing.Point(7, 24);
            this.rbxCopieTexte.Name = "rbxCopieTexte";
            this.rbxCopieTexte.ShortcutsEnabled = false;
            this.rbxCopieTexte.Size = new System.Drawing.Size(885, 117);
            this.rbxCopieTexte.TabIndex = 0;
            this.rbxCopieTexte.Text = "";
            this.rbxCopieTexte.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbxCopieTexte_MouseClick);
            this.rbxCopieTexte.TextChanged += new System.EventHandler(this.tbxCopieTexte_TextChanged);
            this.rbxCopieTexte.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbxCopieTexte_KeyDown);
            this.rbxCopieTexte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCopieTexte_KeyPress);
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
            this.rbxTexteExemple.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rbxTexteExemple.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rbxTexteExemple.Font = new System.Drawing.Font("Consolas", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbxTexteExemple.Location = new System.Drawing.Point(7, 24);
            this.rbxTexteExemple.Name = "rbxTexteExemple";
            this.rbxTexteExemple.ReadOnly = true;
            this.rbxTexteExemple.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rbxTexteExemple.ShortcutsEnabled = false;
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
            this.gbxDetails.Size = new System.Drawing.Size(387, 161);
            this.gbxDetails.TabIndex = 5;
            this.gbxDetails.TabStop = false;
            this.gbxDetails.Text = "Détails du travail";
            // 
            // lblNiveau
            // 
            this.lblNiveau.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNiveau.ForeColor = System.Drawing.Color.Blue;
            this.lblNiveau.Location = new System.Drawing.Point(150, 119);
            this.lblNiveau.Name = "lblNiveau";
            this.lblNiveau.Size = new System.Drawing.Size(225, 20);
            this.lblNiveau.TabIndex = 9;
            // 
            // lblClasse
            // 
            this.lblClasse.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClasse.ForeColor = System.Drawing.Color.Blue;
            this.lblClasse.Location = new System.Drawing.Point(150, 87);
            this.lblClasse.Name = "lblClasse";
            this.lblClasse.Size = new System.Drawing.Size(228, 20);
            this.lblClasse.TabIndex = 8;
            // 
            // lblProfesseur
            // 
            this.lblProfesseur.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfesseur.ForeColor = System.Drawing.Color.Blue;
            this.lblProfesseur.Location = new System.Drawing.Point(150, 58);
            this.lblProfesseur.Name = "lblProfesseur";
            this.lblProfesseur.Size = new System.Drawing.Size(222, 20);
            this.lblProfesseur.TabIndex = 7;
            // 
            // lblEleve
            // 
            this.lblEleve.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEleve.ForeColor = System.Drawing.Color.Blue;
            this.lblEleve.Location = new System.Drawing.Point(150, 29);
            this.lblEleve.Name = "lblEleve";
            this.lblEleve.Size = new System.Drawing.Size(225, 20);
            this.lblEleve.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 20);
            this.label9.TabIndex = 5;
            this.label9.Text = "Niveau du travail : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(75, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "Classe : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(46, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
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
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(84, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Élève : ";
            // 
            // gbxProgression
            // 
            this.gbxProgression.Controls.Add(this.label1);
            this.gbxProgression.Controls.Add(this.lblTravailAccompli);
            this.gbxProgression.Controls.Add(this.lblTemps);
            this.gbxProgression.Controls.Add(this.pgbBarreProgression);
            this.gbxProgression.Controls.Add(this.label6);
            this.gbxProgression.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.gbxProgression.ForeColor = System.Drawing.Color.Black;
            this.gbxProgression.Location = new System.Drawing.Point(16, 313);
            this.gbxProgression.Name = "gbxProgression";
            this.gbxProgression.Size = new System.Drawing.Size(498, 161);
            this.gbxProgression.TabIndex = 4;
            this.gbxProgression.TabStop = false;
            this.gbxProgression.Text = "Progression du travail ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(97, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Progression : ";
            // 
            // lblTravailAccompli
            // 
            this.lblTravailAccompli.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTravailAccompli.ForeColor = System.Drawing.Color.Blue;
            this.lblTravailAccompli.Location = new System.Drawing.Point(208, 132);
            this.lblTravailAccompli.Name = "lblTravailAccompli";
            this.lblTravailAccompli.Size = new System.Drawing.Size(268, 20);
            this.lblTravailAccompli.TabIndex = 4;
            this.lblTravailAccompli.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTemps
            // 
            this.lblTemps.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemps.ForeColor = System.Drawing.Color.Blue;
            this.lblTemps.Location = new System.Drawing.Point(208, 52);
            this.lblTemps.Name = "lblTemps";
            this.lblTemps.Size = new System.Drawing.Size(268, 18);
            this.lblTemps.TabIndex = 3;
            // 
            // pgbBarreProgression
            // 
            this.pgbBarreProgression.Location = new System.Drawing.Point(208, 110);
            this.pgbBarreProgression.MarqueeAnimationSpeed = 1;
            this.pgbBarreProgression.Maximum = 1000;
            this.pgbBarreProgression.Name = "pgbBarreProgression";
            this.pgbBarreProgression.Size = new System.Drawing.Size(268, 20);
            this.pgbBarreProgression.Step = 1;
            this.pgbBarreProgression.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(6, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(196, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Durée effective du travail : ";
            // 
            // tbpGestion
            // 
            this.tbpGestion.Controls.Add(this.btnSauvegarderLog);
            this.tbpGestion.Controls.Add(this.btnOuvrir);
            this.tbpGestion.Controls.Add(this.btnNouveau);
            this.tbpGestion.Controls.Add(this.btnSupprimer);
            this.tbpGestion.Controls.Add(this.btnEditer);
            this.tbpGestion.Controls.Add(this.lsbListeTravaux);
            this.tbpGestion.Location = new System.Drawing.Point(4, 27);
            this.tbpGestion.Name = "tbpGestion";
            this.tbpGestion.Padding = new System.Windows.Forms.Padding(3);
            this.tbpGestion.Size = new System.Drawing.Size(916, 480);
            this.tbpGestion.TabIndex = 1;
            this.tbpGestion.Text = "Gestion de travaux";
            this.tbpGestion.UseVisualStyleBackColor = true;
            // 
            // btnSauvegarderLog
            // 
            this.btnSauvegarderLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSauvegarderLog.Location = new System.Drawing.Point(744, 419);
            this.btnSauvegarderLog.Name = "btnSauvegarderLog";
            this.btnSauvegarderLog.Size = new System.Drawing.Size(160, 55);
            this.btnSauvegarderLog.TabIndex = 5;
            this.btnSauvegarderLog.Text = "Journalisation";
            this.btnSauvegarderLog.UseVisualStyleBackColor = true;
            this.btnSauvegarderLog.Click += new System.EventHandler(this.btnSauvegarderLog_Click);
            // 
            // btnOuvrir
            // 
            this.btnOuvrir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOuvrir.Location = new System.Drawing.Point(192, 419);
            this.btnOuvrir.Name = "btnOuvrir";
            this.btnOuvrir.Size = new System.Drawing.Size(160, 55);
            this.btnOuvrir.TabIndex = 4;
            this.btnOuvrir.Text = "Ouvrir";
            this.btnOuvrir.UseVisualStyleBackColor = true;
            // 
            // btnNouveau
            // 
            this.btnNouveau.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNouveau.Location = new System.Drawing.Point(8, 419);
            this.btnNouveau.Name = "btnNouveau";
            this.btnNouveau.Size = new System.Drawing.Size(160, 55);
            this.btnNouveau.TabIndex = 3;
            this.btnNouveau.Text = "Nouveau";
            this.btnNouveau.UseVisualStyleBackColor = true;
            this.btnNouveau.Click += new System.EventHandler(this.tsiNouveau_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.Location = new System.Drawing.Point(376, 419);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(160, 55);
            this.btnSupprimer.TabIndex = 2;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnEditer
            // 
            this.btnEditer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditer.Location = new System.Drawing.Point(560, 419);
            this.btnEditer.Name = "btnEditer";
            this.btnEditer.Size = new System.Drawing.Size(160, 55);
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
            this.lsbListeTravaux.ItemHeight = 80;
            this.lsbListeTravaux.Location = new System.Drawing.Point(8, 6);
            this.lsbListeTravaux.Name = "lsbListeTravaux";
            this.lsbListeTravaux.Size = new System.Drawing.Size(900, 404);
            this.lsbListeTravaux.TabIndex = 0;
            this.lsbListeTravaux.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lsbListeTravaux_DrawItem);
            this.lsbListeTravaux.SelectedIndexChanged += new System.EventHandler(this.lsbListeTravaux_SelectedIndexChanged);
            this.lsbListeTravaux.DragDrop += new System.Windows.Forms.DragEventHandler(this.lsbListeTravaux_DragDrop);
            this.lsbListeTravaux.DragEnter += new System.Windows.Forms.DragEventHandler(this.lsbListeTravaux_DragEnter);
            this.lsbListeTravaux.DragOver += new System.Windows.Forms.DragEventHandler(this.lsbListeTravaux_DragOver);
            // 
            // tmrTempsEffectif
            // 
            this.tmrTempsEffectif.Interval = 1000;
            this.tmrTempsEffectif.Tick += new System.EventHandler(this.tmrTempsEffectif_Tick);
            // 
            // sfdSauvegarderTravail
            // 
            this.sfdSauvegarderTravail.DefaultExt = "td";
            this.sfdSauvegarderTravail.FileName = "travail.td";
            this.sfdSauvegarderTravail.Filter = "Travaux Disciplinaire au CFPT|*.td";
            this.sfdSauvegarderTravail.Title = "Enregistrer le travail";
            // 
            // ofdOuvrirFichier
            // 
            this.ofdOuvrirFichier.FileName = "travail.td";
            this.ofdOuvrirFichier.Filter = "Travaux Disciplinaire au CFPT|*.td";
            this.ofdOuvrirFichier.Multiselect = true;
            // 
            // sfdSauvegarderListe
            // 
            this.sfdSauvegarderListe.FileName = "ListeTravaux.ltd";
            this.sfdSauvegarderListe.Filter = "Liste de Travaux Disciplinaire au CFPT|*.ltd";
            this.sfdSauvegarderListe.Title = "Exporter la liste de travaux";
            // 
            // sfdSauvegarderLog
            // 
            this.sfdSauvegarderLog.FileName = "Log";
            this.sfdSauvegarderLog.Filter = "Fichier Texte |*.txt";
            // 
            // ofdOuvrirListe
            // 
            this.ofdOuvrirListe.FileName = "liste.ltd";
            this.ofdOuvrirListe.Filter = "Liste de Travaux Disciplinaire au CFPT|*.ltd";
            // 
            // frmPrincipale
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 565);
            this.Controls.Add(this.tbcPrincipale);
            this.Controls.Add(this.mspMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.mspMenu;
            this.MaximizeBox = false;
            this.Name = "frmPrincipale";
            this.Text = "Travaux disciplinaires au CFPT";
            this.Load += new System.EventHandler(this.frmPrincipale_Load);
            this.mspMenu.ResumeLayout(false);
            this.mspMenu.PerformLayout();
            this.tbcPrincipale.ResumeLayout(false);
            this.tbpTravail.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
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
        private System.Windows.Forms.Timer tmrTempsEffectif;
        private System.Windows.Forms.Button btnOuvrir;
        private System.Windows.Forms.SaveFileDialog sfdSauvegarderTravail;
        private System.Windows.Forms.OpenFileDialog ofdOuvrirFichier;
        private System.Windows.Forms.RichTextBox rbxCopieTexte;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsiExporter;
        private System.Windows.Forms.ToolStripMenuItem tsiImporter;
        private System.Windows.Forms.SaveFileDialog sfdSauvegarderListe;
        private System.Windows.Forms.ToolStripMenuItem tsiEnregistrerSous;
        private System.Windows.Forms.SaveFileDialog sfdSauvegarderLog;
        private System.Windows.Forms.Button btnSauvegarderLog;
        private System.Windows.Forms.OpenFileDialog ofdOuvrirListe;
        private System.Windows.Forms.ToolStripMenuItem tsiDesactiverInfosBulles;
    }
}

