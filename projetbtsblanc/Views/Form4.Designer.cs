namespace projetbtsblanc.Views
{
    partial class Form4
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
            txtNom = new TextBox();
            txtPrenom = new TextBox();
            label2 = new Label();
            DateNaissance = new DateTimePicker();
            label3 = new Label();
            numPoids = new NumericUpDown();
            label4 = new Label();
            Taille = new Label();
            numTaille = new NumericUpDown();
            comboBox1 = new ComboBox();
            cmbSexe = new Label();
            maskedTextBox1 = new MaskedTextBox();
            label7 = new Label();
            mtbSexu = new MaskedTextBox();
            txtPathologies = new RichTextBox();
            label8 = new Label();
            btnCreer = new Button();
            ((System.ComponentModel.ISupportInitialize)numPoids).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTaille).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(198, 24);
            label1.Name = "label1";
            label1.Size = new Size(52, 25);
            label1.TabIndex = 0;
            label1.Text = "Nom";
            // 
            // txtNom
            // 
            txtNom.Location = new Point(198, 52);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(150, 31);
            txtNom.TabIndex = 1;
            // 
            // txtPrenom
            // 
            txtPrenom.Location = new Point(448, 52);
            txtPrenom.Name = "txtPrenom";
            txtPrenom.Size = new Size(150, 31);
            txtPrenom.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(448, 24);
            label2.Name = "label2";
            label2.Size = new Size(74, 25);
            label2.TabIndex = 2;
            label2.Text = "Prénom";
            // 
            // DateNaissance
            // 
            DateNaissance.Location = new Point(120, 132);
            DateNaissance.Name = "DateNaissance";
            DateNaissance.Size = new Size(300, 31);
            DateNaissance.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(122, 104);
            label3.Name = "label3";
            label3.Size = new Size(154, 25);
            label3.TabIndex = 5;
            label3.Text = "Date de naissance";
            // 
            // numPoids
            // 
            numPoids.DecimalPlaces = 1;
            numPoids.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numPoids.Location = new Point(508, 136);
            numPoids.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            numPoids.Name = "numPoids";
            numPoids.Size = new Size(76, 31);
            numPoids.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(508, 106);
            label4.Name = "label4";
            label4.Size = new Size(55, 25);
            label4.TabIndex = 7;
            label4.Text = "Poids";
            // 
            // Taille
            // 
            Taille.AutoSize = true;
            Taille.Location = new Point(620, 106);
            Taille.Name = "Taille";
            Taille.Size = new Size(49, 25);
            Taille.TabIndex = 9;
            Taille.Text = "Taille";
            Taille.TextAlign = ContentAlignment.TopCenter;
            // 
            // numTaille
            // 
            numTaille.DecimalPlaces = 2;
            numTaille.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numTaille.Location = new Point(620, 136);
            numTaille.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numTaille.Name = "numTaille";
            numTaille.Size = new Size(76, 31);
            numTaille.TabIndex = 8;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(122, 224);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 33);
            comboBox1.TabIndex = 10;
            // 
            // cmbSexe
            // 
            cmbSexe.AutoSize = true;
            cmbSexe.Location = new Point(122, 196);
            cmbSexe.Name = "cmbSexe";
            cmbSexe.Size = new Size(48, 25);
            cmbSexe.TabIndex = 11;
            cmbSexe.Text = "Sexe";
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(-483, 260);
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(150, 31);
            maskedTextBox1.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(438, 196);
            label7.Name = "label7";
            label7.Size = new Size(225, 25);
            label7.TabIndex = 13;
            label7.Text = "Numéro de sécurité sociale";
            // 
            // mtbSexu
            // 
            mtbSexu.Location = new Point(438, 226);
            mtbSexu.Mask = "0 00 00 00 000 000 00";
            mtbSexu.Name = "mtbSexu";
            mtbSexu.Size = new Size(284, 31);
            mtbSexu.TabIndex = 14;
            // 
            // txtPathologies
            // 
            txtPathologies.Location = new Point(120, 307);
            txtPathologies.Name = "txtPathologies";
            txtPathologies.Size = new Size(640, 138);
            txtPathologies.TabIndex = 15;
            txtPathologies.Text = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(120, 279);
            label8.Name = "label8";
            label8.Size = new Size(104, 25);
            label8.TabIndex = 16;
            label8.Text = "Pathologies";
            // 
            // btnCreer
            // 
            btnCreer.Cursor = Cursors.Hand;
            btnCreer.FlatStyle = FlatStyle.Flat;
            btnCreer.Location = new Point(369, 451);
            btnCreer.Name = "btnCreer";
            btnCreer.Size = new Size(112, 34);
            btnCreer.TabIndex = 17;
            btnCreer.Text = "Créer";
            btnCreer.UseVisualStyleBackColor = true;
            btnCreer.Click += btnCreer_Click;
            // 
            // Form4
            // 
            AcceptButton = btnCreer;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 510);
            Controls.Add(btnCreer);
            Controls.Add(label8);
            Controls.Add(txtPathologies);
            Controls.Add(mtbSexu);
            Controls.Add(label7);
            Controls.Add(maskedTextBox1);
            Controls.Add(cmbSexe);
            Controls.Add(comboBox1);
            Controls.Add(Taille);
            Controls.Add(numTaille);
            Controls.Add(label4);
            Controls.Add(numPoids);
            Controls.Add(label3);
            Controls.Add(DateNaissance);
            Controls.Add(txtPrenom);
            Controls.Add(label2);
            Controls.Add(txtNom);
            Controls.Add(label1);
            Name = "Form4";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Form4";
            ((System.ComponentModel.ISupportInitialize)numPoids).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTaille).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNom;
        private TextBox txtPrenom;
        private Label label2;
        private DateTimePicker DateNaissance;
        private Label label3;
        private NumericUpDown numPoids;
        private Label label4;
        private Label Taille;
        private NumericUpDown numTaille;
        private ComboBox comboBox1;
        private Label cmbSexe;
        private MaskedTextBox maskedTextBox1;
        private Label label7;
        private MaskedTextBox mtbSexu;
        private RichTextBox txtPathologies;
        private Label label8;
        private Button btnCreer;
    }
}