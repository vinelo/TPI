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
            this.mspMenu = new System.Windows.Forms.MenuStrip();
            this.tsmFichier = new System.Windows.Forms.ToolStripMenuItem();
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
            this.gbxDetails = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbxProgression = new System.Windows.Forms.GroupBox();
            this.pgbBarreProgression = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxCopie = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxExemple = new System.Windows.Forms.TextBox();
            this.tbpGestion = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTemps = new System.Windows.Forms.Label();
            this.lblTravailAccompli = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblProfesseur = new System.Windows.Forms.Label();
            this.lblClasse = new System.Windows.Forms.Label();
            this.lblNiveau = new System.Windows.Forms.Label();
            this.lsbListeTravaux = new System.Windows.Forms.ListBox();
            this.btnExecuter = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.mspMenu.SuspendLayout();
            this.tbcPrincipale.SuspendLayout();
            this.tbpTravail.SuspendLayout();
            this.gbxDetails.SuspendLayout();
            this.gbxProgression.SuspendLayout();
            this.tbpGestion.SuspendLayout();
            this.SuspendLayout();
            // 
            // mspMenu
            // 
            this.mspMenu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.mspMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFichier,
            this.toolStripMenuItem1});
            this.mspMenu.Location = new System.Drawing.Point(0, 0);
            this.mspMenu.Name = "mspMenu";
            this.mspMenu.Size = new System.Drawing.Size(924, 29);
            this.mspMenu.TabIndex = 0;
            this.mspMenu.Text = "mspMenu";
            // 
            // tsmFichier
            // 
            this.tsmFichier.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiOuvrir,
            this.toolStripSeparator1,
            this.tsiEnregistrer,
            this.tsiEnregistrerSous});
            this.tsmFichier.Name = "tsmFichier";
            this.tsmFichier.Size = new System.Drawing.Size(54, 20);
            this.tsmFichier.Text = "Fichier";
            // 
            // tsiOuvrir
            // 
            this.tsiOuvrir.Name = "tsiOuvrir";
            this.tsiOuvrir.Size = new System.Drawing.Size(166, 22);
            this.tsiOuvrir.Text = "Ouvrir";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(163, 6);
            // 
            // tsiEnregistrer
            // 
            this.tsiEnregistrer.Name = "tsiEnregistrer";
            this.tsiEnregistrer.Size = new System.Drawing.Size(166, 22);
            this.tsiEnregistrer.Text = "Enregistrer";
            // 
            // tsiEnregistrerSous
            // 
            this.tsiEnregistrerSous.Name = "tsiEnregistrerSous";
            this.tsiEnregistrerSous.Size = new System.Drawing.Size(166, 22);
            this.tsiEnregistrerSous.Text = "Enregistrer sous...";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiAide,
            this.toolStripSeparator2,
            this.tsiAPropos});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // tsiAide
            // 
            this.tsiAide.Name = "tsiAide";
            this.tsiAide.Size = new System.Drawing.Size(176, 22);
            this.tsiAide.Text = "Aide";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(173, 6);
            // 
            // tsiAPropos
            // 
            this.tsiAPropos.Name = "tsiAPropos";
            this.tsiAPropos.Size = new System.Drawing.Size(176, 22);
            this.tsiAPropos.Text = "À propos de nous...";
            // 
            // tbcPrincipale
            // 
            this.tbcPrincipale.Controls.Add(this.tbpTravail);
            this.tbcPrincipale.Controls.Add(this.tbpGestion);
            this.tbcPrincipale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbcPrincipale.Location = new System.Drawing.Point(0, 42);
            this.tbcPrincipale.Name = "tbcPrincipale";
            this.tbcPrincipale.SelectedIndex = 0;
            this.tbcPrincipale.Size = new System.Drawing.Size(924, 491);
            this.tbcPrincipale.TabIndex = 1;
            this.tbcPrincipale.TabStop = false;
            // 
            // tbpTravail
            // 
            this.tbpTravail.Controls.Add(this.gbxDetails);
            this.tbpTravail.Controls.Add(this.gbxProgression);
            this.tbpTravail.Controls.Add(this.label2);
            this.tbpTravail.Controls.Add(this.tbxCopie);
            this.tbpTravail.Controls.Add(this.label1);
            this.tbpTravail.Controls.Add(this.tbxExemple);
            this.tbpTravail.Location = new System.Drawing.Point(4, 29);
            this.tbpTravail.Name = "tbpTravail";
            this.tbpTravail.Padding = new System.Windows.Forms.Padding(3);
            this.tbpTravail.Size = new System.Drawing.Size(916, 458);
            this.tbpTravail.TabIndex = 0;
            this.tbpTravail.Text = "Travail";
            this.tbpTravail.UseVisualStyleBackColor = true;
            // 
            // gbxDetails
            // 
            this.gbxDetails.Controls.Add(this.lblNiveau);
            this.gbxDetails.Controls.Add(this.lblClasse);
            this.gbxDetails.Controls.Add(this.lblProfesseur);
            this.gbxDetails.Controls.Add(this.lblNom);
            this.gbxDetails.Controls.Add(this.label9);
            this.gbxDetails.Controls.Add(this.label8);
            this.gbxDetails.Controls.Add(this.label5);
            this.gbxDetails.Controls.Add(this.label3);
            this.gbxDetails.Controls.Add(this.label4);
            this.gbxDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDetails.Location = new System.Drawing.Point(520, 281);
            this.gbxDetails.Name = "gbxDetails";
            this.gbxDetails.Size = new System.Drawing.Size(387, 192);
            this.gbxDetails.TabIndex = 5;
            this.gbxDetails.TabStop = false;
            this.gbxDetails.Text = "Détails du travail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Élève :";
            // 
            // gbxProgression
            // 
            this.gbxProgression.Controls.Add(this.lblTravailAccompli);
            this.gbxProgression.Controls.Add(this.lblTemps);
            this.gbxProgression.Controls.Add(this.pgbBarreProgression);
            this.gbxProgression.Controls.Add(this.label7);
            this.gbxProgression.Controls.Add(this.label6);
            this.gbxProgression.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxProgression.Location = new System.Drawing.Point(9, 281);
            this.gbxProgression.Name = "gbxProgression";
            this.gbxProgression.Size = new System.Drawing.Size(505, 192);
            this.gbxProgression.TabIndex = 4;
            this.gbxProgression.TabStop = false;
            this.gbxProgression.Text = "Progression du travail ";
            // 
            // pgbBarreProgression
            // 
            this.pgbBarreProgression.Location = new System.Drawing.Point(29, 127);
            this.pgbBarreProgression.Name = "pgbBarreProgression";
            this.pgbBarreProgression.Size = new System.Drawing.Size(446, 23);
            this.pgbBarreProgression.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(89, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Travail accompli : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(196, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Durée effective du travail : ";
            this.label6.Click += new System.EventHandler(this.lblDuree_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(20, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Votre texte :";
            // 
            // tbxCopie
            // 
            this.tbxCopie.Location = new System.Drawing.Point(8, 177);
            this.tbxCopie.Multiline = true;
            this.tbxCopie.Name = "tbxCopie";
            this.tbxCopie.Size = new System.Drawing.Size(899, 97);
            this.tbxCopie.TabIndex = 0;
            this.tbxCopie.TextChanged += new System.EventHandler(this.tbxCopie_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Texte à recopier :";
            // 
            // tbxExemple
            // 
            this.tbxExemple.Location = new System.Drawing.Point(6, 50);
            this.tbxExemple.Multiline = true;
            this.tbxExemple.Name = "tbxExemple";
            this.tbxExemple.ReadOnly = true;
            this.tbxExemple.Size = new System.Drawing.Size(899, 97);
            this.tbxExemple.TabIndex = 0;
            this.tbxExemple.TabStop = false;
            // 
            // tbpGestion
            // 
            this.tbpGestion.Controls.Add(this.button1);
            this.tbpGestion.Controls.Add(this.btnExecuter);
            this.tbpGestion.Controls.Add(this.lsbListeTravaux);
            this.tbpGestion.Location = new System.Drawing.Point(4, 29);
            this.tbpGestion.Name = "tbpGestion";
            this.tbpGestion.Padding = new System.Windows.Forms.Padding(3);
            this.tbpGestion.Size = new System.Drawing.Size(916, 458);
            this.tbpGestion.TabIndex = 1;
            this.tbpGestion.Text = "Gestion de travaux";
            this.tbpGestion.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Professeur :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(73, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "Classe :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 20);
            this.label9.TabIndex = 5;
            this.label9.Text = "Niveau du travail :";
            // 
            // lblTemps
            // 
            this.lblTemps.AutoSize = true;
            this.lblTemps.Location = new System.Drawing.Point(227, 36);
            this.lblTemps.Name = "lblTemps";
            this.lblTemps.Size = new System.Drawing.Size(70, 20);
            this.lblTemps.TabIndex = 3;
            this.lblTemps.Text = "0 minute";
            // 
            // lblTravailAccompli
            // 
            this.lblTravailAccompli.Location = new System.Drawing.Point(227, 76);
            this.lblTravailAccompli.Name = "lblTravailAccompli";
            this.lblTravailAccompli.Size = new System.Drawing.Size(272, 20);
            this.lblTravailAccompli.TabIndex = 4;
            this.lblTravailAccompli.Text = "20000 caractères sur 20000";
            // 
            // lblNom
            // 
            this.lblNom.Location = new System.Drawing.Point(144, 36);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(237, 20);
            this.lblNom.TabIndex = 6;
            this.lblNom.Text = "Maxence Menier";
            // 
            // lblProfesseur
            // 
            this.lblProfesseur.Location = new System.Drawing.Point(144, 66);
            this.lblProfesseur.Name = "lblProfesseur";
            this.lblProfesseur.Size = new System.Drawing.Size(237, 20);
            this.lblProfesseur.TabIndex = 7;
            this.lblProfesseur.Text = "Alec Beney";
            // 
            // lblClasse
            // 
            this.lblClasse.Location = new System.Drawing.Point(144, 98);
            this.lblClasse.Name = "lblClasse";
            this.lblClasse.Size = new System.Drawing.Size(237, 20);
            this.lblClasse.TabIndex = 8;
            this.lblClasse.Text = "I.IN-P4B";
            // 
            // lblNiveau
            // 
            this.lblNiveau.Location = new System.Drawing.Point(144, 127);
            this.lblNiveau.Name = "lblNiveau";
            this.lblNiveau.Size = new System.Drawing.Size(237, 20);
            this.lblNiveau.TabIndex = 9;
            this.lblNiveau.Text = "Niveau 1 ( environ 20 minutes)";
            // 
            // lsbListeTravaux
            // 
            this.lsbListeTravaux.FormattingEnabled = true;
            this.lsbListeTravaux.ItemHeight = 20;
            this.lsbListeTravaux.Location = new System.Drawing.Point(8, 6);
            this.lsbListeTravaux.Name = "lsbListeTravaux";
            this.lsbListeTravaux.Size = new System.Drawing.Size(900, 384);
            this.lsbListeTravaux.TabIndex = 0;
            // 
            // btnExecuter
            // 
            this.btnExecuter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnExecuter.Location = new System.Drawing.Point(704, 395);
            this.btnExecuter.Name = "btnExecuter";
            this.btnExecuter.Size = new System.Drawing.Size(178, 55);
            this.btnExecuter.TabIndex = 1;
            this.btnExecuter.Text = "Exécuter";
            this.btnExecuter.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.Location = new System.Drawing.Point(25, 395);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 55);
            this.button1.TabIndex = 2;
            this.button1.Text = "Supprimer";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmPrincipale
            // 
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
            this.tbpTravail.PerformLayout();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxCopie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxExemple;
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
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTravailAccompli;
        private System.Windows.Forms.Label lblTemps;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnExecuter;
        private System.Windows.Forms.ListBox lsbListeTravaux;
    }
}

