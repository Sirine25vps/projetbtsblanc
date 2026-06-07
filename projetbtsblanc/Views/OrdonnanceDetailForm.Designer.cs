namespace projetbtsblanc.Views
{
    partial class OrdonnanceDetailForm
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
            label4 = new Label();
            label5 = new Label();
            lstAllergies = new ListBox();
            dgvHistorique = new DataGridView();
            label6 = new Label();
            label7 = new Label();
            btnFermer = new Button();
            lblNom = new Label();
            lblDateNaissance = new Label();
            lblNumeroSecu = new Label();
            lblAge = new Label();
            lblPrenom = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvHistorique).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 138);
            label1.Name = "label1";
            label1.Size = new Size(88, 25);
            label1.TabIndex = 0;
            label1.Text = "N° Sécu : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(316, 30);
            label2.Name = "label2";
            label2.Size = new Size(88, 25);
            label2.TabIndex = 1;
            label2.Text = "Prénom : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 92);
            label3.Name = "label3";
            label3.Size = new Size(85, 25);
            label3.TabIndex = 2;
            label3.Text = "Né(e) le : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(50, 30);
            label4.Name = "label4";
            label4.Size = new Size(66, 25);
            label4.TabIndex = 3;
            label4.Text = "Nom : ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(316, 92);
            label5.Name = "label5";
            label5.Size = new Size(58, 25);
            label5.TabIndex = 4;
            label5.Text = "Âge : ";
            // 
            // lstAllergies
            // 
            lstAllergies.FormattingEnabled = true;
            lstAllergies.Location = new Point(50, 240);
            lstAllergies.Name = "lstAllergies";
            lstAllergies.Size = new Size(209, 179);
            lstAllergies.TabIndex = 5;
            // 
            // dgvHistorique
            // 
            dgvHistorique.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorique.Location = new Point(327, 178);
            dgvHistorique.Name = "dgvHistorique";
            dgvHistorique.RowHeadersWidth = 62;
            dgvHistorique.Size = new Size(360, 241);
            dgvHistorique.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(50, 212);
            label6.Name = "label6";
            label6.Size = new Size(79, 25);
            label6.TabIndex = 7;
            label6.Text = "Allergies";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(325, 148);
            label7.Name = "label7";
            label7.Size = new Size(235, 25);
            label7.TabIndex = 8;
            label7.Text = "Historique des ordonnances";
            // 
            // btnFermer
            // 
            btnFermer.Location = new Point(575, 433);
            btnFermer.Name = "btnFermer";
            btnFermer.Size = new Size(112, 34);
            btnFermer.TabIndex = 9;
            btnFermer.Text = "Fermer";
            btnFermer.UseVisualStyleBackColor = true;
            btnFermer.Click += btnFermer_Click;
            // 
            // lblNom
            // 
            lblNom.AutoSize = true;
            lblNom.Location = new Point(122, 30);
            lblNom.Name = "lblNom";
            lblNom.Size = new Size(0, 25);
            lblNom.TabIndex = 12;
            // 
            // lblDateNaissance
            // 
            lblDateNaissance.AutoSize = true;
            lblDateNaissance.Location = new Point(134, 92);
            lblDateNaissance.Name = "lblDateNaissance";
            lblDateNaissance.Size = new Size(0, 25);
            lblDateNaissance.TabIndex = 11;
            // 
            // lblNumeroSecu
            // 
            lblNumeroSecu.AutoSize = true;
            lblNumeroSecu.Location = new Point(134, 138);
            lblNumeroSecu.Name = "lblNumeroSecu";
            lblNumeroSecu.Size = new Size(0, 25);
            lblNumeroSecu.TabIndex = 10;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(371, 92);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(0, 25);
            lblAge.TabIndex = 14;
            // 
            // lblPrenom
            // 
            lblPrenom.AutoSize = true;
            lblPrenom.Location = new Point(397, 30);
            lblPrenom.Name = "lblPrenom";
            lblPrenom.Size = new Size(0, 25);
            lblPrenom.TabIndex = 13;
            // 
            // PatientDetailForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 479);
            Controls.Add(lblAge);
            Controls.Add(lblPrenom);
            Controls.Add(lblNom);
            Controls.Add(lblDateNaissance);
            Controls.Add(lblNumeroSecu);
            Controls.Add(btnFermer);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(dgvHistorique);
            Controls.Add(lstAllergies);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "PatientDetailForm";
            Text = "PatientDetailForm";
            ((System.ComponentModel.ISupportInitialize)dgvHistorique).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ListBox lstAllergies;
        private DataGridView dgvHistorique;
        private Label label6;
        private Label label7;
        private Button btnFermer;
        private Label lblNom;
        private Label lblDateNaissance;
        private Label lblNumeroSecu;
        private Label lblAge;
        private Label lblPrenom;
    }
}