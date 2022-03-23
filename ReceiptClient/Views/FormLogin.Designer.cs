namespace ReceiptClient.Views
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelPasswordError = new System.Windows.Forms.Label();
            this.labelEmailError = new System.Windows.Forms.Label();
            this.linkLabelRegister = new System.Windows.Forms.LinkLabel();
            this.labelNoAccount = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 45F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTitle.Location = new System.Drawing.Point(121, 40);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(229, 81);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Receipt";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.labelTitle.Click += new System.EventHandler(this.labelTitle_Click);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(298, 128);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(28, 15);
            this.labelVersion.TabIndex = 1;
            this.labelVersion.Text = "v1.0";
            this.labelVersion.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.AccessibleDescription = "Email";
            this.textBoxEmail.Location = new System.Drawing.Point(81, 101);
            this.textBoxEmail.MaxLength = 100;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(226, 23);
            this.textBoxEmail.TabIndex = 2;
            this.textBoxEmail.TextChanged += new System.EventHandler(this.textBoxEmail_TextChanged);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.AccessibleDescription = "Senha";
            this.textBoxPassword.Location = new System.Drawing.Point(81, 167);
            this.textBoxPassword.MaxLength = 255;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(226, 23);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Enabled = false;
            this.buttonLogin.Location = new System.Drawing.Point(151, 224);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 4;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_ClickAsync);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelPasswordError);
            this.panel1.Controls.Add(this.labelEmailError);
            this.panel1.Controls.Add(this.linkLabelRegister);
            this.panel1.Controls.Add(this.labelNoAccount);
            this.panel1.Controls.Add(this.labelPassword);
            this.panel1.Controls.Add(this.labelEmail);
            this.panel1.Controls.Add(this.labelLogin);
            this.panel1.Controls.Add(this.textBoxEmail);
            this.panel1.Controls.Add(this.buttonLogin);
            this.panel1.Controls.Add(this.textBoxPassword);
            this.panel1.Location = new System.Drawing.Point(44, 160);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 296);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // labelPasswordError
            // 
            this.labelPasswordError.AutoSize = true;
            this.labelPasswordError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPasswordError.ForeColor = System.Drawing.Color.Red;
            this.labelPasswordError.Location = new System.Drawing.Point(81, 190);
            this.labelPasswordError.Name = "labelPasswordError";
            this.labelPasswordError.Size = new System.Drawing.Size(87, 15);
            this.labelPasswordError.TabIndex = 12;
            this.labelPasswordError.Text = "PasswordError";
            this.labelPasswordError.Click += new System.EventHandler(this.label1_Click_3);
            // 
            // labelEmailError
            // 
            this.labelEmailError.AutoSize = true;
            this.labelEmailError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelEmailError.ForeColor = System.Drawing.Color.Red;
            this.labelEmailError.Location = new System.Drawing.Point(81, 124);
            this.labelEmailError.Name = "labelEmailError";
            this.labelEmailError.Size = new System.Drawing.Size(64, 15);
            this.labelEmailError.TabIndex = 11;
            this.labelEmailError.Text = "EmailError";
            this.labelEmailError.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // linkLabelRegister
            // 
            this.linkLabelRegister.AutoSize = true;
            this.linkLabelRegister.LinkColor = System.Drawing.SystemColors.MenuHighlight;
            this.linkLabelRegister.Location = new System.Drawing.Point(217, 263);
            this.linkLabelRegister.Name = "linkLabelRegister";
            this.linkLabelRegister.Size = new System.Drawing.Size(65, 15);
            this.linkLabelRegister.TabIndex = 10;
            this.linkLabelRegister.TabStop = true;
            this.linkLabelRegister.Text = "Registre-se";
            this.linkLabelRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // labelNoAccount
            // 
            this.labelNoAccount.AutoSize = true;
            this.labelNoAccount.Location = new System.Drawing.Point(104, 263);
            this.labelNoAccount.Name = "labelNoAccount";
            this.labelNoAccount.Size = new System.Drawing.Size(118, 15);
            this.labelNoAccount.TabIndex = 9;
            this.labelNoAccount.Text = "Não tem uma conta?";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(81, 149);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(39, 15);
            this.labelPassword.TabIndex = 8;
            this.labelPassword.Text = "Senha";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(81, 83);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(36, 15);
            this.labelEmail.TabIndex = 7;
            this.labelEmail.Text = "Email";
            this.labelEmail.Click += new System.EventHandler(this.labelEmail_Click);
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelLogin.Location = new System.Drawing.Point(73, 32);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(243, 28);
            this.labelLogin.TabIndex = 6;
            this.labelLogin.Text = "Entre com suas credenciais";
            this.labelLogin.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.labelLogin.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // FormRegister
            // 
            this.AcceptButton = this.buttonLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(486, 501);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receipt - Login";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.LinkLabel linkLabelRegister;
        private System.Windows.Forms.Label labelNoAccount;
        private System.Windows.Forms.Label labelEmailError;
        private System.Windows.Forms.Label labelPasswordError;
    }
}
