namespace Payroll_System
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            linkLabel1 = new LinkLabel();
            HidePasswordIcon = new PictureBox();
            ShowPasswordIcon = new PictureBox();
            PasswordPlaceHolderLabel = new Label();
            UsernamePlaceHolderLabel = new Label();
            passwordIconBox = new PictureBox();
            userIconBox = new PictureBox();
            ExitButton = new Button();
            PasswordTextBox = new TextBox();
            UsernameTextBox = new TextBox();
            ClearButton = new Button();
            LoginButton = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)HidePasswordIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ShowPasswordIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)passwordIconBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userIconBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = SystemColors.InactiveCaption;
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Impact", 10F, FontStyle.Regular, GraphicsUnit.Point);
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(56, 238);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(109, 18);
            linkLabel1.TabIndex = 28;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Forgot Password?";
            linkLabel1.VisitedLinkColor = SystemColors.ActiveCaption;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // HidePasswordIcon
            // 
            HidePasswordIcon.BackColor = SystemColors.Window;
            HidePasswordIcon.Image = (Image)resources.GetObject("HidePasswordIcon.Image");
            HidePasswordIcon.Location = new Point(390, 205);
            HidePasswordIcon.Name = "HidePasswordIcon";
            HidePasswordIcon.Size = new Size(25, 25);
            HidePasswordIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            HidePasswordIcon.TabIndex = 27;
            HidePasswordIcon.TabStop = false;
            HidePasswordIcon.Click += HidePasswordIcon_Click;
            // 
            // ShowPasswordIcon
            // 
            ShowPasswordIcon.BackColor = SystemColors.Window;
            ShowPasswordIcon.Image = (Image)resources.GetObject("ShowPasswordIcon.Image");
            ShowPasswordIcon.Location = new Point(390, 205);
            ShowPasswordIcon.Name = "ShowPasswordIcon";
            ShowPasswordIcon.Size = new Size(25, 25);
            ShowPasswordIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            ShowPasswordIcon.TabIndex = 26;
            ShowPasswordIcon.TabStop = false;
            ShowPasswordIcon.Visible = false;
            ShowPasswordIcon.Click += ShowPasswordIcon_Click;
            // 
            // PasswordPlaceHolderLabel
            // 
            PasswordPlaceHolderLabel.AutoSize = true;
            PasswordPlaceHolderLabel.BackColor = Color.White;
            PasswordPlaceHolderLabel.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            PasswordPlaceHolderLabel.ForeColor = SystemColors.ActiveBorder;
            PasswordPlaceHolderLabel.Location = new Point(63, 201);
            PasswordPlaceHolderLabel.Name = "PasswordPlaceHolderLabel";
            PasswordPlaceHolderLabel.Size = new Size(107, 29);
            PasswordPlaceHolderLabel.TabIndex = 25;
            PasswordPlaceHolderLabel.Text = "Password";
            PasswordPlaceHolderLabel.Click += PasswordPlaceHolderLabel_Click;
            // 
            // UsernamePlaceHolderLabel
            // 
            UsernamePlaceHolderLabel.AutoSize = true;
            UsernamePlaceHolderLabel.BackColor = SystemColors.Window;
            UsernamePlaceHolderLabel.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            UsernamePlaceHolderLabel.ForeColor = SystemColors.ActiveBorder;
            UsernamePlaceHolderLabel.Location = new Point(63, 137);
            UsernamePlaceHolderLabel.Margin = new Padding(0);
            UsernamePlaceHolderLabel.Name = "UsernamePlaceHolderLabel";
            UsernamePlaceHolderLabel.Size = new Size(114, 29);
            UsernamePlaceHolderLabel.TabIndex = 24;
            UsernamePlaceHolderLabel.Text = "Username";
            UsernamePlaceHolderLabel.Click += UsernamePlaceHolderLabel_Click;
            // 
            // passwordIconBox
            // 
            passwordIconBox.Image = Properties.Resources.passwordIcon;
            passwordIconBox.Location = new Point(12, 199);
            passwordIconBox.Name = "passwordIconBox";
            passwordIconBox.Size = new Size(36, 36);
            passwordIconBox.SizeMode = PictureBoxSizeMode.StretchImage;
            passwordIconBox.TabIndex = 23;
            passwordIconBox.TabStop = false;
            // 
            // userIconBox
            // 
            userIconBox.Image = Properties.Resources.userIcon;
            userIconBox.Location = new Point(12, 134);
            userIconBox.Name = "userIconBox";
            userIconBox.Size = new Size(36, 36);
            userIconBox.SizeMode = PictureBoxSizeMode.StretchImage;
            userIconBox.TabIndex = 22;
            userIconBox.TabStop = false;
            // 
            // ExitButton
            // 
            ExitButton.Image = Properties.Resources.Exit;
            ExitButton.ImageAlign = ContentAlignment.MiddleLeft;
            ExitButton.Location = new Point(223, 336);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(202, 52);
            ExitButton.TabIndex = 4;
            ExitButton.Text = "EXIT";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(56, 198);
            PasswordTextBox.MaxLength = 16;
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(369, 37);
            PasswordTextBox.TabIndex = 1;
            PasswordTextBox.UseSystemPasswordChar = true;
            PasswordTextBox.Enter += PasswordTextBox_Enter;
            PasswordTextBox.KeyDown += LoginButton_KeyDown;
            PasswordTextBox.Leave += PasswordTextBox_Leave;
            // 
            // UsernameTextBox
            // 
            UsernameTextBox.Location = new Point(56, 134);
            UsernameTextBox.Name = "UsernameTextBox";
            UsernameTextBox.Size = new Size(369, 37);
            UsernameTextBox.TabIndex = 0;
            UsernameTextBox.Enter += UsernameTextBox_Enter;
            UsernameTextBox.Leave += UsernameTextBox_Leave;
            // 
            // ClearButton
            // 
            ClearButton.Image = Properties.Resources.clear;
            ClearButton.ImageAlign = ContentAlignment.MiddleLeft;
            ClearButton.Location = new Point(12, 336);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(202, 52);
            ClearButton.TabIndex = 3;
            ClearButton.Text = "CLEAR";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // LoginButton
            // 
            LoginButton.BackgroundImageLayout = ImageLayout.None;
            LoginButton.Image = Properties.Resources.login;
            LoginButton.ImageAlign = ContentAlignment.MiddleLeft;
            LoginButton.Location = new Point(12, 264);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(413, 52);
            LoginButton.TabIndex = 2;
            LoginButton.Text = "LOGIN";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Payroll_System;
            pictureBox1.Location = new Point(129, -24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(172, 186);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 29;
            pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(99, 110, 114);
            ClientSize = new Size(442, 400);
            Controls.Add(linkLabel1);
            Controls.Add(HidePasswordIcon);
            Controls.Add(ShowPasswordIcon);
            Controls.Add(PasswordPlaceHolderLabel);
            Controls.Add(UsernamePlaceHolderLabel);
            Controls.Add(passwordIconBox);
            Controls.Add(userIconBox);
            Controls.Add(ExitButton);
            Controls.Add(PasswordTextBox);
            Controls.Add(UsernameTextBox);
            Controls.Add(ClearButton);
            Controls.Add(LoginButton);
            Controls.Add(pictureBox1);
            Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)HidePasswordIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)ShowPasswordIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)passwordIconBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)userIconBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LinkLabel linkLabel1;
        private PictureBox HidePasswordIcon;
        private PictureBox ShowPasswordIcon;
        private Label PasswordPlaceHolderLabel;
        private Label UsernamePlaceHolderLabel;
        private PictureBox passwordIconBox;
        private PictureBox userIconBox;
        private Button ExitButton;
        private TextBox PasswordTextBox;
        private TextBox UsernameTextBox;
        private Button ClearButton;
        private Button LoginButton;
        private PictureBox pictureBox1;
    }
}