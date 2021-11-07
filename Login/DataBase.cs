using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Login
{
    public static class DataBase
    {
        /// <summary>
        /// Сервер базы данных
        /// </summary>
        private const string DataSource = "ERELID";

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
        /// Текушая сессия для работы с базой данных
        /// </summary>
        /// <remarks>Если нет сессии или она закрыта, то создаётся новая сессия</remarks>
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
            SessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration      
                    .MsSql2012.ConnectionString(ConnectionString))
                .Mappings(x => x
                    .FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .BuildConfiguration()
                .BuildSessionFactory();
        }
    }
}
