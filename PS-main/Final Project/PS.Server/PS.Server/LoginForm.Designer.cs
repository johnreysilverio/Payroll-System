namespace PS.Server
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
            LoginButton = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            UsernameTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            ClearButton = new Button();
            ExitButton = new Button();
            UsernamePlaceHolderLabel = new Label();
            PasswordPlaceHolderLabel = new Label();
            HidePasswordIcon = new PictureBox();
            ShowPasswordIcon = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HidePasswordIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ShowPasswordIcon).BeginInit();
            SuspendLayout();
            // 
            // LoginButton
            // 
            LoginButton.BackColor = SystemColors.Control;
            LoginButton.Image = Properties.Resources.login;
            LoginButton.ImageAlign = ContentAlignment.MiddleLeft;
            LoginButton.Location = new Point(12, 264);
            LoginButton.Margin = new Padding(5, 6, 5, 6);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(413, 52);
            LoginButton.TabIndex = 2;
            LoginButton.Text = "LOGIN";
            LoginButton.UseVisualStyleBackColor = false;
            LoginButton.Click += LoginButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.PS_Server;
            pictureBox1.Location = new Point(129, -14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(172, 186);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.userIcon;
            pictureBox2.Location = new Point(12, 150);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(36, 36);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.passwordIcon;
            pictureBox3.Location = new Point(12, 215);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(36, 36);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            // 
            // UsernameTextBox
            // 
            UsernameTextBox.BackColor = SystemColors.Control;
            UsernameTextBox.Location = new Point(56, 150);
            UsernameTextBox.Name = "UsernameTextBox";
            UsernameTextBox.Size = new Size(369, 37);
            UsernameTextBox.TabIndex = 0;
            UsernameTextBox.Enter += UsernameTextBox_Enter;
            UsernameTextBox.Leave += UsernameTextBox_Leave;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.BackColor = SystemColors.Control;
            PasswordTextBox.Location = new Point(54, 215);
            PasswordTextBox.MaxLength = 16;
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(369, 37);
            PasswordTextBox.TabIndex = 1;
            PasswordTextBox.UseSystemPasswordChar = true;
            PasswordTextBox.Enter += PasswordTextBox_Enter;
            PasswordTextBox.KeyDown += LoginButton_KeyDown;
            PasswordTextBox.Leave += PasswordTextBox_Leave;
            // 
            // ClearButton
            // 
            ClearButton.BackColor = SystemColors.Control;
            ClearButton.Image = Properties.Resources.clear;
            ClearButton.ImageAlign = ContentAlignment.MiddleLeft;
            ClearButton.Location = new Point(12, 333);
            ClearButton.Margin = new Padding(5, 6, 5, 6);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(202, 52);
            ClearButton.TabIndex = 3;
            ClearButton.Text = "CLEAR";
            ClearButton.UseVisualStyleBackColor = false;
            ClearButton.Click += ClearButton_Click;
            // 
            // ExitButton
            // 
            ExitButton.BackColor = SystemColors.Control;
            ExitButton.Image = Properties.Resources.Exit;
            ExitButton.ImageAlign = ContentAlignment.MiddleLeft;
            ExitButton.Location = new Point(221, 333);
            ExitButton.Margin = new Padding(5, 6, 5, 6);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(202, 52);
            ExitButton.TabIndex = 4;
            ExitButton.Text = "EXIT";
            ExitButton.UseVisualStyleBackColor = false;
            ExitButton.Click += ExitButton_Click;
            // 
            // UsernamePlaceHolderLabel
            // 
            UsernamePlaceHolderLabel.AutoSize = true;
            UsernamePlaceHolderLabel.BackColor = SystemColors.Control;
            UsernamePlaceHolderLabel.ForeColor = SystemColors.ActiveBorder;
            UsernamePlaceHolderLabel.Location = new Point(64, 154);
            UsernamePlaceHolderLabel.Name = "UsernamePlaceHolderLabel";
            UsernamePlaceHolderLabel.Size = new Size(114, 29);
            UsernamePlaceHolderLabel.TabIndex = 8;
            UsernamePlaceHolderLabel.Text = "Username";
            UsernamePlaceHolderLabel.Click += UsernamePlaceHolderLabel_Click;
            // 
            // PasswordPlaceHolderLabel
            // 
            PasswordPlaceHolderLabel.AutoSize = true;
            PasswordPlaceHolderLabel.BackColor = SystemColors.Control;
            PasswordPlaceHolderLabel.ForeColor = SystemColors.ActiveBorder;
            PasswordPlaceHolderLabel.Location = new Point(64, 219);
            PasswordPlaceHolderLabel.Name = "PasswordPlaceHolderLabel";
            PasswordPlaceHolderLabel.Size = new Size(107, 29);
            PasswordPlaceHolderLabel.TabIndex = 9;
            PasswordPlaceHolderLabel.Text = "Password";
            PasswordPlaceHolderLabel.Click += PasswordPlaceHolderLabel_Click;
            // 
            // HidePasswordIcon
            // 
            HidePasswordIcon.BackColor = SystemColors.Control;
            HidePasswordIcon.Image = Properties.Resources.hidePasswordIcon;
            HidePasswordIcon.Location = new Point(390, 221);
            HidePasswordIcon.Name = "HidePasswordIcon";
            HidePasswordIcon.Size = new Size(25, 25);
            HidePasswordIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            HidePasswordIcon.TabIndex = 10;
            HidePasswordIcon.TabStop = false;
            HidePasswordIcon.Click += HidePasswordIcon_Click;
            // 
            // ShowPasswordIcon
            // 
            ShowPasswordIcon.BackColor = SystemColors.Control;
            ShowPasswordIcon.Image = Properties.Resources.showPasswordIcon;
            ShowPasswordIcon.Location = new Point(390, 221);
            ShowPasswordIcon.Name = "ShowPasswordIcon";
            ShowPasswordIcon.Size = new Size(25, 25);
            ShowPasswordIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            ShowPasswordIcon.TabIndex = 11;
            ShowPasswordIcon.TabStop = false;
            ShowPasswordIcon.Click += ShowPasswordIcon_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(99, 110, 114);
            ClientSize = new Size(442, 400);
            Controls.Add(ShowPasswordIcon);
            Controls.Add(HidePasswordIcon);
            Controls.Add(PasswordPlaceHolderLabel);
            Controls.Add(UsernamePlaceHolderLabel);
            Controls.Add(ExitButton);
            Controls.Add(ClearButton);
            Controls.Add(PasswordTextBox);
            Controls.Add(UsernameTextBox);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(LoginButton);
            Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)HidePasswordIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)ShowPasswordIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button LoginButton;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private TextBox UsernameTextBox;
        private TextBox PasswordTextBox;
        private Button ClearButton;
        private Button ExitButton;
        private Label UsernamePlaceHolderLabel;
        private Label PasswordPlaceHolderLabel;
        private PictureBox HidePasswordIcon;
        private PictureBox ShowPasswordIcon;
    }
}