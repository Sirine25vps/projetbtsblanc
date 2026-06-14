namespace projetbtsblanc.Views
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblIdentifiant = new Label();
            label2 = new Label();
            btnConnexion = new Button();
            txtEmail = new TextBox();
            txtMdp = new TextBox();
            SuspendLayout();
            // 
            // lblIdentifiant
            // 
            lblIdentifiant.AutoSize = true;
            lblIdentifiant.BackColor = Color.Transparent;
            lblIdentifiant.Location = new Point(268, 94);
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
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(673, 422);
            Controls.Add(txtMdp);
            Controls.Add(txtEmail);
            Controls.Add(btnConnexion);
            Controls.Add(label2);
            Controls.Add(lblIdentifiant);
            Name = "LoginForm";
            Text = "Connexion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIdentifiant;
        private Label label2;
        private Button btnConnexion;
        private TextBox txtEmail;
        private TextBox txtMdp;
    }
}