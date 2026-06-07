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
            ((System.ComponentModel.ISupportInitialize)dgvMedicaments).BeginInit();
            SuspendLayout();
            // 
            // cmbMedecins
            // 
            cmbMedecins.FormattingEnabled = true;
            cmbMedecins.Location = new Point(97, 64);
            cmbMedecins.Name = "cmbMedecins";
            cmbMedecins.Size = new Size(182, 33);
            cmbMedecins.TabIndex = 0;
            // 
            // cmbMedicaments
            // 
            cmbMedicaments.FormattingEnabled = true;
            cmbMedicaments.Location = new Point(359, 64);
            cmbMedicaments.Name = "cmbMedicaments";
            cmbMedicaments.Size = new Size(182, 33);
            cmbMedicaments.TabIndex = 1;
            // 
            // btnAjouterMedoc
            // 
            btnAjouterMedoc.Location = new Point(68, 369);
            btnAjouterMedoc.Name = "btnAjouterMedoc";
            btnAjouterMedoc.Size = new Size(191, 34);
            btnAjouterMedoc.TabIndex = 2;
            btnAjouterMedoc.Text = "Ajouter médicament";
            btnAjouterMedoc.UseVisualStyleBackColor = true;
            // 
            // btnEnregistrer
            // 
            btnEnregistrer.Location = new Point(545, 369);
            btnEnregistrer.Name = "btnEnregistrer";
            btnEnregistrer.Size = new Size(112, 34);
            btnEnregistrer.TabIndex = 4;
            btnEnregistrer.Text = "Enregistrer";
            btnEnregistrer.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(100, 36);
            label1.Name = "label1";
            label1.Size = new Size(79, 25);
            label1.TabIndex = 5;
            label1.Text = "Medecin";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(360, 34);
            label2.Name = "label2";
            label2.Size = new Size(65, 25);
            label2.TabIndex = 6;
            label2.Text = "Patient";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(97, 132);
            label3.Name = "label3";
            label3.Size = new Size(178, 25);
            label3.TabIndex = 7;
            label3.Text = "Ligne de prescription";
            // 
            // dgvMedicaments
            // 
            dgvMedicaments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedicaments.Location = new Point(87, 190);
            dgvMedicaments.Name = "dgvMedicaments";
            dgvMedicaments.RowHeadersWidth = 62;
            dgvMedicaments.Size = new Size(541, 124);
            dgvMedicaments.TabIndex = 8;
            // 
            // OrdonnanceEditForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvMedicaments);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnEnregistrer);
            Controls.Add(btnAjouterMedoc);
            Controls.Add(cmbMedicaments);
            Controls.Add(cmbMedecins);
            Name = "OrdonnanceEditForm";
            Text = "OrdonnanceEditForm";
            ((System.ComponentModel.ISupportInitialize)dgvMedicaments).EndInit();
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
    }
}