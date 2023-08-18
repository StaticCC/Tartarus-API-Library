namespace TartarusLib
{
    partial class Authenticate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authenticate));
            this.loginButton = new MaterialSkin.Controls.MaterialButton();
            this.loginUsername = new MaterialSkin.Controls.MaterialTextBox();
            this.loginPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.faqButton = new MaterialSkin.Controls.MaterialButton();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.login = new System.Windows.Forms.TabPage();
            this.register = new System.Windows.Forms.TabPage();
            this.registerUsername = new MaterialSkin.Controls.MaterialTextBox();
            this.registerButton = new MaterialSkin.Controls.MaterialButton();
            this.registerKey = new MaterialSkin.Controls.MaterialTextBox();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialTabControl1.SuspendLayout();
            this.login.SuspendLayout();
            this.register.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.loginButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.loginButton.Depth = 0;
            this.loginButton.HighEmphasis = true;
            this.loginButton.Icon = null;
            this.loginButton.Location = new System.Drawing.Point(296, 140);
            this.loginButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.loginButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.loginButton.Name = "loginButton";
            this.loginButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.loginButton.Size = new System.Drawing.Size(64, 36);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "Login";
            this.loginButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.loginButton.UseAccentColor = false;
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // loginUsername
            // 
            this.loginUsername.AnimateReadOnly = false;
            this.loginUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loginUsername.Depth = 0;
            this.loginUsername.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.loginUsername.Hint = "Username";
            this.loginUsername.LeadingIcon = null;
            this.loginUsername.Location = new System.Drawing.Point(6, 25);
            this.loginUsername.MaxLength = 14;
            this.loginUsername.MouseState = MaterialSkin.MouseState.OUT;
            this.loginUsername.Multiline = false;
            this.loginUsername.Name = "loginUsername";
            this.loginUsername.Size = new System.Drawing.Size(354, 50);
            this.loginUsername.TabIndex = 1;
            this.loginUsername.Text = "";
            this.loginUsername.TrailingIcon = null;
            // 
            // loginPassword
            // 
            this.loginPassword.AnimateReadOnly = false;
            this.loginPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loginPassword.Depth = 0;
            this.loginPassword.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.loginPassword.Hint = "Product Key";
            this.loginPassword.LeadingIcon = null;
            this.loginPassword.Location = new System.Drawing.Point(5, 81);
            this.loginPassword.MaxLength = 255;
            this.loginPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.loginPassword.Multiline = false;
            this.loginPassword.Name = "loginPassword";
            this.loginPassword.Size = new System.Drawing.Size(355, 50);
            this.loginPassword.TabIndex = 2;
            this.loginPassword.Text = "";
            this.loginPassword.TrailingIcon = null;
            this.loginPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.loginPassword_KeyPress);
            // 
            // faqButton
            // 
            this.faqButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.faqButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.faqButton.Depth = 0;
            this.faqButton.HighEmphasis = true;
            this.faqButton.Icon = null;
            this.faqButton.Location = new System.Drawing.Point(224, 140);
            this.faqButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.faqButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.faqButton.Name = "faqButton";
            this.faqButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.faqButton.Size = new System.Drawing.Size(64, 36);
            this.faqButton.TabIndex = 4;
            this.faqButton.Text = "?";
            this.faqButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.faqButton.UseAccentColor = false;
            this.faqButton.UseVisualStyleBackColor = true;
            this.faqButton.Click += new System.EventHandler(this.faqButton_Click);
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.login);
            this.materialTabControl1.Controls.Add(this.register);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(-1, 92);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(551, 241);
            this.materialTabControl1.TabIndex = 6;
            // 
            // login
            // 
            this.login.Controls.Add(this.loginUsername);
            this.login.Controls.Add(this.loginButton);
            this.login.Controls.Add(this.faqButton);
            this.login.Controls.Add(this.loginPassword);
            this.login.Location = new System.Drawing.Point(4, 22);
            this.login.Name = "login";
            this.login.Padding = new System.Windows.Forms.Padding(3);
            this.login.Size = new System.Drawing.Size(543, 215);
            this.login.TabIndex = 0;
            this.login.Text = "Login";
            this.login.UseVisualStyleBackColor = true;
            // 
            // register
            // 
            this.register.Controls.Add(this.registerUsername);
            this.register.Controls.Add(this.registerButton);
            this.register.Controls.Add(this.registerKey);
            this.register.Location = new System.Drawing.Point(4, 22);
            this.register.Name = "register";
            this.register.Padding = new System.Windows.Forms.Padding(3);
            this.register.Size = new System.Drawing.Size(543, 215);
            this.register.TabIndex = 1;
            this.register.Text = "Register";
            this.register.UseVisualStyleBackColor = true;
            // 
            // registerUsername
            // 
            this.registerUsername.AnimateReadOnly = false;
            this.registerUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.registerUsername.Depth = 0;
            this.registerUsername.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.registerUsername.Hint = "Username";
            this.registerUsername.LeadingIcon = null;
            this.registerUsername.Location = new System.Drawing.Point(6, 25);
            this.registerUsername.MaxLength = 14;
            this.registerUsername.MouseState = MaterialSkin.MouseState.OUT;
            this.registerUsername.Multiline = false;
            this.registerUsername.Name = "registerUsername";
            this.registerUsername.Size = new System.Drawing.Size(355, 50);
            this.registerUsername.TabIndex = 6;
            this.registerUsername.Text = "";
            this.registerUsername.TrailingIcon = null;
            // 
            // registerButton
            // 
            this.registerButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.registerButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.registerButton.Depth = 0;
            this.registerButton.HighEmphasis = true;
            this.registerButton.Icon = null;
            this.registerButton.Location = new System.Drawing.Point(272, 140);
            this.registerButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.registerButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.registerButton.Name = "registerButton";
            this.registerButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.registerButton.Size = new System.Drawing.Size(89, 36);
            this.registerButton.TabIndex = 5;
            this.registerButton.Text = "Register";
            this.registerButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.registerButton.UseAccentColor = false;
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // registerKey
            // 
            this.registerKey.AnimateReadOnly = false;
            this.registerKey.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.registerKey.Depth = 0;
            this.registerKey.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.registerKey.Hint = "Product Key";
            this.registerKey.LeadingIcon = null;
            this.registerKey.Location = new System.Drawing.Point(5, 81);
            this.registerKey.MaxLength = 255;
            this.registerKey.MouseState = MaterialSkin.MouseState.OUT;
            this.registerKey.Multiline = false;
            this.registerKey.Name = "registerKey";
            this.registerKey.Size = new System.Drawing.Size(356, 50);
            this.registerKey.TabIndex = 7;
            this.registerKey.Text = "";
            this.registerKey.TrailingIcon = null;
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.CharacterCasing = MaterialSkin.Controls.MaterialTabSelector.CustomCharacterCasing.Normal;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTabSelector1.Location = new System.Drawing.Point(-1, 60);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(440, 48);
            this.materialTabSelector1.TabIndex = 7;
            // 
            // Authenticate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 282);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.materialTabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Authenticate";
            this.Sizable = false;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Authenticate_FormClosing);
            this.materialTabControl1.ResumeLayout(false);
            this.login.ResumeLayout(false);
            this.login.PerformLayout();
            this.register.ResumeLayout(false);
            this.register.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton loginButton;
        private MaterialSkin.Controls.MaterialTextBox loginUsername;
        private MaterialSkin.Controls.MaterialTextBox loginPassword;
        private MaterialSkin.Controls.MaterialButton faqButton;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage login;
        private System.Windows.Forms.TabPage register;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialTextBox registerUsername;
        private MaterialSkin.Controls.MaterialButton registerButton;
        private MaterialSkin.Controls.MaterialTextBox registerKey;
    }
}

