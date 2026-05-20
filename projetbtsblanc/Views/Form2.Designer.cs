namespace projetbtsblanc.Views
{
    partial class Form2
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
            txtNom = new TextBox();
            textenom = new Label();
            texterpps = new Label();
            txtRPPS = new TextBox();
            textemdp = new Label();
            txtMdp = new TextBox();
            textepr = new Label();
            txtPrenom = new TextBox();
            txtmail = new Label();
            txtEmail = new TextBox();
            texteConfirmation = new Label();
            txtConfirmation = new TextBox();
            btnInscription = new Button();
            linkConnexion = new LinkLabel();
            SuspendLayout();
            // 
            // txtNom
            // 
            txtNom.Location = new Point(142, 93);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(150, 31);
            txtNom.TabIndex = 0;
            // 
            // textenom
            // 
            textenom.AutoSize = true;
            textenom.Location = new Point(143, 62);
            textenom.Name = "textenom";
            textenom.Size = new Size(52, 25);
            textenom.TabIndex = 1;
            textenom.Text = "Nom";
            // 
            // texterpps
            // 
            texterpps.AutoSize = true;
            texterpps.Location = new Point(144, 151);
            texterpps.Name = "texterpps";
            texterpps.Size = new Size(123, 25);
            texterpps.TabIndex = 3;
            texterpps.Text = "Numéro RPPS";
            // 
            // txtRPPS
            // 
            txtRPPS.Location = new Point(143, 182);
            txtRPPS.Name = "txtRPPS";
            txtRPPS.Size = new Size(150, 31);
            txtRPPS.TabIndex = 2;
            // 
            // textemdp
            // 
            textemdp.AutoSize = true;
            textemdp.Location = new Point(145, 243);
            textemdp.Name = "textemdp";
            textemdp.Size = new Size(120, 25);
            textemdp.TabIndex = 5;
            textemdp.Text = "Mot de passe";
            // 
            // txtMdp
            // 
            txtMdp.Location = new Point(144, 274);
            txtMdp.Name = "txtMdp";
            txtMdp.Size = new Size(150, 31);
            txtMdp.TabIndex = 4;
            txtMdp.UseSystemPasswordChar = true;
            // 
            // textepr
            // 
            textepr.AutoSize = true;
            textepr.Location = new Point(418, 62);
            textepr.Name = "textepr";
            textepr.Size = new Size(74, 25);
            textepr.TabIndex = 7;
            textepr.Text = "Prénom";
            // 
            // txtPrenom
            // 
            txtPrenom.Location = new Point(417, 93);
            txtPrenom.Name = "txtPrenom";
            txtPrenom.Size = new Size(150, 31);
            txtPrenom.TabIndex = 6;
            // 
            // txtmail
            // 
            txtmail.AutoSize = true;
            txtmail.Location = new Point(418, 161);
            txtmail.Name = "txtmail";
            txtmail.Size = new Size(54, 25);
            txtmail.TabIndex = 9;
            txtmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(417, 192);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(150, 31);
            txtEmail.TabIndex = 8;
            // 
            // texteConfirmation
            // 
            texteConfirmation.AutoSize = true;
            texteConfirmation.Location = new Point(418, 243);
            texteConfirmation.Name = "texteConfirmation";
            texteConfirmation.Size = new Size(229, 25);
            texteConfirmation.TabIndex = 11;
            texteConfirmation.Text = "Confirmation mot de passe";
            // 
            // txtConfirmation
            // 
            txtConfirmation.Location = new Point(418, 274);
            txtConfirmation.Name = "txtConfirmation";
            txtConfirmation.Size = new Size(150, 31);
            txtConfirmation.TabIndex = 10;
            txtConfirmation.UseSystemPasswordChar = true;
            // 
            // btnInscription
            // 
            btnInscription.Location = new Point(302, 335);
            btnInscription.Name = "btnInscription";
            btnInscription.Size = new Size(112, 34);
            btnInscription.TabIndex = 12;
            btnInscription.Text = "Inscription";
            btnInscription.UseVisualStyleBackColor = true;
            btnInscription.Click += btnInscription_Click;
            // 
            // linkConnexion
            // 
            linkConnexion.AutoSize = true;
            linkConnexion.Location = new Point(312, 389);
            linkConnexion.Name = "linkConnexion";
            linkConnexion.Size = new Size(96, 25);
            linkConnexion.TabIndex = 13;
            linkConnexion.TabStop = true;
            linkConnexion.Text = "Connexion";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(linkConnexion);
            Controls.Add(btnInscription);
            Controls.Add(texteConfirmation);
            Controls.Add(txtConfirmation);
            Controls.Add(txtmail);
            Controls.Add(txtEmail);
            Controls.Add(textepr);
            Controls.Add(txtPrenom);
            Controls.Add(textemdp);
            Controls.Add(txtMdp);
            Controls.Add(texterpps);
            Controls.Add(txtRPPS);
            Controls.Add(textenom);
            Controls.Add(txtNom);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNom;
        private Label textenom;
        private Label texterpps;
        private TextBox txtRPPS;
        private Label textemdp;
        private TextBox txtMdp;
        private Label textepr;
        private TextBox txtPrenom;
        private Label txtmail;
        private TextBox txtEmail;
        private Label texteConfirmation;
        private TextBox txtConfirmation;
        private Button btnInscription;
        private LinkLabel linkConnexion;
    }
}