﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravauxDisciplinaireCFPT
{
    public partial class frmCreation : Form
    {
       
        //Champs...
        private string _texte;

        //Propriétés...
        public string Texte
        {
            get { return _texte; }
            set { _texte = value; }
        }

        //Constructeurs...
        public frmCreation()
        {
            InitializeComponent();
            UpdateVue();
        }
        //Méthodes...

        /// <summary>
        /// Créer un travail avec les données saisies
        /// </summary>
        /// <returns>Renvoie un travail disciplinaire crée</returns>
        public TravailDisciplinaire CreerTravail()
        {
            string NomProfesseur = tbxNomProf.Text;
            string PrenomProfesseur = tbxPrenomProf.Text;
            string NomEleve = tbxNomEleve.Text;
            string PrenomEleve = tbxPrenomEleve.Text;
            string ClasseEleve = tbxClasseEleve.Text;
            int Niveau = 0;

            if (rbnPersonnaliser.Checked == true)
                Niveau = 6;
            if (rbnNiveau1.Checked == true)
                Niveau = 1;
            if (rbnNiveau2.Checked == true)
                Niveau = 2;
            if (rbnNiveau3.Checked == true)
                Niveau = 3;
            if (rbnNiveau4.Checked == true)
                Niveau = 4;
            if (rbnNiveau5.Checked == true)
                Niveau = 5;

            TravailDisciplinaire Td;

            if (Niveau == 6)
                Td = new TravailDisciplinaire(NomProfesseur, PrenomProfesseur, NomEleve, PrenomEleve, ClasseEleve, Niveau, Texte);
            else
                Td = new TravailDisciplinaire(NomProfesseur, PrenomProfesseur, NomEleve, PrenomEleve, ClasseEleve, Niveau);

            return Td;
        }

        /// <summary>
        /// Vérifie si les champs sont remplis
        /// </summary>
        /// <returns>Renvoie vrai si les champs sont remplis</returns>
        public bool VerifierChamps()
        {
            bool Validation = true;

            if (this.tbxClasseEleve.Text != "" && this.tbxNomEleve.Text != "" && this.tbxNomProf.Text != "" && this.tbxPrenomEleve.Text != "" && this.tbxPrenomProf.Text != "")
            {
                Validation = true;
                if (rbnPersonnaliser.Checked == true)
                {
                    Validation = false;
                    if (Texte != "")
                    {
                        Validation = true;
                    }
                }
            }
            return Validation;
        }



        // A REFAIRE POUR SUPPRIMER LES ENTER EN TROP
        public string FiltrerTexte(string paramFichier)
        {
            string[] lireText = File.ReadAllLines(paramFichier, Encoding.Default);

            Texte = "";
            foreach (string uneLigne in lireText)
            {
                Texte += uneLigne + Environment.NewLine;
            }
            return Texte;
        }

        /// <summary>
        /// Raffraichit la vue
        /// </summary>
        public void UpdateVue()
        {
            //Choisi le texte à afficher en fonction du niveau
            if (ChoisirNiveau() == 6)
                tbxApercu.Text = Texte;
            else
            {
                Niveau Niveau = new Niveau(ChoisirNiveau());
                tbxApercu.Text = Niveau.ChoisirTexte();
            }
                
            //Determine si le bouton "Creer" est grisé ou pas
            if (VerifierChamps())
                btnCreer.Enabled = true;
            else
                btnCreer.Enabled = false;

            //Determine si le bouton "Personnaliser (...)" est grisé ou pas
            if (rbnPersonnaliser.Checked)
                btnPersonnaliser.Enabled = true;
            else
                btnPersonnaliser.Enabled = false;
        }

        //A REVOIR
        /// <summary>
        /// Choisi le niveau correspondant à la "case" coché
        /// </summary>
        /// <returns>Niveau du texte</returns>
        public int ChoisirNiveau()
        {
            int NiveauARetourner = 0;
            if (rbnPersonnaliser.Checked == true)
                NiveauARetourner = 6;
            if (rbnNiveau1.Checked == true)
                NiveauARetourner = 1;
            if (rbnNiveau2.Checked == true)
                NiveauARetourner = 2;
            if (rbnNiveau3.Checked == true)
                NiveauARetourner = 3;
            if (rbnNiveau4.Checked == true)
                NiveauARetourner = 4;
            if (rbnNiveau5.Checked == true)
                NiveauARetourner = 5;

            return NiveauARetourner;
        }

        // A Refaire au propre pour filtrer les caractères et mettre dans une fonction
        private void btnPersonnaliser_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == ofdOuvrir.ShowDialog())
            {
                this.Texte = FiltrerTexte(ofdOuvrir.FileName);
                tbxApercu.Text = Texte;
            }
        }

        private void rbnPersonnaliser_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVue();
        }

        private void tbx_TextChanged(object sender, EventArgs e)
        {
            UpdateVue();
        }

        private void rbnNiveau_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVue();
        }


    }
}
