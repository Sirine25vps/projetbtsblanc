namespace projetbtsblanc.Views
{
    partial class Form3
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
            cmbPatients = new ComboBox();
            label1 = new Label();
            btnNouveauPatient = new Button();
            label2 = new Label();
            txtNomPatient = new TextBox();
            txtPrenomPatient = new TextBox();
            label3 = new Label();
            dtpDateNaissance = new DateTimePicker();
            numPoids = new NumericUpDown();
            label4 = new Label();
            label5 = new Label();
            numTaille = new NumericUpDown();
            cmbSexe = new ComboBox();
            label6 = new Label();
            mtbSecu = new MaskedTextBox();
            label7 = new Label();
            txtPathologies = new RichTextBox();
            label8 = new Label();
            txtOrdonnances = new RichTextBox();
            label9 = new Label();
            label10 = new Label();
            btnModifier = new Button();
            btnCreer = new Button();
            btnSupprimer = new Button();
            btnRedigerOrdonnance = new Button();
            ((System.ComponentModel.ISupportInitialize)numPoids).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTaille).BeginInit();
            SuspendLayout();
            // 
            // cmbPatients
            // 
            cmbPatients.FormattingEnabled = true;
            cmbPatients.Location = new Point(114, 57);
            cmbPatients.Name = "cmbPatients";
            cmbPatients.Size = new Size(182, 33);
            cmbPatients.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(114, 28);
            label1.Name = "label1";
            label1.Size = new Size(65, 25);
            label1.TabIndex = 1;
            label1.Text = "Patient";
            // 
            // btnNouveauPatient
            // 
            btnNouveauPatient.Location = new Point(372, 57);
            btnNouveauPatient.Name = "btnNouveauPatient";
            btnNouveauPatient.Size = new Size(159, 34);
            btnNouveauPatient.TabIndex = 2;
            btnNouveauPatient.Text = "+ Nouv. Patient";
            btnNouveauPatient.UseVisualStyleBackColor = true;
            btnNouveauPatient.Click += btnNouveauPatient_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(114, 101);
            label2.Name = "label2";
            label2.Size = new Size(52, 25);
            label2.TabIndex = 3;
            label2.Text = "Nom";
            // 
            // txtNomPatient
            // 
            txtNomPatient.Location = new Point(114, 129);
            txtNomPatient.Name = "txtNomPatient";
            txtNomPatient.Size = new Size(150, 31);
            txtNomPatient.TabIndex = 4;
            // 
            // txtPrenomPatient
            // 
            txtPrenomPatient.Location = new Point(372, 129);
            txtPrenomPatient.Name = "txtPrenomPatient";
            txtPrenomPatient.Size = new Size(159, 31);
            txtPrenomPatient.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(372, 101);
            label3.Name = "label3";
            label3.Size = new Size(74, 25);
            label3.TabIndex = 5;
            label3.Text = "Prénom";
            // 
            // dtpDateNaissance
            // 
            dtpDateNaissance.Format = DateTimePickerFormat.Short;
            dtpDateNaissance.Location = new Point(119, 208);
            dtpDateNaissance.Name = "dtpDateNaissance";
            dtpDateNaissance.Size = new Size(154, 31);
            dtpDateNaissance.TabIndex = 7;
            // 
            // numPoids
            // 
            numPoids.DecimalPlaces = 1;
            numPoids.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numPoids.Location = new Point(572, 211);
            numPoids.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            numPoids.Name = "numPoids";
            numPoids.Size = new Size(73, 31);
            numPoids.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(570, 182);
            label4.Name = "label4";
            label4.Size = new Size(55, 25);
            label4.TabIndex = 9;
            label4.Text = "Poids";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(680, 182);
            label5.Name = "label5";
            label5.Size = new Size(49, 25);
            label5.TabIndex = 11;
            label5.Text = "Taille";
            // 
            // numTaille
            // 
            numTaille.DecimalPlaces = 2;
            numTaille.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numTaille.Location = new Point(682, 211);
            numTaille.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            numTaille.Name = "numTaille";
            numTaille.Size = new Size(73, 31);
            numTaille.TabIndex = 10;
            // 
            // cmbSexe
            // 
            cmbSexe.FormattingEnabled = true;
            cmbSexe.Location = new Point(114, 285);
            cmbSexe.Name = "cmbSexe";
            cmbSexe.Size = new Size(182, 33);
            cmbSexe.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(119, 257);
            label6.Name = "label6";
            label6.Size = new Size(48, 25);
            label6.TabIndex = 13;
            label6.Text = "Sexe";
            // 
            // mtbSecu
            // 
            mtbSecu.Location = new Point(114, 358);
            mtbSecu.Mask = "0 00 00 00 000 000 00";
            mtbSecu.Name = "mtbSecu";
            mtbSecu.Size = new Size(277, 31);
            mtbSecu.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(119, 330);
            label7.Name = "label7";
            label7.Size = new Size(225, 25);
            label7.TabIndex = 15;
            label7.Text = "Numéro de sécurité sociale";
            // 
            // txtPathologies
            // 
            txtPathologies.Location = new Point(472, 302);
            txtPathologies.Name = "txtPathologies";
            txtPathologies.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtPathologies.Size = new Size(319, 76);
            txtPathologies.TabIndex = 16;
            txtPathologies.Text = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(472, 274);
            label8.Name = "label8";
            label8.Size = new Size(114, 25);
            label8.TabIndex = 17;
            label8.Text = "Pathologie(s)";
            // 
            // txtOrdonnances
            // 
            txtOrdonnances.Location = new Point(114, 439);
            txtOrdonnances.Name = "txtOrdonnances";
            txtOrdonnances.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtOrdonnances.Size = new Size(716, 99);
            txtOrdonnances.TabIndex = 18;
            txtOrdonnances.Text = "";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(119, 180);
            label9.Name = "label9";
            label9.Size = new Size(154, 25);
            label9.TabIndex = 19;
            label9.Text = "Date de naissance";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(119, 411);
            label10.Name = "label10";
            label10.Size = new Size(118, 25);
            label10.TabIndex = 20;
            label10.Text = "Ordonnances";
            // 
            // btnModifier
            // 
            btnModifier.Location = new Point(718, 568);
            btnModifier.Name = "btnModifier";
            btnModifier.Size = new Size(112, 34);
            btnModifier.TabIndex = 21;
            btnModifier.Text = "Modifier";
            btnModifier.UseVisualStyleBackColor = true;
            btnModifier.Click += btnModifier_Click;
            // 
            // btnCreer
            // 
            btnCreer.Location = new Point(572, 568);
            btnCreer.Name = "btnCreer";
            btnCreer.Size = new Size(112, 34);
            btnCreer.TabIndex = 22;
            btnCreer.Text = "Créer";
            btnCreer.UseVisualStyleBackColor = true;
            btnCreer.Click += btnCreer_Click;
            // 
            // btnSupprimer
            // 
            btnSupprimer.Location = new Point(429, 568);
            btnSupprimer.Name = "btnSupprimer";
            btnSupprimer.Size = new Size(112, 34);
            btnSupprimer.TabIndex = 23;
            btnSupprimer.Text = "Supprimer";
            btnSupprimer.UseVisualStyleBackColor = true;
            btnSupprimer.Click += btnSupprimer_Click;
            // 
            // btnRedigerOrdonnance
            // 
            btnRedigerOrdonnance.Location = new Point(113, 547);
            btnRedigerOrdonnance.Name = "btnRedigerOrdonnance";
            btnRedigerOrdonnance.Size = new Size(231, 34);
            btnRedigerOrdonnance.TabIndex = 24;
            btnRedigerOrdonnance.Text = "Rédiger une ordonnance";
            btnRedigerOrdonnance.UseVisualStyleBackColor = true;
           
            // Form3
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(897, 626);
            Controls.Add(btnRedigerOrdonnance);
            Controls.Add(btnSupprimer);
            Controls.Add(btnCreer);
            Controls.Add(btnModifier);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(txtOrdonnances);
            Controls.Add(label8);
            Controls.Add(txtPathologies);
            Controls.Add(label7);
            Controls.Add(mtbSecu);
            Controls.Add(label6);
            Controls.Add(cmbSexe);
            Controls.Add(label5);
            Controls.Add(numTaille);
            Controls.Add(label4);
            Controls.Add(numPoids);
            Controls.Add(dtpDateNaissance);
            Controls.Add(txtPrenomPatient);
            Controls.Add(label3);
            Controls.Add(txtNomPatient);
            Controls.Add(label2);
            Controls.Add(btnNouveauPatient);
            Controls.Add(label1);
            Controls.Add(cmbPatients);
            Name = "Form3";
            Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)numPoids).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTaille).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbPatients;
        private Label label1;
        private Button btnNouveauPatient;
        private Label label2;
        private TextBox txtNomPatient;
        private TextBox txtPrenomPatient;
        private Label label3;
        private DateTimePicker dtpDateNaissance;
        private NumericUpDown numPoids;
        private Label label4;
        private Label label5;
        private NumericUpDown numTaille;
        private ComboBox cmbSexe;
        private Label label6;
        private MaskedTextBox mtbSecu;
        private Label label7;
        private RichTextBox txtPathologies;
        private Label label8;
        private RichTextBox txtOrdonnances;
        private Label label9;
        private Label label10;
        private Button btnModifier;
        private Button btnCreer;
        private Button btnSupprimer;
        private Button btnRedigerOrdonnance;
    }
}