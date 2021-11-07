using System;
using System.Drawing;
using System.Windows.Forms;

namespace Login
{
    public partial class RegDialog : Form
    {
        private string Login => loginTextBox.Text;
        private string Email => emailTextBox.Text;
        private string Password => passwordTextBox.Text;
        private string PasswordConfirm => passwordConfirmTextBox.Text;

        /// <summary>
        /// Новый пользователь
        /// </summary>
        public User User { get; private set; }

        public RegDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        private void regButton_Click(object sender, EventArgs e)
        {
            // Регистрация происходит лишь при правильности введённых данных
            if ( !IsLoginValid() && !IsPasswordConfirmed() ) return;
            
            User = new User
            {
                Login = Login,
                Password = Password.EncryptBySHA256(),
                Photo = avatarPanel.BackgroundImage,
                Type = typeComboBox.Text
            };
            
            DataBase.Session.Save(User);
            DataBase.Session.Flush(); 

            DialogResult = DialogResult.OK;
        }

        private bool IsLoginValid()
        {
            if ( Login == "" ) 
            {
                emailError.SetError(emailTextBox, "Введите почту");
                return false;
            }
            
            if ( Email.IsValidEmail() ) 
            {
                emailError.SetError(emailTextBox, "Введите нормальную почту");
                return false;
            }

            // Почта не должна быть занята
            if ( User.ByLogin(Email) != null) 
            {
                emailError.SetError(emailTextBox, "Почта уже занята");
                return false;
            }
            
            emailError.Clear();
            return true;
        }

        private bool IsPasswordValid()
        {
            switch (Password.GetPasswordStrength())
            {
                case PasswordStrength.None:
                    passwordError.SetError(passwordTextBox, "Введите пароль");
                    return false;
                case PasswordStrength.VeryWeak:
                case PasswordStrength.Weak:
                case PasswordStrength.Medium:
                    // Пароль не должен содержать логин
                    if (passwordTextBox.Text.Contains(loginTextBox.Text))
                    {
                        passwordError.SetError(passwordTextBox, "Пароль совпадает с логином");
                        return false;
                    }
                    else
                    {
                        passwordError.SetError(passwordTextBox, "Вы ввели слишком простой пароль");
                        return false;
                    }
                case PasswordStrength.Strong:
                case PasswordStrength.VeryStrong:
                    passwordError.Clear();
                    return true;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private bool IsPasswordConfirmed()
        {
            // Пароли проверяются на совпадение лишь если пароль введён верно
            if (!IsPasswordValid()) 
            {
                confirmPasswordError.Clear();
                return false;
            }

            if (Password != PasswordConfirm) 
            {
                confirmPasswordError.SetError(passwordConfirmTextBox, "Пароли не совпадают.");
                return false;
            }
            
            confirmPasswordError.Clear();
            return true;
        }

        /// <summary>
        /// Проверка почты при её изменении
        /// </summary>
        private void emailTextBox_TextChanged(object sender, EventArgs e) 
        {
            IsLoginValid(); 
        } 

        /// <summary>
        /// Проверка пароля при его изменнеии
        /// </summary>
        private void passwordTextBox_TextChanged(object sender, EventArgs e) 
        {
            IsPasswordValid(); 
        }

        /// <summary>
        /// Проверка повтора пароля
        /// </summary>
        private void passwordConfirmTextBox_TextChanged(object sender, EventArgs e) 
        {
            IsPasswordConfirmed(); 
        }

        /// <summary>
        /// Выбор новоей картинки профиля
        /// </summary>
        private void avatarPanel_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog { Filter = "Images|*.png;*.jpg;*.jpeg" };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                avatarPanel.BackgroundImage = Image.FromFile(dialog.FileName);
            }
        }
    }
}
