using System;
using System.Windows.Forms;

namespace Login
{
    public partial class LoginDialog : Form
    {
        /// <summary>
        /// Авторизированный пользователь
        /// </summary>
        public User User { get; private set; }

        public LoginDialog()
        {
            InitializeComponent();
        }

        private void AuthorizeAs(User user)
        {
            User = user;

            // Если пользователь найден и пароли совпдают, то войти
            if (User?.Password == Utils.EncryptPassword(passwordTextBox.Text))
            {
                if ( checkBox1.Checked )
                {
                    Properties.Settings.Default.SavedLogin = User.Login;
                    Properties.Settings.Default.SavedPasswword = User.Password;
                    Properties.Settings.Default.Save();
                }

                DialogResult = DialogResult.OK;
            }
            else // Иначе выдать оишбку
            {
                MessageBox.Show("Введены некорректные данные.", "Ошибка");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Поиск пользователя по логину (почте)
            AuthorizeAs(User.ByLogin(emailTextBox.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Диалог регистрации
            var dialog = new RegDialog();

            // Если пользователь зарегистрировался, то войти под этим пользователем
            if ( dialog.ShowDialog() == DialogResult.OK )
            {
                AuthorizeAs(dialog.User);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if ( !checkBox1.Checked )
            {
                Properties.Settings.Default.SavedLogin = "";
                Properties.Settings.Default.SavedPasswword = "";
            }
        }
    }
}
