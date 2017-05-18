namespace TravauxDisciplinaireCFPT
{
    partial class frmCreation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbxProfesseur = new System.Windows.Forms.GroupBox();
            this.tbxPrenomProf = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxNomProf = new System.Windows.Forms.TextBox();
            this.lblNom = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxClasseEleve = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxPrenomEleve = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxNomEleve = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPersonnaliser = new System.Windows.Forms.Button();
            this.rbnPersonnaliser = new System.Windows.Forms.RadioButton();
            this.rbnNiveau5 = new System.Windows.Forms.RadioButton();
            this.rbnNiveau4 = new System.Windows.Forms.RadioButton();
            this.rbnNiveau3 = new System.Windows.Forms.RadioButton();
            this.rbnNiveau2 = new System.Windows.Forms.RadioButton();
            this.rbnNiveau1 = new System.Windows.Forms.RadioButton();
            this.btnCreer = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.ofdOuvrir = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbxApercu = new System.Windows.Forms.RichTextBox();
            this.gbxProfesseur.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxProfesseur
            // 
            this.gbxProfesseur.Controls.Add(this.tbxPrenomProf);
            this.gbxProfesseur.Controls.Add(this.label1);
            this.gbxProfesseur.Controls.Add(this.tbxNomProf);
            this.gbxProfesseur.Controls.Add(this.lblNom);
            this.gbxProfesseur.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxProfesseur.Location = new System.Drawing.Point(12, 12);
            this.gbxProfesseur.Name = "gbxProfesseur";
            this.gbxProfesseur.Size = new System.Drawing.Size(256, 108);
            this.gbxProfesseur.TabIndex = 0;
            this.gbxProfesseur.TabStop = false;
            this.gbxProfesseur.Text = "Professeur";
            // 
            // tbxPrenomProf
            // 
            this.tbxPrenomProf.Font = new System.Drawing.Font("Consolas", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPrenomProf.Location = new System.Drawing.Point(84, 67);
            this.tbxPrenomProf.Name = "tbxPrenomProf";
            this.tbxPrenomProf.Size = new System.Drawing.Size(166, 27);
            this.tbxPrenomProf.TabIndex = 1;
            this.tbxPrenomProf.TextChanged += new System.EventHandler(this.tbx_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Prénom :";
            // 
            // tbxNomProf
            // 
            this.tbxNomProf.Font = new System.Drawing.Font("Consolas", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNomProf.Location = new System.Drawing.Point(84, 35);
            this.tbxNomProf.Name = "tbxNomProf";
            this.tbxNomProf.Size = new System.Drawing.Size(166, 27);
            this.tbxNomProf.TabIndex = 0;
            this.tbxNomProf.TextChanged += new System.EventHandler(this.tbx_TextChanged);
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNom.Location = new System.Drawing.Point(25, 37);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(50, 20);
            this.lblNom.TabIndex = 0;
            this.lblNom.Text = "Nom :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxClasseEleve);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbxPrenomEleve);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbxNomEleve);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 143);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Élève";
            // 
            // tbxClasseEleve
            // 
            this.tbxClasseEleve.Font = new System.Drawing.Font("Consolas", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxClasseEleve.Location = new System.Drawing.Point(84, 99);
            this.tbxClasseEleve.Name = "tbxClasseEleve";
            this.tbxClasseEleve.Size = new System.Drawing.Size(166, 27);
            this.tbxClasseEleve.TabIndex = 4;
            this.tbxClasseEleve.TextChanged += new System.EventHandler(this.tbx_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Classe :";
            // 
            // tbxPrenomEleve
            // 
            this.tbxPrenomEleve.Font = new System.Drawing.Font("Consolas", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPrenomEleve.Location = new System.Drawing.Point(84, 67);
            this.tbxPrenomEleve.Name = "tbxPrenomEleve";
            this.tbxPrenomEleve.Size = new System.Drawing.Size(166, 27);
            this.tbxPrenomEleve.TabIndex = 3;
            this.tbxPrenomEleve.TextChanged += new System.EventHandler(this.tbx_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Prénom :";
            // 
            // tbxNomEleve
            // 
            this.tbxNomEleve.Font = new System.Drawing.Font("Consolas", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNomEleve.Location = new System.Drawing.Point(84, 35);
            this.tbxNomEleve.Name = "tbxNomEleve";
            this.tbxNomEleve.Size = new System.Drawing.Size(166, 27);
            this.tbxNomEleve.TabIndex = 2;
            this.tbxNomEleve.TextChanged += new System.EventHandler(this.tbx_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nom :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPersonnaliser);
            this.groupBox2.Controls.Add(this.rbnPersonnaliser);
            this.groupBox2.Controls.Add(this.rbnNiveau5);
            this.groupBox2.Controls.Add(this.rbnNiveau4);
            this.groupBox2.Controls.Add(this.rbnNiveau3);
            this.groupBox2.Controls.Add(this.rbnNiveau2);
            this.groupBox2.Controls.Add(this.rbnNiveau1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(274, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 257);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Difficulté du travail";
            // 
            // btnPersonnaliser
            // 
            this.btnPersonnaliser.Enabled = false;
            this.btnPersonnaliser.Location = new System.Drawing.Point(172, 209);
            this.btnPersonnaliser.Name = "btnPersonnaliser";
            this.btnPersonnaliser.Size = new System.Drawing.Size(35, 27);
            this.btnPersonnaliser.TabIndex = 11;
            this.btnPersonnaliser.Text = "...";
            this.btnPersonnaliser.UseVisualStyleBackColor = true;
            this.btnPersonnaliser.Click += new System.EventHandler(this.btnPersonnaliser_Click);
            // 
            // rbnPersonnaliser
            // 
            this.rbnPersonnaliser.AutoSize = true;
            this.rbnPersonnaliser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnPersonnaliser.Location = new System.Drawing.Point(6, 212);
            this.rbnPersonnaliser.Name = "rbnPersonnaliser";
            this.rbnPersonnaliser.Size = new System.Drawing.Size(160, 24);
            this.rbnPersonnaliser.TabIndex = 10;
            this.rbnPersonnaliser.Text = "Texte personnalisé";
            this.rbnPersonnaliser.UseVisualStyleBackColor = true;
            this.rbnPersonnaliser.CheckedChanged += new System.EventHandler(this.rbnNiveau_CheckedChanged);
            // 
            // rbnNiveau5
            // 
            this.rbnNiveau5.AutoSize = true;
            this.rbnNiveau5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnNiveau5.Location = new System.Drawing.Point(6, 144);
            this.rbnNiveau5.Name = "rbnNiveau5";
            this.rbnNiveau5.Size = new System.Drawing.Size(123, 24);
            this.rbnNiveau5.TabIndex = 9;
            this.rbnNiveau5.Text = "5 (~ 150 min.)";
            this.rbnNiveau5.UseVisualStyleBackColor = true;
            this.rbnNiveau5.CheckedChanged += new System.EventHandler(this.rbnNiveau_CheckedChanged);
            // 
            // rbnNiveau4
            // 
            this.rbnNiveau4.AutoSize = true;
            this.rbnNiveau4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnNiveau4.Location = new System.Drawing.Point(6, 114);
            this.rbnNiveau4.Name = "rbnNiveau4";
            this.rbnNiveau4.Size = new System.Drawing.Size(123, 24);
            this.rbnNiveau4.TabIndex = 8;
            this.rbnNiveau4.Text = "4 (~ 120 min.)";
            this.rbnNiveau4.UseVisualStyleBackColor = true;
            this.rbnNiveau4.CheckedChanged += new System.EventHandler(this.rbnNiveau_CheckedChanged);
            // 
            // rbnNiveau3
            // 
            this.rbnNiveau3.AutoSize = true;
            this.rbnNiveau3.Checked = true;
            this.rbnNiveau3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnNiveau3.Location = new System.Drawing.Point(6, 85);
            this.rbnNiveau3.Name = "rbnNiveau3";
            this.rbnNiveau3.Size = new System.Drawing.Size(114, 24);
            this.rbnNiveau3.TabIndex = 7;
            this.rbnNiveau3.TabStop = true;
            this.rbnNiveau3.Text = "3 (~ 60 min.)";
            this.rbnNiveau3.UseVisualStyleBackColor = true;
            this.rbnNiveau3.CheckedChanged += new System.EventHandler(this.rbnNiveau_CheckedChanged);
            // 
            // rbnNiveau2
            // 
            this.rbnNiveau2.AutoSize = true;
            this.rbnNiveau2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnNiveau2.Location = new System.Drawing.Point(6, 55);
            this.rbnNiveau2.Name = "rbnNiveau2";
            this.rbnNiveau2.Size = new System.Drawing.Size(114, 24);
            this.rbnNiveau2.TabIndex = 6;
            this.rbnNiveau2.Text = "2 (~ 40 min.)";
            this.rbnNiveau2.UseVisualStyleBackColor = true;
            this.rbnNiveau2.CheckedChanged += new System.EventHandler(this.rbnNiveau_CheckedChanged);
            // 
            // rbnNiveau1
            // 
            this.rbnNiveau1.AutoSize = true;
            this.rbnNiveau1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnNiveau1.Location = new System.Drawing.Point(6, 25);
            this.rbnNiveau1.Name = "rbnNiveau1";
            this.rbnNiveau1.Size = new System.Drawing.Size(114, 24);
            this.rbnNiveau1.TabIndex = 5;
            this.rbnNiveau1.Text = "1 (~ 20 min.)";
            this.rbnNiveau1.UseVisualStyleBackColor = true;
            this.rbnNiveau1.CheckedChanged += new System.EventHandler(this.rbnNiveau_CheckedChanged);
            // 
            // btnCreer
            // 
            this.btnCreer.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCreer.Enabled = false;
            this.btnCreer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnCreer.Location = new System.Drawing.Point(397, 404);
            this.btnCreer.Name = "btnCreer";
            this.btnCreer.Size = new System.Drawing.Size(104, 52);
            this.btnCreer.TabIndex = 12;
            this.btnCreer.Text = "Créer";
            this.btnCreer.UseVisualStyleBackColor = true;
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnAnnuler.Location = new System.Drawing.Point(12, 404);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(104, 52);
            this.btnAnnuler.TabIndex = 13;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbxApercu);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 275);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(486, 123);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Aperçu du texte";
            // 
            // rbxApercu
            // 
            this.rbxApercu.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.rbxApercu.Location = new System.Drawing.Point(6, 23);
            this.rbxApercu.Name = "rbxApercu";
            this.rbxApercu.Size = new System.Drawing.Size(474, 94);
            this.rbxApercu.TabIndex = 16;
            this.rbxApercu.Text = "";
            // 
            // frmCreation
            // 
            this.AcceptButton = this.btnCreer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 468);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnCreer);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbxProfesseur);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCreation";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Création d\'un travail";
            this.gbxProfesseur.ResumeLayout(false);
            this.gbxProfesseur.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxProfesseur;
        private System.Windows.Forms.TextBox tbxPrenomProf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxNomProf;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxClasseEleve;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxPrenomEleve;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxNomEleve;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPersonnaliser;
        private System.Windows.Forms.RadioButton rbnPersonnaliser;
        private System.Windows.Forms.RadioButton rbnNiveau5;
        private System.Windows.Forms.RadioButton rbnNiveau4;
        private System.Windows.Forms.RadioButton rbnNiveau3;
        private System.Windows.Forms.RadioButton rbnNiveau2;
        private System.Windows.Forms.RadioButton rbnNiveau1;
        private System.Windows.Forms.Button btnCreer;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.OpenFileDialog ofdOuvrir;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox rbxApercu;
    }
}