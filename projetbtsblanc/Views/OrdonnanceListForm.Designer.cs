namespace projetbtsblanc.Views
{
    partial class OrdonnanceListForm
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
            dgvOrdonnances = new DataGridView();
            dgvLignes = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOrdonnances).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLignes).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 62);
            label1.Name = "label1";
            label1.Size = new Size(132, 25);
            label1.TabIndex = 0;
            label1.Text = "Ordonnances : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(63, 276);
            label2.Name = "label2";
            label2.Size = new Size(195, 25);
            label2.TabIndex = 1;
            label2.Text = "Lignes de prescription :";
            // 
            // dgvOrdonnances
            // 
            dgvOrdonnances.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvOrdonnances.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrdonnances.Location = new Point(68, 90);
            dgvOrdonnances.Name = "dgvOrdonnances";
            dgvOrdonnances.ReadOnly = true;
            dgvOrdonnances.RowHeadersWidth = 62;
            dgvOrdonnances.Size = new Size(604, 161);
            dgvOrdonnances.TabIndex = 2;
            // 
            // dgvLignes
            // 
            dgvLignes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvLignes.CausesValidation = false;
            dgvLignes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLignes.Location = new Point(68, 304);
            dgvLignes.Name = "dgvLignes";
            dgvLignes.ReadOnly = true;
            dgvLignes.RowHeadersWidth = 62;
            dgvLignes.Size = new Size(604, 161);
            dgvLignes.TabIndex = 3;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(604, 500);
            button1.Name = "button1";
            button1.Size = new Size(128, 31);
            button1.TabIndex = 4;
            button1.Text = "Fermer";
            button1.UseVisualStyleBackColor = true;
    
            // 
            // OrdonnanceListForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(768, 563);
            Controls.Add(button1);
            Controls.Add(dgvLignes);
            Controls.Add(dgvOrdonnances);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "OrdonnanceListForm";
            Text = "Ordonnance du patient ";
            ((System.ComponentModel.ISupportInitialize)dgvOrdonnances).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLignes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DataGridView dgvOrdonnances;
        private DataGridView dgvLignes;
        private Button button1;
    }
}