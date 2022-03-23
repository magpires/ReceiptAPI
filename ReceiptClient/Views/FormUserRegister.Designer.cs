namespace ReceiptClient.Views
{
    partial class FormUserRegister
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
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelRegister = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelHaveAccount = new System.Windows.Forms.Label();
            this.linkLabelLogin = new System.Windows.Forms.LinkLabel();
            this.labelNameError = new System.Windows.Forms.Label();
            this.labelPasswordError = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelConfirmPasswordError = new System.Windows.Forms.Label();
            this.labelConfirmPassword = new System.Windows.Forms.Label();
            this.textBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.labelEmailError = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.AccessibleDescription = "Senha";
            this.textBoxPassword.Location = new System.Drawing.Point(53, 244);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxPassword.MaxLength = 255;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(258, 27);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // buttonRegister
            // 
            this.buttonRegister.Enabled = false;
            this.buttonRegister.Location = new System.Drawing.Point(280, 368);
            this.buttonRegister.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(86, 31);
            this.buttonRegister.TabIndex = 4;
            this.buttonRegister.Text = "Registrar-se";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.AccessibleDescription = "Email";
            this.textBoxName.Location = new System.Drawing.Point(53, 156);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxName.MaxLength = 100;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(258, 27);
            this.textBoxName.TabIndex = 2;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // labelRegister
            // 
            this.labelRegister.AutoSize = true;
            this.labelRegister.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRegister.Location = new System.Drawing.Point(126, 53);
            this.labelRegister.Name = "labelRegister";
            this.labelRegister.Size = new System.Drawing.Size(422, 35);
            this.labelRegister.TabIndex = 6;
            this.labelRegister.Text = "Informe os dados de sua nova conta";
            this.labelRegister.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.labelRegister.Click += new System.EventHandler(this.labelLogin_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(53, 132);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(50, 20);
            this.labelName.TabIndex = 7;
            this.labelName.Text = "Nome";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(53, 220);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(49, 20);
            this.labelPassword.TabIndex = 8;
            this.labelPassword.Text = "Senha";
            // 
            // labelHaveAccount
            // 
            this.labelHaveAccount.AutoSize = true;
            this.labelHaveAccount.Location = new System.Drawing.Point(233, 443);
            this.labelHaveAccount.Name = "labelHaveAccount";
            this.labelHaveAccount.Size = new System.Drawing.Size(133, 20);
            this.labelHaveAccount.TabIndex = 9;
            this.labelHaveAccount.Text = "Já tem uma conta?";
            // 
            // linkLabelLogin
            // 
            this.linkLabelLogin.AutoSize = true;
            this.linkLabelLogin.LinkColor = System.Drawing.SystemColors.MenuHighlight;
            this.linkLabelLogin.Location = new System.Drawing.Point(362, 443);
            this.linkLabelLogin.Name = "linkLabelLogin";
            this.linkLabelLogin.Size = new System.Drawing.Size(76, 20);
            this.linkLabelLogin.TabIndex = 10;
            this.linkLabelLogin.TabStop = true;
            this.linkLabelLogin.Text = "Faça login";
            this.linkLabelLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLogin_LinkClicked);
            // 
            // labelNameError
            // 
            this.labelNameError.AutoSize = true;
            this.labelNameError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelNameError.ForeColor = System.Drawing.Color.Red;
            this.labelNameError.Location = new System.Drawing.Point(53, 187);
            this.labelNameError.Name = "labelNameError";
            this.labelNameError.Size = new System.Drawing.Size(86, 20);
            this.labelNameError.TabIndex = 11;
            this.labelNameError.Text = "NameError";
            // 
            // labelPasswordError
            // 
            this.labelPasswordError.AutoSize = true;
            this.labelPasswordError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPasswordError.ForeColor = System.Drawing.Color.Red;
            this.labelPasswordError.Location = new System.Drawing.Point(53, 275);
            this.labelPasswordError.MaximumSize = new System.Drawing.Size(255, 0);
            this.labelPasswordError.Name = "labelPasswordError";
            this.labelPasswordError.Size = new System.Drawing.Size(244, 40);
            this.labelPasswordError.TabIndex = 12;
            this.labelPasswordError.Text = "PasswordErrorPasswordErrorPasswordErrorPasswordError";
            this.labelPasswordError.Click += new System.EventHandler(this.labelPasswordError_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelConfirmPasswordError);
            this.panel1.Controls.Add(this.labelConfirmPassword);
            this.panel1.Controls.Add(this.textBoxConfirmPassword);
            this.panel1.Controls.Add(this.labelEmailError);
            this.panel1.Controls.Add(this.labelEmail);
            this.panel1.Controls.Add(this.textBoxEmail);
            this.panel1.Controls.Add(this.labelPasswordError);
            this.panel1.Controls.Add(this.labelNameError);
            this.panel1.Controls.Add(this.linkLabelLogin);
            this.panel1.Controls.Add(this.labelHaveAccount);
            this.panel1.Controls.Add(this.labelPassword);
            this.panel1.Controls.Add(this.labelName);
            this.panel1.Controls.Add(this.labelRegister);
            this.panel1.Controls.Add(this.textBoxName);
            this.panel1.Controls.Add(this.buttonRegister);
            this.panel1.Controls.Add(this.textBoxPassword);
            this.panel1.Location = new System.Drawing.Point(14, 16);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(685, 478);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // labelConfirmPasswordError
            // 
            this.labelConfirmPasswordError.AutoSize = true;
            this.labelConfirmPasswordError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelConfirmPasswordError.ForeColor = System.Drawing.Color.Red;
            this.labelConfirmPasswordError.Location = new System.Drawing.Point(342, 275);
            this.labelConfirmPasswordError.Name = "labelConfirmPasswordError";
            this.labelConfirmPasswordError.Size = new System.Drawing.Size(166, 20);
            this.labelConfirmPasswordError.TabIndex = 18;
            this.labelConfirmPasswordError.Text = "confirmPasswordError";
            // 
            // labelConfirmPassword
            // 
            this.labelConfirmPassword.AutoSize = true;
            this.labelConfirmPassword.Location = new System.Drawing.Point(342, 220);
            this.labelConfirmPassword.Name = "labelConfirmPassword";
            this.labelConfirmPassword.Size = new System.Drawing.Size(119, 20);
            this.labelConfirmPassword.TabIndex = 17;
            this.labelConfirmPassword.Text = "Confirmar Senha";
            // 
            // textBoxConfirmPassword
            // 
            this.textBoxConfirmPassword.AccessibleDescription = "Senha";
            this.textBoxConfirmPassword.Location = new System.Drawing.Point(342, 244);
            this.textBoxConfirmPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxConfirmPassword.MaxLength = 255;
            this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            this.textBoxConfirmPassword.PasswordChar = '*';
            this.textBoxConfirmPassword.Size = new System.Drawing.Size(258, 27);
            this.textBoxConfirmPassword.TabIndex = 16;
            this.textBoxConfirmPassword.TextChanged += new System.EventHandler(this.textBoxConfirmPassword_TextChanged);
            // 
            // labelEmailError
            // 
            this.labelEmailError.AutoSize = true;
            this.labelEmailError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelEmailError.ForeColor = System.Drawing.Color.Red;
            this.labelEmailError.Location = new System.Drawing.Point(342, 187);
            this.labelEmailError.Name = "labelEmailError";
            this.labelEmailError.Size = new System.Drawing.Size(82, 20);
            this.labelEmailError.TabIndex = 15;
            this.labelEmailError.Text = "EmailError";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(342, 132);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(46, 20);
            this.labelEmail.TabIndex = 14;
            this.labelEmail.Text = "Email";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.AccessibleDescription = "Email";
            this.textBoxEmail.Location = new System.Drawing.Point(342, 156);
            this.textBoxEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxEmail.MaxLength = 100;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(258, 27);
            this.textBoxEmail.TabIndex = 13;
            this.textBoxEmail.TextChanged += new System.EventHandler(this.textBoxEmail_TextChanged);
            // 
            // FormUserRegister
            // 
            this.AcceptButton = this.buttonRegister;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(713, 511);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FormUserRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Receipt - Register";
            this.Load += new System.EventHandler(this.FormUserRegister_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelRegister;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelHaveAccount;
        private System.Windows.Forms.LinkLabel linkLabelLogin;
        private System.Windows.Forms.Label labelNameError;
        private System.Windows.Forms.Label labelPasswordError;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelConfirmPasswordError;
        private System.Windows.Forms.Label labelConfirmPassword;
        private System.Windows.Forms.TextBox textBoxConfirmPassword;
        private System.Windows.Forms.Label labelEmailError;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private bool _closedFromMyButton;
    }
}