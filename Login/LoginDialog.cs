using System;
using System.Windows.Forms;

namespace Login
{
    public partial class LoginDialog : Form
    {
        private string Login => emailTextBox.Text;
        private string Password => passwordTextBox.Text;
        
        /// <summary>
        /// Авторизированный пользователь
        /// </summary>
        public User User { get; private set; }

        public LoginDialog()
        {
            InitializeComponent();
            DialogResult = DialogResult.OK;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            User = User.ByLogin(Login);
            
            if (User?.Password == Password.EncryptBySHA256())
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Введены некорректные данные.", "Ошибка");
            }
        }

        private void registrationButton_Click(object sender, EventArgs e)
        {
            // Диалог регистрации
            var dialog = new RegDialog();

            // Если пользователь зарегистрировался, то войти под этим пользователем
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                User = dialog.User;
                DialogResult = DialogResult.OK;
            }
        }
    }
}
