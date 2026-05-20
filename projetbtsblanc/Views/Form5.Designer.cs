namespace projetbtsblanc.Views
{
    partial class Form5
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
            txtMedicament = new TextBox();
            label1 = new Label();
            dtpDateLimite = new DateTimePicker();
            label2 = new Label();
            numDose = new NumericUpDown();
            LABEL = new Label();
            cmbDose = new ComboBox();
            cmbFrequence = new ComboBox();
            label4 = new Label();
            numFrequence = new NumericUpDown();
            btnAjouter = new Button();
            dgvPrescriptions = new DataGridView();
            btnSupprimerLigne = new Button();
            btnValiderFinal = new Button();
            ((System.ComponentModel.ISupportInitialize)numDose).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numFrequence).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPrescriptions).BeginInit();
            SuspendLayout();
            // 
            // txtMedicament
            // 
            txtMedicament.Location = new Point(123, 50);
            txtMedicament.Name = "txtMedicament";
            txtMedicament.Size = new Size(150, 31);
            txtMedicament.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(126, 23);
            label1.Name = "label1";
            label1.Size = new Size(110, 25);
            label1.TabIndex = 1;
            label1.Text = "Médicament";
            // 
            // dtpDateLimite
            // 
            dtpDateLimite.Location = new Point(413, 50);
            dtpDateLimite.Name = "dtpDateLimite";
            dtpDateLimite.Size = new Size(300, 31);
            dtpDateLimite.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(413, 22);
            label2.Name = "label2";
            label2.Size = new Size(97, 25);
            label2.TabIndex = 3;
            label2.Text = "Date limite";
            // 
            // numDose
            // 
            numDose.DecimalPlaces = 2;
            numDose.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
            numDose.Location = new Point(126, 133);
            numDose.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numDose.Name = "numDose";
            numDose.Size = new Size(71, 31);
            numDose.TabIndex = 4;
            // 
            // LABEL
            // 
            LABEL.AutoSize = true;
            LABEL.Location = new Point(123, 105);
            LABEL.Name = "LABEL";
            LABEL.Size = new Size(53, 25);
            LABEL.TabIndex = 5;
            LABEL.Text = "Dose";
            // 
            // cmbDose
            // 
            cmbDose.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDose.FormattingEnabled = true;
            cmbDose.Items.AddRange(new object[] { "mg", "g", "ml", "gouttes", "comprimé(s)", "gélule(s)", "gummies" });
            cmbDose.Location = new Point(203, 133);
            cmbDose.Name = "cmbDose";
            cmbDose.Size = new Size(90, 33);
            cmbDose.TabIndex = 6;
            // 
            // cmbFrequence
            // 
            cmbFrequence.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFrequence.FormattingEnabled = true;
            cmbFrequence.Items.AddRange(new object[] { "/ jour", "/ 24h", "/ semaine", "/ mois", "à la demande", "si douleurs" });
            cmbFrequence.Location = new Point(203, 209);
            cmbFrequence.Name = "cmbFrequence";
            cmbFrequence.Size = new Size(90, 33);
            cmbFrequence.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(123, 181);
            label4.Name = "label4";
            label4.Size = new Size(93, 25);
            label4.TabIndex = 8;
            label4.Text = "Fréquence";
            // 
            // numFrequence
            // 
            numFrequence.Location = new Point(126, 209);
            numFrequence.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numFrequence.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numFrequence.Name = "numFrequence";
            numFrequence.Size = new Size(71, 31);
            numFrequence.TabIndex = 7;
            numFrequence.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAjouter
            // 
            btnAjouter.Location = new Point(495, 209);
            btnAjouter.Name = "btnAjouter";
            btnAjouter.Size = new Size(137, 34);
            btnAjouter.TabIndex = 10;
            btnAjouter.Text = "Valider";
            btnAjouter.UseVisualStyleBackColor = true;
            btnAjouter.Click += btnAjouter_Click;
            // 
            // dgvPrescriptions
            // 
            dgvPrescriptions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrescriptions.Location = new Point(100, 272);
            dgvPrescriptions.Name = "dgvPrescriptions";
            dgvPrescriptions.RowHeadersWidth = 62;
            dgvPrescriptions.Size = new Size(640, 135);
            dgvPrescriptions.TabIndex = 11;
            // 
            // btnSupprimerLigne
            // 
            btnSupprimerLigne.Location = new Point(628, 413);
            btnSupprimerLigne.Name = "btnSupprimerLigne";
            btnSupprimerLigne.Size = new Size(112, 34);
            btnSupprimerLigne.TabIndex = 12;
            btnSupprimerLigne.Text = "Supprimer";
            btnSupprimerLigne.UseVisualStyleBackColor = true;
            btnSupprimerLigne.Click += btnSupprimerLigne_Click;
            // 
            // btnValiderFinal
            // 
            btnValiderFinal.Location = new Point(360, 438);
            btnValiderFinal.Name = "btnValiderFinal";
            btnValiderFinal.Size = new Size(112, 34);
            btnValiderFinal.TabIndex = 13;
            btnValiderFinal.Text = "Valider";
            btnValiderFinal.UseVisualStyleBackColor = true;
            btnValiderFinal.Click += btnValiderFinal_Click;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(844, 494);
            Controls.Add(btnValiderFinal);
            Controls.Add(btnSupprimerLigne);
            Controls.Add(dgvPrescriptions);
            Controls.Add(btnAjouter);
            Controls.Add(cmbFrequence);
            Controls.Add(label4);
            Controls.Add(numFrequence);
            Controls.Add(cmbDose);
            Controls.Add(LABEL);
            Controls.Add(numDose);
            Controls.Add(label2);
            Controls.Add(dtpDateLimite);
            Controls.Add(label1);
            Controls.Add(txtMedicament);
            Name = "Form5";
            Text = "Form5";
            ((System.ComponentModel.ISupportInitialize)numDose).EndInit();
            ((System.ComponentModel.ISupportInitialize)numFrequence).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPrescriptions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMedicament;
        private Label label1;
        private DateTimePicker dtpDateLimite;
        private Label label2;
        private NumericUpDown numDose;
        private Label LABEL;
        private ComboBox cmbDose;
        private ComboBox cmbFrequence;
        private Label label4;
        private NumericUpDown numFrequence;
        private Button btnAjouter;
        private DataGridView dgvPrescriptions;
        private Button btnSupprimerLigne;
        private Button btnValiderFinal;
    }
}