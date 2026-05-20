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
            label1 = new Label();
            txtRecherche = new TextBox();
            btnReset = new Button();
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
            btnRechercher.Location = new Point(445, 84);
            btnRechercher.Name = "btnRechercher";
            btnRechercher.Size = new Size(112, 34);
            btnRechercher.TabIndex = 1;
            btnRechercher.Text = "OK";
            btnRechercher.UseVisualStyleBackColor = true;
            btnRechercher.Click += btnRechercher_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(111, 56);
            label1.Name = "label1";
            label1.Size = new Size(97, 25);
            label1.TabIndex = 3;
            label1.Text = "Rechercher";
            // 
            // txtRecherche
            // 
            txtRecherche.Location = new Point(111, 84);
            txtRecherche.Name = "txtRecherche";
            txtRecherche.Size = new Size(150, 31);
            txtRecherche.TabIndex = 4;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(575, 84);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(171, 34);
            btnReset.TabIndex = 5;
            btnReset.Text = "Tout afficher";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // PatientListForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(925, 479);
            Controls.Add(btnReset);
            Controls.Add(txtRecherche);
            Controls.Add(label1);
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
        private Label label1;
        private TextBox txtRecherche;
        private Button btnReset;
    }
}