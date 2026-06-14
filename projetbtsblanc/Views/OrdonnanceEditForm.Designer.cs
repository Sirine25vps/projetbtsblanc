namespace projetbtsblanc.Views
{
    partial class OrdonnanceEditForm
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
            cmbMedecins = new ComboBox();
            cmbMedicaments = new ComboBox();
            btnAjouterMedoc = new Button();
            btnEnregistrer = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dgvMedicaments = new DataGridView();
            numDose = new NumericUpDown();
            Dosage = new Label();
            cmbUnite = new ComboBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMedicaments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDose).BeginInit();
            SuspendLayout();
            // 
            // cmbMedecins
            // 
            cmbMedecins.FormattingEnabled = true;
            cmbMedecins.Location = new Point(87, 43);
            cmbMedecins.Name = "cmbMedecins";
            cmbMedecins.Size = new Size(182, 33);
            cmbMedecins.TabIndex = 0;
            // 
            // cmbMedicaments
            // 
            cmbMedicaments.FormattingEnabled = true;
            cmbMedicaments.Location = new Point(316, 43);
            cmbMedicaments.Name = "cmbMedicaments";
            cmbMedicaments.Size = new Size(182, 33);
            cmbMedicaments.TabIndex = 1;
            // 
            // btnAjouterMedoc
            // 
            btnAjouterMedoc.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAjouterMedoc.Location = new Point(64, 390);
            btnAjouterMedoc.Name = "btnAjouterMedoc";
            btnAjouterMedoc.Size = new Size(191, 34);
            btnAjouterMedoc.TabIndex = 2;
            btnAjouterMedoc.Text = "Ajouter médicament";
            btnAjouterMedoc.UseVisualStyleBackColor = true;
            btnAjouterMedoc.Click += btnAjouterMedoc_Click_1;
            // 
            // btnEnregistrer
            // 
            btnEnregistrer.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEnregistrer.Location = new Point(556, 390);
            btnEnregistrer.Name = "btnEnregistrer";
            btnEnregistrer.Size = new Size(112, 34);
            btnEnregistrer.TabIndex = 4;
            btnEnregistrer.Text = "Enregistrer";
            btnEnregistrer.UseVisualStyleBackColor = true;
            btnEnregistrer.Click += btnEnregistrer_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(87, 15);
            label1.Name = "label1";
            label1.Size = new Size(79, 25);
            label1.TabIndex = 5;
            label1.Text = "Medecin";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(317, 13);
            label2.Name = "label2";
            label2.Size = new Size(110, 25);
            label2.TabIndex = 6;
            label2.Text = "Médicament";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(87, 108);
            label3.Name = "label3";
            label3.Size = new Size(178, 25);
            label3.TabIndex = 7;
            label3.Text = "Ligne de prescription";
            // 
            // dgvMedicaments
            // 
            dgvMedicaments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMedicaments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedicaments.Location = new Point(87, 146);
            dgvMedicaments.Name = "dgvMedicaments";
            dgvMedicaments.ReadOnly = true;
            dgvMedicaments.RowHeadersWidth = 62;
            dgvMedicaments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedicaments.Size = new Size(570, 227);
            dgvMedicaments.TabIndex = 8;
            // 
            // numDose
            // 
            numDose.DecimalPlaces = 2;
            numDose.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numDose.Location = new Point(556, 45);
            numDose.Name = "numDose";
            numDose.Size = new Size(53, 31);
            numDose.TabIndex = 9;
            // 
            // Dosage
            // 
            Dosage.AutoSize = true;
            Dosage.Location = new Point(546, 17);
            Dosage.Name = "Dosage";
            Dosage.Size = new Size(73, 25);
            Dosage.TabIndex = 10;
            Dosage.Text = "Dosage";
            // 
            // cmbUnite
            // 
            cmbUnite.FormattingEnabled = true;
            cmbUnite.Items.AddRange(new object[] { "mg", "g", "ml", "comprimé(s)" });
            cmbUnite.Location = new Point(634, 45);
            cmbUnite.Name = "cmbUnite";
            cmbUnite.Size = new Size(76, 33);
            cmbUnite.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(634, 17);
            label4.Name = "label4";
            label4.Size = new Size(53, 25);
            label4.TabIndex = 12;
            label4.Text = "Unité";
            // 
            // OrdonnanceEditForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(cmbUnite);
            Controls.Add(Dosage);
            Controls.Add(numDose);
            Controls.Add(dgvMedicaments);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnEnregistrer);
            Controls.Add(btnAjouterMedoc);
            Controls.Add(cmbMedicaments);
            Controls.Add(cmbMedecins);
            Name = "OrdonnanceEditForm";
            Text = "nouvelle ordonnance";
            ((System.ComponentModel.ISupportInitialize)dgvMedicaments).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDose).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbMedecins;
        private ComboBox cmbMedicaments;
        private Button btnAjouterMedoc;
        private Button btnEnregistrer;
        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dgvMedicaments;
        private NumericUpDown numDose;
        private Label Dosage;
        private ComboBox cmbUnite;
        private Label label4;
    }
}