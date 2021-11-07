using System;
using System.Collections.Generic;
using System.Drawing;
using FluentNHibernate.Mapping;

namespace Login
{
    public class User
    {
        /// <summary>
        /// Уникальный логин пользователя
        /// </summary>
        public virtual string Login { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        /// <remarks>
        /// Зашифровано с помощью SHA256
        /// </remarks>
        public virtual string Password { get; set; }

        /// <summary>
        /// Фото пользователя
        /// </summary>
        public virtual Image Photo { get; set; }

        /// <summary>
        /// Тип пользователя
        /// </summary>
        /// <remarks>
        /// Например:
        /// - Директор
        /// - Менеджер по работе с клиентами
        /// - Менеджер по заказам
        /// - Мастер
        /// - Заказчик
        /// </remarks>
        public virtual string Type { get; set; }

        /// <summary>
        /// Инструменты пользователя
        /// </summary>
        /// <remarks>
        /// У пользователя может быть несколько инструментов
        /// </remarks>
        public virtual IList<Tool> Tools { get; set; }

        public override string ToString()
        {
            return $"{Login}";
        }

        /// <summary>
        /// Возвращает пользователя по заданному логину
        /// </summary>
        /// <param name="login">Логин искомого пользователя</param>
        /// <returns>Пользователь с указанным логином</returns>
        public static User ByLogin(string login)
        {
            // Select * From User Where User.login = login
            return DataBase.Session.QueryOver<User>().Where(x => x.Login == login).SingleOrDefault() 
                   ?? throw new ArgumentException("Логин отсутсвует в Базе данных.");
        }

        /// <summary>
        /// Возвращает всех пользователей хранящихся в базе данных
        /// </summary>
        /// <returns>Список всех пользователей в базе данных</returns>
        public static IList<User> GetAll()
        {
            // Select * From User
            return DataBase.Session.QueryOver<User>().List();
        }
    }

    internal class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            // Логин вводится пользователем вручную
            // Потому генерация не используется
            Id(x => x.Login);                    
            Map(x => x.Password);
            
            Map(x => x.Photo).Length(int.MaxValue);
            Map(x => x.Type);

            // У каждого пользователя может быть несколько инструментов
            HasMany(x => x.Tools);
        }
    }
}
