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
            btnReset = new Button();
            cmbAllergies = new ComboBox();
            lblAllergie = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            SuspendLayout();
            // 
            // dgvPatients
            // 
            dgvPatients.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatients.Location = new Point(98, 161);
            dgvPatients.Name = "dgvPatients";
            dgvPatients.RowHeadersWidth = 62;
            dgvPatients.Size = new Size(658, 246);
            dgvPatients.TabIndex = 0;
            dgvPatients.CellDoubleClick += dgvPatients_CellDoubleClick;
            // 
            // btnRechercher
            // 
            btnRechercher.Location = new Point(610, 112);
            btnRechercher.Name = "btnRechercher";
            btnRechercher.Size = new Size(112, 34);
            btnRechercher.TabIndex = 1;
            btnRechercher.Text = "OK";
            btnRechercher.UseVisualStyleBackColor = true;
            btnRechercher.Click += btnRechercher_Click_1;
            // 
            // lblRecherche
            // 
            lblRecherche.AutoSize = true;
            lblRecherche.Location = new Point(108, 24);
            lblRecherche.Name = "lblRecherche";
            lblRecherche.Size = new Size(182, 25);
            lblRecherche.TabIndex = 3;
            lblRecherche.Text = "Rechercher un patient";
            // 
            // txtRecherche
            // 
            txtRecherche.Location = new Point(108, 52);
            txtRecherche.Name = "txtRecherche";
            txtRecherche.Size = new Size(186, 31);
            txtRecherche.TabIndex = 4;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(585, 433);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(171, 34);
            btnReset.TabIndex = 5;
            btnReset.Text = "Tout afficher";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // cmbAllergies
            // 
            cmbAllergies.FormattingEnabled = true;
            cmbAllergies.Location = new Point(112, 100);
            cmbAllergies.Name = "cmbAllergies";
            cmbAllergies.Size = new Size(182, 33);
            cmbAllergies.TabIndex = 6;
            // 
            // lblAllergie
            // 
            lblAllergie.AutoSize = true;
            lblAllergie.Location = new Point(21, 103);
            lblAllergie.Name = "lblAllergie";
            lblAllergie.Size = new Size(85, 25);
            lblAllergie.TabIndex = 7;
            lblAllergie.Text = "Allergie : ";
            // 
            // PatientListForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(925, 479);
            Controls.Add(lblAllergie);
            Controls.Add(cmbAllergies);
            Controls.Add(btnReset);
            Controls.Add(txtRecherche);
            Controls.Add(lblRecherche);
            Controls.Add(btnRechercher);
            Controls.Add(dgvPatients);
            Name = "PatientListForm";
            Text = "PatientListForm";
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
        private Button btnReset;
        private ComboBox cmbAllergies;
        private Label lblAllergie;
    }
}