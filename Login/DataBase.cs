using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Login
{
    /// <summary>
    /// Работа с базой данных
    /// </summary>
    public static class DataBase
    {
        /// <summary>
        /// Сервер базы данных
        /// </summary>
        private const string DataSource = @"ERELID";

        /// <summary>
        /// База данных
        /// </summary>
        private const string InitialCatalog = "Reg";

        private static readonly string ConnectionString = $@"Data Source={ DataSource }; Initial Catalog={ InitialCatalog }; Integrated Security=True";

        private static readonly ISessionFactory SessionFactory;

        /// <summary>
        /// Текущая сессия
        /// </summary>
        private static ISession _session;

        /// <summary>
        /// Возвращает текущую сессию или создаёт новую, если текущая закрыта
        /// </summary>
        /// <returns>Сессия для работы с базой данных</returns>
        public static ISession Session
        {
            get
            {
                if ( _session == null || !_session.IsOpen )
                    _session = SessionFactory.OpenSession();

                return _session;
            }
        }

        static DataBase()
        {
            SessionFactory = Fluently.Configure() // Создание конфигурации FluentNHibernate
                .Database(MsSqlConfiguration      
                    .MsSql2012.ConnectionString(ConnectionString)) // База данных, с которой будет идти работа
                .Mappings(x => x  // С какими сущностями будет идти работа
                    .FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())) // Добавить все найденные сущности
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true)) // Обновить базу данных в соответствие с текущей конфигурацией
                .BuildConfiguration()
                .BuildSessionFactory();
        }
    }
}
