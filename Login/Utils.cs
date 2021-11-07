using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Login
{
    public enum PasswordStrength
    {
        None,
        VeryWeak,
        Weak,
        Medium,
        Strong,
        VeryStrong
    }
    
    /// <summary>
    /// Набор полезных функций
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Проверка пароля на надёжность
        /// </summary>
        /// <param name="password">Пароль, который необходимо проверить</param>
        /// <returns>Значение типа PasswordStrength</returns>
        public static PasswordStrength GetPasswordStrength(this string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return PasswordStrength.None;
            }

            PasswordStrength result = PasswordStrength.None;
            
            // Пароль должен быть не меньше 5 символов
            if (password.Length > 4) result++;

            // Пароль должен содержать строчные буквы
            if (Regex.IsMatch(password, @"[a-z]")) result++; 

            // Пароль должен содержать прописные буквы
            if (Regex.IsMatch(password, @"[A-Z]")) result++;

            // Пароль должен содержать цифры
            if (Regex.IsMatch(password, @"\d+")) result++;

            // Пароль должен содержать различные символы, перечисленные в [...] 
            if (Regex.IsMatch(password, @"[_, ?, \\]")) result++;

            return result;
        }

        /// <summary>
        /// Шифровка пароля кодировкой SHA256
        /// </summary>
        /// <param name="password">Пароль, который нужно зашифровать</param>
        /// <returns>Зашифрованный пароль</returns>
        public static string EncryptBySHA256(this string password)
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
        public static bool IsValidEmail(this string email)
        {
            try
            {
                return new MailAddress(email).Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}