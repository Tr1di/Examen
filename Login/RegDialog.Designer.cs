
namespace Login
{
    partial class RegDialog
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
            this.components = new System.ComponentModel.Container();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.loginLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.confirmPasswordLabel = new System.Windows.Forms.Label();
            this.passwordConfirmTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.patronymicLabel = new System.Windows.Forms.Label();
            this.patronymicTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.userTypeLabel = new System.Windows.Forms.Label();
            this.regButton = new System.Windows.Forms.Button();
            this.phoneTextBox = new System.Windows.Forms.MaskedTextBox();
            this.passwordError = new System.Windows.Forms.ErrorProvider(this.components);
            this.emailError = new System.Windows.Forms.ErrorProvider(this.components);
            this.confirmPasswordError = new System.Windows.Forms.ErrorProvider(this.components);
            this.avatarPanel = new System.Windows.Forms.Panel();
            this.photoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.passwordError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.confirmPasswordError)).BeginInit();
            this.SuspendLayout();
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(143, 9);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 7;
            this.passwordLabel.Text = "Password";
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(12, 48);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(33, 13);
            this.loginLabel.TabIndex = 6;
            this.loginLabel.Text = "Login";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(143, 25);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(125, 20);
            this.passwordTextBox.TabIndex = 2;
            this.passwordTextBox.UseSystemPasswordChar = true;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBox_TextChanged);
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(12, 64);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(125, 20);
            this.loginTextBox.TabIndex = 1;
            // 
            // confirmPasswordLabel
            // 
            this.confirmPasswordLabel.AutoSize = true;
            this.confirmPasswordLabel.Location = new System.Drawing.Point(143, 48);
            this.confirmPasswordLabel.Name = "confirmPasswordLabel";
            this.confirmPasswordLabel.Size = new System.Drawing.Size(91, 13);
            this.confirmPasswordLabel.TabIndex = 9;
            this.confirmPasswordLabel.Text = "Password Confirm";
            // 
            // passwordConfirmTextBox
            // 
            this.passwordConfirmTextBox.Location = new System.Drawing.Point(143, 64);
            this.passwordConfirmTextBox.Name = "passwordConfirmTextBox";
            this.passwordConfirmTextBox.Size = new System.Drawing.Size(125, 20);
            this.passwordConfirmTextBox.TabIndex = 3;
            this.passwordConfirmTextBox.UseSystemPasswordChar = true;
            this.passwordConfirmTextBox.TextChanged += new System.EventHandler(this.passwordConfirmTextBox_TextChanged);
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(12, 9);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(32, 13);
            this.emailLabel.TabIndex = 11;
            this.emailLabel.Text = "Email";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(12, 25);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(125, 20);
            this.emailTextBox.TabIndex = 7;
            this.emailTextBox.TextChanged += new System.EventHandler(this.emailTextBox_TextChanged);
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new System.Drawing.Point(143, 87);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(38, 13);
            this.phoneLabel.TabIndex = 13;
            this.phoneLabel.Text = "Phone";
            // 
            // patronymicLabel
            // 
            this.patronymicLabel.AutoSize = true;
            this.patronymicLabel.Location = new System.Drawing.Point(12, 165);
            this.patronymicLabel.Name = "patronymicLabel";
            this.patronymicLabel.Size = new System.Drawing.Size(59, 13);
            this.patronymicLabel.TabIndex = 21;
            this.patronymicLabel.Text = "Patronymic";
            // 
            // patronymicTextBox
            // 
            this.patronymicTextBox.Location = new System.Drawing.Point(12, 181);
            this.patronymicTextBox.Name = "patronymicTextBox";
            this.patronymicTextBox.Size = new System.Drawing.Size(125, 20);
            this.patronymicTextBox.TabIndex = 6;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 126);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 19;
            this.nameLabel.Text = "Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(12, 142);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(125, 20);
            this.nameTextBox.TabIndex = 5;
            // 
            // surnameLabel
            // 
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.Location = new System.Drawing.Point(12, 87);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(49, 13);
            this.surnameLabel.TabIndex = 17;
            this.surnameLabel.Text = "Surname";
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Location = new System.Drawing.Point(12, 103);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(125, 20);
            this.surnameTextBox.TabIndex = 4;
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "Заказчик",
            "Директор",
            "Кладовщик",
            "Продавец"});
            this.typeComboBox.Location = new System.Drawing.Point(143, 141);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(125, 21);
            this.typeComboBox.TabIndex = 9;
            // 
            // userTypeLabel
            // 
            this.userTypeLabel.AutoSize = true;
            this.userTypeLabel.Location = new System.Drawing.Point(143, 126);
            this.userTypeLabel.Name = "userTypeLabel";
            this.userTypeLabel.Size = new System.Drawing.Size(31, 13);
            this.userTypeLabel.TabIndex = 23;
            this.userTypeLabel.Text = "Type";
            // 
            // regButton
            // 
            this.regButton.Location = new System.Drawing.Point(143, 178);
            this.regButton.Name = "regButton";
            this.regButton.Size = new System.Drawing.Size(125, 23);
            this.regButton.TabIndex = 24;
            this.regButton.Text = "Зарегистрироваться";
            this.regButton.UseVisualStyleBackColor = true;
            this.regButton.Click += new System.EventHandler(this.regButton_Click);
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(143, 103);
            this.phoneTextBox.Mask = "8 (000) 000-00-00";
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(126, 20);
            this.phoneTextBox.TabIndex = 25;
            // 
            // passwordError
            // 
            this.passwordError.ContainerControl = this;
            // 
            // emailError
            // 
            this.emailError.ContainerControl = this;
            // 
            // confirmPasswordError
            // 
            this.confirmPasswordError.ContainerControl = this;
            // 
            // avatarPanel
            // 
            this.avatarPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.avatarPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.avatarPanel.Location = new System.Drawing.Point(275, 25);
            this.avatarPanel.Name = "avatarPanel";
            this.avatarPanel.Size = new System.Drawing.Size(137, 137);
            this.avatarPanel.TabIndex = 26;
            this.avatarPanel.Click += new System.EventHandler(this.avatarPanel_Click);
            // 
            // photoLabel
            // 
            this.photoLabel.AutoSize = true;
            this.photoLabel.Location = new System.Drawing.Point(272, 9);
            this.photoLabel.Name = "photoLabel";
            this.photoLabel.Size = new System.Drawing.Size(35, 13);
            this.photoLabel.TabIndex = 27;
            this.photoLabel.Text = "Photo";
            // 
            // RegDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 216);
            this.Controls.Add(this.photoLabel);
            this.Controls.Add(this.avatarPanel);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.regButton);
            this.Controls.Add(this.userTypeLabel);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.patronymicLabel);
            this.Controls.Add(this.patronymicTextBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.surnameLabel);
            this.Controls.Add(this.surnameTextBox);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.confirmPasswordLabel);
            this.Controls.Add(this.passwordConfirmTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.loginTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "RegDialog";
            this.Text = "Регистрация";
            ((System.ComponentModel.ISupportInitialize)(this.passwordError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.confirmPasswordError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.Label confirmPasswordLabel;
        private System.Windows.Forms.TextBox passwordConfirmTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.Label patronymicLabel;
        private System.Windows.Forms.TextBox patronymicTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label surnameLabel;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label userTypeLabel;
        private System.Windows.Forms.Button regButton;
        private System.Windows.Forms.MaskedTextBox phoneTextBox;
        private System.Windows.Forms.ErrorProvider passwordError;
        private System.Windows.Forms.ErrorProvider emailError;
        private System.Windows.Forms.ErrorProvider confirmPasswordError;
        private System.Windows.Forms.Label photoLabel;
        private System.Windows.Forms.Panel avatarPanel;
    }
}