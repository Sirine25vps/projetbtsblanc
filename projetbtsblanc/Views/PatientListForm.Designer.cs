namespace projetbtsblanc.Views
{
    partial class PatientListForm
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
            dgvPatients = new DataGridView();
            btnRechercher = new Button();
            lblRecherche = new Label();
            txtRecherche = new TextBox();
            cmbAllergies = new ComboBox();
            lblAllergie = new Label();
            btnReinitialiser = new Button();
            btnNouveauPatient = new Button();
            btnDetail = new Button();
            btnSuppr = new Button();
            btnNouvOrdo = new Button();
            btnGestionOrdonnances = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            SuspendLayout();
            // 
            // dgvPatients
            // 
            dgvPatients.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatients.Location = new Point(88, 108);
            dgvPatients.Name = "dgvPatients";
            dgvPatients.RowHeadersWidth = 62;
            dgvPatients.Size = new Size(801, 335);
            dgvPatients.TabIndex = 0;
            dgvPatients.CellDoubleClick += dgvPatients_CellDoubleClick;
            // 
            // btnRechercher
            // 
            btnRechercher.Location = new Point(634, 35);
            btnRechercher.Name = "btnRechercher";
            btnRechercher.Size = new Size(112, 34);
            btnRechercher.TabIndex = 1;
            btnRechercher.Text = "OK";
            btnRechercher.UseVisualStyleBackColor = true;
            btnRechercher.Click += btnRechercher_Click;
            // 
            // lblRecherche
            // 
            lblRecherche.AutoSize = true;
            lblRecherche.Location = new Point(31, 38);
            lblRecherche.Name = "lblRecherche";
            lblRecherche.Size = new Size(106, 25);
            lblRecherche.TabIndex = 3;
            lblRecherche.Text = "Rechercher :";
            // 
            // txtRecherche
            // 
            txtRecherche.Location = new Point(143, 38);
            txtRecherche.Name = "txtRecherche";
            txtRecherche.Size = new Size(135, 31);
            txtRecherche.TabIndex = 4;
            // 
            // cmbAllergies
            // 
            cmbAllergies.FormattingEnabled = true;
            cmbAllergies.Location = new Point(404, 38);
            cmbAllergies.Name = "cmbAllergies";
            cmbAllergies.Size = new Size(184, 33);
            cmbAllergies.TabIndex = 6;
            // 
            // lblAllergie
            // 
            lblAllergie.AutoSize = true;
            lblAllergie.Location = new Point(313, 41);
            lblAllergie.Name = "lblAllergie";
            lblAllergie.Size = new Size(85, 25);
            lblAllergie.TabIndex = 7;
            lblAllergie.Text = "Allergie : ";
            // 
            // btnReinitialiser
            // 
            btnReinitialiser.Location = new Point(766, 35);
            btnReinitialiser.Name = "btnReinitialiser";
            btnReinitialiser.Size = new Size(113, 33);
            btnReinitialiser.TabIndex = 8;
            btnReinitialiser.Text = "Réinitialiser";
            btnReinitialiser.UseVisualStyleBackColor = true;
            btnReinitialiser.Click += btnReinitialiser_Click;
            // 
            // btnNouveauPatient
            // 
            btnNouveauPatient.Anchor = AnchorStyles.Bottom;
            btnNouveauPatient.Location = new Point(664, 473);
            btnNouveauPatient.Name = "btnNouveauPatient";
            btnNouveauPatient.Size = new Size(166, 41);
            btnNouveauPatient.TabIndex = 9;
            btnNouveauPatient.Text = "Nouveau Patient";
            btnNouveauPatient.UseVisualStyleBackColor = true;
            btnNouveauPatient.Click += btnNouveauPatient_Click;
            // 
            // btnDetail
            // 
            btnDetail.Anchor = AnchorStyles.Bottom;
            btnDetail.Location = new Point(540, 473);
            btnDetail.Name = "btnDetail";
            btnDetail.Size = new Size(118, 41);
            btnDetail.TabIndex = 10;
            btnDetail.Text = "Voir détail";
            btnDetail.UseVisualStyleBackColor = true;
            btnDetail.Click += btnDetail_Click;
            // 
            // btnSuppr
            // 
            btnSuppr.Anchor = AnchorStyles.Bottom;
            btnSuppr.Location = new Point(836, 473);
            btnSuppr.Name = "btnSuppr";
            btnSuppr.Size = new Size(115, 41);
            btnSuppr.TabIndex = 11;
            btnSuppr.Text = "Supprimer";
            btnSuppr.UseVisualStyleBackColor = true;
            btnSuppr.Click += btnSuppr_Click;
            // 
            // btnNouvOrdo
            // 
            btnNouvOrdo.Anchor = AnchorStyles.Bottom;
            btnNouvOrdo.Location = new Point(290, 473);
            btnNouvOrdo.Name = "btnNouvOrdo";
            btnNouvOrdo.Size = new Size(200, 41);
            btnNouvOrdo.TabIndex = 12;
            btnNouvOrdo.Text = "Nouvelle ordonnance";
            btnNouvOrdo.UseVisualStyleBackColor = true;
            btnNouvOrdo.Click += btnNouvOrdo_Click;
            // 
            // btnGestionOrdonnances
            // 
            btnGestionOrdonnances.Anchor = AnchorStyles.Bottom;
            btnGestionOrdonnances.Location = new Point(82, 475);
            btnGestionOrdonnances.Name = "btnGestionOrdonnances";
            btnGestionOrdonnances.Size = new Size(204, 36);
            btnGestionOrdonnances.TabIndex = 13;
            btnGestionOrdonnances.Text = "Gestion ordonnance";
            btnGestionOrdonnances.UseVisualStyleBackColor = true;
            btnGestionOrdonnances.Click += btnGestionOrdonnances_Click;
            // 
            // PatientListForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1068, 568);
            Controls.Add(btnGestionOrdonnances);
            Controls.Add(btnNouvOrdo);
            Controls.Add(btnSuppr);
            Controls.Add(btnDetail);
            Controls.Add(btnNouveauPatient);
            Controls.Add(btnReinitialiser);
            Controls.Add(lblAllergie);
            Controls.Add(cmbAllergies);
            Controls.Add(txtRecherche);
            Controls.Add(lblRecherche);
            Controls.Add(btnRechercher);
            Controls.Add(dgvPatients);
            Name = "PatientListForm";
            Text = "Liste des patients";
            Load += PatientListForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPatients;
        private Button btnRechercher;
        private Label lblRecherche;
        private TextBox txtRecherche;
        private ComboBox cmbAllergies;
        private Label lblAllergie;
        private Button btnReinitialiser;
        private Button btnNouveauPatient;
        private Button btnDetail;
        private Button btnSuppr;
        private Button btnNouvOrdo;
        private Button btnGestionOrdonnances;
    }
}