namespace projetbtsblanc.Views
{
    partial class Form1
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
            lblIdentifiant = new Label();
            label2 = new Label();
            lblInscription = new LinkLabel();
            btnConnexion = new Button();
            txtEmail = new TextBox();
            txtMdp = new TextBox();
            SuspendLayout();
            // 
            // lblIdentifiant
            // 
            lblIdentifiant.AutoSize = true;
            lblIdentifiant.BackColor = SystemColors.ButtonHighlight;
            lblIdentifiant.Location = new Point(270, 94);
            lblIdentifiant.Name = "lblIdentifiant";
            lblIdentifiant.Size = new Size(122, 25);
            lblIdentifiant.TabIndex = 0;
            lblIdentifiant.Text = "Adresse email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(270, 185);
            label2.Name = "label2";
            label2.Size = new Size(120, 25);
            label2.TabIndex = 1;
            label2.Text = "Mot de passe";
            // 
            // lblInscription
            // 
            lblInscription.AutoSize = true;
            lblInscription.Location = new Point(290, 346);
            lblInscription.Name = "lblInscription";
            lblInscription.Size = new Size(95, 25);
            lblInscription.TabIndex = 2;
            lblInscription.TabStop = true;
            lblInscription.Text = "Inscription";
            lblInscription.LinkClicked += lblInscription_LinkClicked;
            // 
            // btnConnexion
            // 
            btnConnexion.Location = new Point(278, 299);
            btnConnexion.Name = "btnConnexion";
            btnConnexion.Size = new Size(112, 34);
            btnConnexion.TabIndex = 3;
            btnConnexion.Text = "Connexion";
            btnConnexion.UseVisualStyleBackColor = true;
            btnConnexion.Click += btnConnexion_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(254, 122);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(150, 31);
            txtEmail.TabIndex = 4;
            // 
            // txtMdp
            // 
            txtMdp.Location = new Point(254, 213);
            txtMdp.Name = "txtMdp";
            txtMdp.Size = new Size(150, 31);
            txtMdp.TabIndex = 5;
            txtMdp.UseSystemPasswordChar = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtMdp);
            Controls.Add(txtEmail);
            Controls.Add(btnConnexion);
            Controls.Add(lblInscription);
            Controls.Add(label2);
            Controls.Add(lblIdentifiant);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIdentifiant;
        private Label label2;
        private LinkLabel lblInscription;
        private Button btnConnexion;
        private TextBox txtEmail;
        private TextBox txtMdp;
    }
}