using System;
using System.Drawing;
using System.Windows.Forms;

namespace Login
{
    public partial class RegDialog : Form
    {
        /// <summary>
        /// Новый пользователь
        /// </summary>
        public User User { get; private set; }

        public RegDialog()
        {
            InitializeComponent();
        }

        private void regButton_Click(object sender, EventArgs e)
        {
            // Вход только если все данные введены корректно
            if ( !IsLoginValid() && !IsEmailValid() && !IsPasswordConfirmed() ) return;

            // Создание пользователя
            User = new User
            {
                Login = loginTextBox.Text,
                Password = Utils.EncryptPassword(passwordTextBox.Text),
                Photo = panel1.BackgroundImage,
                Type = typeComboBox.Text
            };

            // Сохранение объекта в базу данных
            DataBase.Session.Save(User);

            // Подтверждение изменений в Базе данных
            DataBase.Session.Flush(); 

            DialogResult = DialogResult.OK;
        }

        private bool IsEmailValid()
        {
            // Если почта не введена, то выдать ошибку
            if ( emailTextBox.Text == "" )
            {
                emailError.SetError(emailTextBox, "Введите почту");
                return false;
            }

            // Если почта введена некорректно, то выдать ошибку
            if ( !Utils.IsValidEmail(emailTextBox.Text) )
            {
                emailError.SetError(emailTextBox, "Введите нормальную почту");
                return false;
            }

            // Если пользователь с такой почтой уже есть, то выдать ошибку
            if ( User.ByEmail(emailTextBox.Text) != null )
            {
                emailError.SetError(emailTextBox, "Почта уже занята");
                return false;
            }

            emailError.Clear();
            return true;
        }

        private bool IsLoginValid()
        {
            // Если логин не введён, то выдать ошибку
            if ( loginTextBox.Text == "" ) 
            {
                loginError.SetError(loginTextBox, "Введите логин");
                return false;
            }

            // Если пользователь с таким логином уже есть, то выдать ошибку
            if ( User.ByLogin(loginTextBox.Text) != null ) 
            {
                loginError.SetError(loginTextBox, "Логин уже занят");
                return false;
            }

            loginError.Clear();
            return true;
        }

        private bool IsPasswordValid()
        {
            // Если пароль не введён, то выдать оишбку
            if (passwordTextBox.Text == "")
            {
                passwordError.SetError(passwordTextBox, "Введите пароль");
                return false;
            }

            // Пароль не должен содержать логин, иначе выдать ошибку
            if ( passwordTextBox.Text.Contains(loginTextBox.Text) ) 
            {
                passwordError.SetError(passwordTextBox, "Пароль содержит логин");
                return false;
            }

            // если пароль не надёжен, то выдать ошибку
            if (!Utils.IsPasswordStrong(passwordTextBox.Text)) 
            { 
                passwordError.SetError(passwordTextBox, "Вы ввели слишком простой пароль");
                return false;
            }

            passwordError.Clear();
            return true;
        }

        private bool IsPasswordConfirmed()
        {
            // Пароли проверяются на совпадение лишь если пароль введён верно
            if ( !IsPasswordValid() ) 
            {
                confirmPasswordError.Clear();
                return false;
            }

            // Пароль и подтверждение пароля должны совпдать
            if ( passwordTextBox.Text != passwordConfirmTextBox.Text ) 
            {
                confirmPasswordError.SetError(passwordConfirmTextBox, "Пароли не совпадают.");
                return false;
            }
            confirmPasswordError.Clear();
            return true;
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e) 
        {
            // Проверять почту при изменении текста в поле почты
            IsEmailValid();
        }

        private void loginTextBox_TextChanged(object sender, EventArgs e)
        {
            // Проверять логин при изменении текста в поле логина
            IsLoginValid();
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e) 
        {
            // Проверять пароль при изменении текста в поле пароля
            IsPasswordValid(); 
        }

        private void passwordConfirmTextBox_TextChanged(object sender, EventArgs e) 
        {
            // Проверять пароли на свопадение при изменении текста в поле подтверждения пароля
            IsPasswordConfirmed(); 
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            // Диалог для поиска файлов с расширениями png, jpg и jpeg
            var dialog = new OpenFileDialog { Filter = "Images|*.png;*.jpg;*.jpeg" };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Присвоить найденное изображение фону панели
                panel1.BackgroundImage = Image.FromFile(dialog.FileName);
            }
        }
    }
}
