using System;
using System.ComponentModel;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Login
{
    /// <summary>
    /// Набор полезных функций
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Проверка пароля на надёжность
        /// </summary>
        /// <param name="password">Пароль, который необходимо проверить</param>
        /// <returns>true, если пароль надёжен, иначе - false</returns>
        public static bool IsPasswordStrong(string password)
        {
            // Пароль должен быть не меньше 5 символов
            if (password.Length < 5) return false;

            // Пароль должен содержать строчные буквы
            if (!Regex.IsMatch(password, @"[a-z]")) return false; 

            // Пароль должен содержать прописные буквы
            if (!Regex.IsMatch(password, @"[A-Z]")) return false;

            // Пароль должен содержать цифры
            if (!Regex.IsMatch(password, @"\d+")) return false;

            // Пароль должен содержать различные символы (перечислить необходимые через запятую в []) 
            if (!Regex.IsMatch(password, @"[_, ?, \\]")) return false;

            return true;
        }

        /// <summary>
        /// Шифровка пароля кодировкой SHA256
        /// </summary>
        /// <param name="password">Пароль, который нужно зашифровать</param>
        /// <returns>Зашифрованный пароль</returns>
        public static string EncryptPassword(string password)
        {
            using (var encrypt = SHA256.Create())
            {
                var result = new StringBuilder(128);

                foreach (var b in encrypt.ComputeHash(Encoding.UTF8.GetBytes(password)))
                {
                    result.Append(b.ToString("X2"));
                }

                return result.ToString();
            }
        }

        /// <summary>
        /// Проверка почты на правильность
        /// </summary>
        /// <param name="email">Предполагаемая почта</param>
        /// <returns>true, если это почта, иначе - false</returns>
        public static bool IsValidEmail(string email)
        {
            try
            {
                // Создаём из поданной строки почту и сверяем с начальным результатом
                return new MailAddress(email).Address == email;
            }
            catch
            {
                // Любая ошибка означает, что почта введена некорректно
                return false;
            }
        }
    }
}