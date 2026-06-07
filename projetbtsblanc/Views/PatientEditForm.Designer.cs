namespace projetbtsblanc.Views
{
    partial class PatientEditForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtNom = new TextBox();
            txtPrenom = new TextBox();
            dtpDateNaissance = new DateTimePicker();
            btnEnregistrer = new Button();
            btnAnnuler = new Button();
            Taille = new Label();
            numTaille = new NumericUpDown();
            label5 = new Label();
            numPoids = new NumericUpDown();
            lblSexe = new Label();
            cmbSexe = new ComboBox();
            txtNumeroSecu = new MaskedTextBox();
            label4 = new Label();
            label8 = new Label();
            txtPathologies = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)numTaille).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPoids).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(79, 58);
            label1.Name = "label1";
            label1.Size = new Size(52, 25);
            label1.TabIndex = 0;
            label1.Text = "Nom";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(79, 139);
            label2.Name = "label2";
            label2.Size = new Size(74, 25);
            label2.TabIndex = 1;
            label2.Text = "Prénom";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(79, 222);
            label3.Name = "label3";
            label3.Size = new Size(159, 25);
            label3.TabIndex = 2;
            label3.Text = "Date de naissance ";
            // 
            // txtNom
            // 
            txtNom.Location = new Point(79, 86);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(150, 31);
            txtNom.TabIndex = 4;
            // 
            // txtPrenom
            // 
            txtPrenom.Location = new Point(79, 167);
            txtPrenom.Name = "txtPrenom";
            txtPrenom.Size = new Size(150, 31);
            txtPrenom.TabIndex = 5;
            // 
            // dtpDateNaissance
            // 
            dtpDateNaissance.Format = DateTimePickerFormat.Short;
            dtpDateNaissance.Location = new Point(79, 250);
            dtpDateNaissance.Name = "dtpDateNaissance";
            dtpDateNaissance.Size = new Size(155, 31);
            dtpDateNaissance.TabIndex = 6;
            // 
            // btnEnregistrer
            // 
            btnEnregistrer.Location = new Point(429, 493);
            btnEnregistrer.Name = "btnEnregistrer";
            btnEnregistrer.Size = new Size(112, 34);
            btnEnregistrer.TabIndex = 8;
            btnEnregistrer.Text = "Enregistrer";
            btnEnregistrer.UseVisualStyleBackColor = true;
            btnEnregistrer.Click += btnEnregistrer_Click;
            // 
            // btnAnnuler
            // 
            btnAnnuler.Location = new Point(573, 493);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(112, 34);
            btnAnnuler.TabIndex = 9;
            btnAnnuler.Text = "Annuler";
            btnAnnuler.UseVisualStyleBackColor = true;
            btnAnnuler.Click += btnAnnuler_Click;
            // 
            // Taille
            // 
            Taille.AutoSize = true;
            Taille.Location = new Point(447, 57);
            Taille.Name = "Taille";
            Taille.Size = new Size(49, 25);
            Taille.TabIndex = 13;
            Taille.Text = "Taille";
            Taille.TextAlign = ContentAlignment.TopCenter;
            // 
            // numTaille
            // 
            numTaille.DecimalPlaces = 2;
            numTaille.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numTaille.Location = new Point(447, 87);
            numTaille.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numTaille.Name = "numTaille";
            numTaille.Size = new Size(76, 31);
            numTaille.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(335, 57);
            label5.Name = "label5";
            label5.Size = new Size(55, 25);
            label5.TabIndex = 11;
            label5.Text = "Poids";
            // 
            // numPoids
            // 
            numPoids.DecimalPlaces = 1;
            numPoids.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numPoids.Location = new Point(335, 87);
            numPoids.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            numPoids.Name = "numPoids";
            numPoids.Size = new Size(76, 31);
            numPoids.TabIndex = 10;
            // 
            // lblSexe
            // 
            lblSexe.AutoSize = true;
            lblSexe.Location = new Point(335, 139);
            lblSexe.Name = "lblSexe";
            lblSexe.Size = new Size(48, 25);
            lblSexe.TabIndex = 18;
            lblSexe.Text = "Sexe";
            // 
            // cmbSexe
            // 
            cmbSexe.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSexe.FormattingEnabled = true;
            cmbSexe.Items.AddRange(new object[] { "Homme", "Femme " });
            cmbSexe.Location = new Point(335, 167);
            cmbSexe.Name = "cmbSexe";
            cmbSexe.Size = new Size(182, 33);
            cmbSexe.TabIndex = 17;
            // 
            // txtNumeroSecu
            // 
            txtNumeroSecu.Location = new Point(335, 252);
            txtNumeroSecu.Mask = "0 00 00 00 000 000 00";
            txtNumeroSecu.Name = "txtNumeroSecu";
            txtNumeroSecu.Size = new Size(225, 31);
            txtNumeroSecu.TabIndex = 20;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(335, 222);
            label4.Name = "label4";
            label4.Size = new Size(225, 25);
            label4.TabIndex = 19;
            label4.Text = "Numéro de sécurité sociale";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(79, 304);
            label8.Name = "label8";
            label8.Size = new Size(104, 25);
            label8.TabIndex = 22;
            label8.Text = "Pathologies";
            // 
            // txtPathologies
            // 
            txtPathologies.Location = new Point(79, 332);
            txtPathologies.Name = "txtPathologies";
            txtPathologies.Size = new Size(540, 138);
            txtPathologies.TabIndex = 21;
            txtPathologies.Text = "";
            // 
            // PatientEditForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(746, 552);
            Controls.Add(label8);
            Controls.Add(txtPathologies);
            Controls.Add(txtNumeroSecu);
            Controls.Add(label4);
            Controls.Add(lblSexe);
            Controls.Add(cmbSexe);
            Controls.Add(Taille);
            Controls.Add(numTaille);
            Controls.Add(label5);
            Controls.Add(numPoids);
            Controls.Add(btnAnnuler);
            Controls.Add(btnEnregistrer);
            Controls.Add(dtpDateNaissance);
            Controls.Add(txtPrenom);
            Controls.Add(txtNom);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "PatientEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "PatientEditForm";
            ((System.ComponentModel.ISupportInitialize)numTaille).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPoids).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtNom;
        private TextBox txtPrenom;
        private DateTimePicker dtpDateNaissance;
        private Button btnEnregistrer;
        private Button btnAnnuler;
        private Label Taille;
        private NumericUpDown numTaille;
        private Label label5;
        private NumericUpDown numPoids;
        private Label lblSexe;
        private ComboBox cmbSexe;
        private MaskedTextBox txtNumeroSecu;
        private Label label4;
        private Label label8;
        private RichTextBox txtPathologies;
    }
}