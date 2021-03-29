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

        private void button1_Click(object sender, EventArgs e)
        {
            // Поиск пользователя по логину (почте)
            User = User.ByLogin(emailTextBox.Text);

            // Если пользователь найден и пароли совпдают, то войти
            if (User?.Password == Utils.EncryptPassword(passwordTextBox.Text))
            {
                DialogResult = DialogResult.OK;
            }
            else // Иначе выдать оишбку
            {
                MessageBox.Show("Введены некорректные данные.", "Ошибка");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Диалог регистрации
            var dialog = new RegDialog();

            // Если пользователь зарегистрировался, то войти под этим пользователем
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                User = dialog.User;
                DialogResult = DialogResult.OK;
            }
        }
    }
}
