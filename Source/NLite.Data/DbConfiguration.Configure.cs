using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Threading;
using NLite.Data.Common;
using NLite.Data.Dialect;
using NLite.Data.Dialect.ExpressionBuilder;
using NLite.Data.Dialect.SqlBuilder;
using NLite.Data.Driver;
using NLite.Data.LinqToSql;
using NLite.Data.Schema.Loader;
using NLite.Data.Schema.Script.Executor;
using NLite.Data.Schema.Script.Generator;

namespace NLite.Data
{

    partial class DbConfiguration
    {
        static readonly IDictionary<string, DbConfiguration> items;
        static readonly HashSet<string> providerNames;
        static readonly Dictionary<string, DbConfigurationInfo> Options;

        /// <summary>
        /// 
        /// </summary>
        public DbConfigurationInfo Option { get; set; }


        static DbConfiguration()
        {
            ManualResetEvent mre = new ManualResetEvent(false);
            ThreadPool.QueueUserWorkItem(s =>
            {
                var dlinqAsm = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(p => p.GetName().Name == "System.Data.Linq");
                if (dlinqAsm != null)
                    DLinq.Init(dlinqAsm);
                var dataAnnotiationAsm = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(p => p.GetName().Name == DataAnnotationMappingAdapter.StrAssemblyName);
                if (dataAnnotiationAsm != null)
                    DataAnnotationMappingAdapter.Init(dataAnnotiationAsm);
                var efDataAnnotiationAsm = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(p => p.GetName().Name == EFDataAnnotiationAdapter.StrAssemblyName);
                if (efDataAnnotiationAsm != null)
                    EFDataAnnotiationAdapter.Init(efDataAnnotiationAsm);
                //初始化PrimitiveMapper
                Converter.IsPrimitiveType(Types.Boolean);
                //初始化Expressor
                var len = MethodRepository.Len;
                var mappings = NLite.Data.Common.MethodMapping.Mappings;

                mre.Set();
            }
           );

            Options = new Dictionary<string, DbConfigurationInfo>(StringComparer.Ordinal);
            items = new Dictionary<string, DbConfiguration>(StringComparer.Ordinal);

            Options["System.Data.OleDb"] = new DbConfigurationInfo
            {
                Driver = new AccessDriver(),
                Dialect = new AccessDialect(),
                FuncRegistry = new NLite.Data.Dialect.Function.Access.AccessFunctionRegistry(),
                DbExpressionBuilder = new AssessDbExpressionBuilder(),
                SqlBuilder = (dialect, funcRegistry) => new AccessSqlBuilder { Dialect = dialect, FuncRegistry = funcRegistry },

                ScriptGenerator = () => new AccessScriptGenerator(),
                ScriptExecutor = () => new AccessScriptExecutor(),
                SchemaLoader = () => new OledbSchemaLoader(),

            };

            Options["MySql.Data.MySqlClient"] = new DbConfigurationInfo
            {
                Driver = new MySqlDriver(),
                Dialect = new MySqlDialect(),
                FuncRegistry = new NLite.Data.Dialect.Function.MySQL.MySqlFunctionRegistry(),
                DbExpressionBuilder = new MySqlExpressionBuilder(),
                SqlBuilder = (dialect, funcRegistry) => new MySqlBuilder { Dialect = dialect, FuncRegistry = funcRegistry },

                ScriptGenerator = () => new MySQLScriptGenerator(),
                ScriptExecutor = () => new MySQLScriptExecutor(),
                SchemaLoader = () => new MySqlSchemaLoader(),

            };

            Options["Oracle.DataAccess.Client"] = new DbConfigurationInfo
            {
                Driver = new OracleODPDriver(),
                Dialect = new OracleDialect(),
                FuncRegistry = new NLite.Data.Dialect.Function.Oracle.OracleFunctionRegistry(),
                DbExpressionBuilder = new OracleExpressionBuilder(),
                SqlBuilder = (dialect, funcRegistry) => new OracleSqlBuilder { Dialect = dialect, FuncRegistry = funcRegistry },

                ScriptGenerator = () => new OracleScriptGenerator(),
                ScriptExecutor = () => new OracleScriptExecutor(),
                SchemaLoader = () => new OracleSchemaLoader(),
            };

            Options["System.Data.OracleClient"] = new DbConfigurationInfo
            {
                Driver = new OracleClientDriver(),
                Dialect = new OracleDialect(),
                FuncRegistry = new NLite.Data.Dialect.Function.Oracle.OracleFunctionRegistry(),
                DbExpressionBuilder = new OracleExpressionBuilder(),
                SqlBuilder = (dialect, funcRegistry) => new OracleSqlBuilder { Dialect = dialect, FuncRegistry = funcRegistry },

                ScriptGenerator = () => new OracleScriptGenerator(),
                ScriptExecutor = () => new OracleScriptExecutor(),
                SchemaLoader = () => new OracleSchemaLoader(),
            };

            Options["System.Data.SqlClient"] = new DbConfigurationInfo
            {
                Driver = new SqlServer2005Driver(),
                Dialect = new MsSql2005Dialect(),
                FuncRegistry = new NLite.Data.Dialect.Function.MsSql.MsSql2005FunctionRegistry(),
                DbExpressionBuilder = new MsSql2005ExpressionBuilder(),
                SqlBuilder = (dialect, funcRegistry) => new SqlServer2005SqlBuilder { Dialect = dialect, FuncRegistry = funcRegistry },

                ScriptGenerator = () => new SqlServerScriptGenerator(),
                ScriptExecutor = () => new SqlServerScriptExecutor(),
                SchemaLoader = () => new SqlServerSchemaLoader(),
            };

            Options["System.Data.SQLite"] = new DbConfigurationInfo
            {
                Driver = new SQLiteDriver(),
                Dialect = new SQLiteDialect(),
                FuncRegistry = new NLite.Data.Dialect.Function.SQLite.SQLiteFunctionManager(),
                DbExpressionBuilder = new SQLiteExpressionBuilder(),
                SqlBuilder = (dialect, funcRegistry) => new SQLiteSqlBuilder { Dialect = dialect, FuncRegistry = funcRegistry },

                ScriptGenerator = () => new SQLiteScriptGenerator(),
                ScriptExecutor = () => new SQLiteScriptExecutor(),
                SchemaLoader = () => new SQLiteSchemaLoader(),

            };

            Options["System.Data.SqlServerCe.3.5"] = new DbConfigurationInfo
            {
                Driver = new SqlCeDriver(),
                Dialect = new SqlCe35Dialect(),
                FuncRegistry = new NLite.Data.Dialect.Function.SqlCe.SqlCeFunctionRegistry(),
                DbExpressionBuilder = new SqlCe35ExpressionBuilder(),
                SqlBuilder = (dialect, funcRegistry) => new SqlCeBuilder { Dialect = dialect, FuncRegistry = funcRegistry },

                ScriptGenerator = () => new SqlCeScriptGenerator(),
                ScriptExecutor = () => new SqlCeScriptExecutor(),
                SchemaLoader = () => new SqlCeSchemaLoader(),

            };

            Options["System.Data.SqlServerCe.4.0"] = new DbConfigurationInfo
            {
                Driver = new SqlCeDriver(),
                Dialect = new SqlCe35Dialect(),
                FuncRegistry = new NLite.Data.Dialect.Function.SqlCe.SqlCeFunctionRegistry(),
                DbExpressionBuilder = new SqlCe35ExpressionBuilder(),
                SqlBuilder = (dialect, funcRegistry) => new SqlCeBuilder { Dialect = dialect, FuncRegistry = funcRegistry },

                ScriptGenerator = () => new SqlCeScriptGenerator(),
                ScriptExecutor = () => new SqlCeScriptExecutor(),
                SchemaLoader = () => new SqlCeSchemaLoader(),

            };


            providerNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var item in DbProviderFactories.GetFactoryClasses().Rows.Cast<DataRow>().Select(p => p["InvariantName"] as string))
                providerNames.Add(item);

            mre.WaitOne();
            mre.Close();
        }


        internal static DbConfiguration Get(string dbConfigurationName)
        {
            Guard.NotNull(dbConfigurationName, "dbConfigurationName");
            DbConfiguration cfg;
            items.TryGetValue(dbConfigurationName, out cfg);
            if (cfg == null)
            {
                //自动配置
                cfg = DbConfiguration.Configure(dbConfigurationName);

            }
            return cfg;
        }

        /// <summary>
        /// 通过缺省的连接字串配置创建DbConfiguration对象（当且仅当配置文件中只有一个数据库连接字符串配置时才能使用）
        /// </summary>
        /// <returns></returns>
        public static DbConfiguration Configure()
        {
            if (System.Configuration.ConfigurationManager.ConnectionStrings.Count == 0)
                throw new ConfigurationErrorsException(Res.ConnectionStringNoConfigException);
            if (System.Configuration.ConfigurationManager.ConnectionStrings.Count != 1)
                throw new ConfigurationErrorsException(Res.ConnectionStringNoConfigException);
            return DbConfiguration.Configure(System.Configuration.ConfigurationManager.ConnectionStrings[0].Name).MakeDefault();
        }
        /// <summary>
        /// 通过connectionStringName对象创建DbConfiguration对象（可以用于配置文件中有多个数据库连接字符串配置）
        /// </summary>
        /// <param name="connectionStringName"></param>
        /// <returns></returns>
        public static DbConfiguration Configure(string connectionStringName)
        {
            Guard.NotNullOrEmpty(connectionStringName, "connectionStringName");
            DbConfiguration cfg;
            if (items.TryGetValue(connectionStringName, out cfg))
                return cfg;

            var item = System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName];
            if (item == null)
                throw new ConfigurationErrorsException(string.Format(Res.ConnectionStringNameInvalid, connectionStringName));

            if (string.IsNullOrEmpty(item.ProviderName))
                throw new ConfigurationErrorsException("connectionString.ProviderName");
            var connectionString = item.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
                throw new ConfigurationErrorsException("ConnectionString");

            var providerName = providerNames.FirstOrDefault(p => p == item.ProviderName);
            if (providerName.IsNullOrEmpty())
                throw new ConfigurationErrorsException(item.ProviderName + " Provider name not exists or invalid for" + connectionStringName);

            DbProviderFactory factory = null;
            try
            {
                factory = DbProviderFactories.GetFactory(providerName);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException(providerName + " Provider name invalid for" + connectionStringName, ex);
            }



            cfg = new DbConfiguration(providerName, item.Name, connectionString, factory);

            lock (items)
                items[cfg.Name] = cfg;

            AutoMatchDialect(cfg, connectionString, providerName, factory);
            return cfg;
        }

        private static void AutoMatchDialect(DbConfiguration cfg, string connectionString, string providerName, DbProviderFactory factory)
        {
            if (Options.ContainsKey(providerName))
            {
                cfg.Option = Options[providerName];
            }

            PopulateSqlServer2000(cfg, factory);
        }



        /// <summary>
        ///  通过connectionString和providerName创建DbConfiguration对象
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="providerName"></param>
        /// <returns></returns>
        public static DbConfiguration Configure(string connectionString, string providerName)
        {
            Guard.NotNullOrEmpty(connectionString, "connectionString");
            Guard.NotNullOrEmpty(providerName, "providerName");


            DbProviderFactory factory = null;
            try
            {
                factory = DbProviderFactories.GetFactory(providerName);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException(providerName + " Provider name invalid", ex);
            }

            var cfg = new DbConfiguration(providerName, Guid.NewGuid().ToString(), connectionString, factory);


            lock (items)
                items[cfg.Name] = cfg;

            AutoMatchDialect(cfg, connectionString, providerName, factory);
            return cfg;
        }

        /// <summary>
        /// 配置Access
        /// </summary>
        /// <param name="databaseFile"></param>
        /// <returns></returns>
        public static DbConfiguration ConfigureAccess(string databaseFile)
        {
            return DbConfiguration.Configure(BuildAccessConnectionString(databaseFile), DbProviderNames.Oledb);
        }

        /// <summary>
        /// 配置SqlCe35
        /// </summary>
        /// <param name="databaseFile"></param>
        /// <returns></returns>
        public static DbConfiguration ConfigureSqlCe35(string databaseFile)
        {
            return DbConfiguration.Configure(BuildSqlCeConnectionString(databaseFile), DbProviderNames.SqlCe35);
        }

        /// <summary>
        /// 配置SqlCe4
        /// </summary>
        /// <param name="databaseFile"></param>
        /// <returns></returns>
        public static DbConfiguration ConfigureSqlCe4(string databaseFile)
        {
            return DbConfiguration.Configure(BuildSqlCeConnectionString(databaseFile), DbProviderNames.SqlCe40);
        }

        /// <summary>
        /// 配置SQLExpress
        /// </summary>
        /// <param name="databaseFile"></param>
        /// <returns></returns>
        public static DbConfiguration ConfigureSQLExpress(string databaseFile)
        {
            return DbConfiguration.Configure(BuildSQLExpressConnectionString(databaseFile), DbProviderNames.SqlServer);
        }

        /// <summary>
        /// 配置SQLite
        /// </summary>
        /// <param name="databaseFile"></param>
        /// <returns></returns>
        public static DbConfiguration ConfigureSQLite(string databaseFile)
        {
            return DbConfiguration.Configure(BuildSQLiteConnectionString(databaseFile), DbProviderNames.SQLite);
        }

        /// <summary>
        /// 配置SQLite
        /// </summary>
        /// <param name="databaseFile"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static DbConfiguration ConfigureSQLite(string databaseFile, string password)
        {
            return DbConfiguration.Configure(BuildSQLiteConnectionString(databaseFile, password), DbProviderNames.SQLite);
        }

        /// <summary>
        /// 配置SQLite
        /// </summary>
        /// <param name="databaseFile"></param>
        /// <param name="failIfMissing"></param>
        /// <returns></returns>
        public static DbConfiguration ConfigureSQLite(string databaseFile, bool failIfMissing)
        {
            return DbConfiguration.Configure(BuildSQLiteConnectionString(databaseFile, failIfMissing), DbProviderNames.SQLite);
        }

        /// <summary>
        /// 配置SQLite
        /// </summary>
        /// <param name="databaseFile"></param>
        /// <param name="password"></param>
        /// <param name="failIfMissing"></param>
        /// <returns></returns>
        public static DbConfiguration ConfigureSQLite(string databaseFile, string password, bool failIfMissing)
        {
            return DbConfiguration.Configure(BuildSQLiteConnectionString(databaseFile, password, failIfMissing), DbProviderNames.SQLite);
        }

        /// <summary>
        /// 配置MySQL
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DbConfiguration ConfigureMySQL(string connectionString)
        {
            return DbConfiguration.Configure(connectionString, DbProviderNames.MySQL);
        }

        /// <summary>
        /// 配置SqlServer
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DbConfiguration ConfigureSqlServer(string connectionString)
        {
            return DbConfiguration.Configure(connectionString, DbProviderNames.SqlServer);
        }

        /// <summary>
        /// 配置Oracle
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DbConfiguration ConfigureOracle(string connectionString)
        {
            return DbConfiguration.Configure(connectionString, DbProviderNames.Oracle);
        }

        /// <summary>
        ///  配置Oracle ODP
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DbConfiguration ConfigureOracleODP(string connectionString)
        {
            return DbConfiguration.Configure(connectionString, DbProviderNames.Oracle_ODP);
        }

        private DbConnection connection;
        /// <summary>
        /// 通过DbConnection对象创建DbConfiguration对象
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static DbConfiguration Configure(DbConnection conn)
        {
            Guard.NotNull(conn, "conn");
            var providerType = conn.GetType()
                .Assembly
                .GetTypes()
                .Where(t => typeof(System.Data.Common.DbProviderFactory).IsAssignableFrom(t)
                && t.Namespace == conn.GetType().Namespace)
                .FirstOrDefault()
                ;
            if (providerType == null)
                throw new NotSupportedException("not found 'DbProviderFactory'");
            var factory = providerType.GetField("Instance", BindingFlags.Public | BindingFlags.Static).GetValue(null) as DbProviderFactory;
            Guard.NotNull(factory, "factory");

            var providerName = providerType.Namespace;
            var cfg = new DbConfiguration(providerName, Guid.NewGuid().ToString(), conn.ConnectionString, factory);
            if (!Options.ContainsKey(providerName))
            {
                var dbtype = conn.GetType().Name;
                if (dbtype.StartsWith("MySql")) providerName = DbProviderNames.MySQL;
                else if (dbtype.StartsWith("SqlCe")) providerName = DbProviderNames.SqlCe35;
                else if (dbtype.StartsWith("Oledb")) providerName = DbProviderNames.Oledb;
                else if (dbtype.StartsWith("Oracle")) providerName = DbProviderNames.Oracle;
                else if (dbtype.StartsWith("SQLite")) providerName = DbProviderNames.SQLite;
                else if (dbtype.StartsWith("System.Data.SqlClient.")) providerName = DbProviderNames.SqlServer;
            }
            if (Options.ContainsKey(providerName))
            {
                cfg.Option = Options[providerName];
            }

            PopulateSqlServer2000(conn, factory, cfg);
            cfg.connection = conn;
            return cfg;
        }

        private static void PopulateSqlServer2000(DbConfiguration cfg, DbProviderFactory factory)
        {
            if (factory is System.Data.SqlClient.SqlClientFactory)
            {
                var connectionStringBuilder = factory.CreateConnectionStringBuilder();
                connectionStringBuilder.ConnectionString = cfg.ConnectionString;
                connectionStringBuilder["Database"] = "master";
                using (var conn = factory.CreateConnection())
                {
                    conn.ConnectionString = connectionStringBuilder.ConnectionString;
                    conn.Open();
                    var serverVersion = conn.ServerVersion;
                    var version = int.Parse(serverVersion.Substring(0, 2));
                    if (version < 9)
                    {
                        InitMsSql2000(cfg);
                    }
                }

            }
        }

        private static void InitMsSql2000(DbConfiguration cfg)
        {
            cfg.Option.Driver = new SqlServer2000Driver();
            cfg.Option.Dialect = new MsSql2000Dialect();
            cfg.Option.ScriptExecutor = () => new SqlServer2000ScriptExecutor();
            cfg.Option.FuncRegistry = new NLite.Data.Dialect.Function.MsSql.MsSqlFunctionRegistry();
            cfg.Option.DbExpressionBuilder = new MsSql2000ExpressionBuilder();
        }

        private static void PopulateSqlServer2000(DbConnection conn, DbProviderFactory factory, DbConfiguration cfg)
        {
            if (factory is System.Data.SqlClient.SqlClientFactory)
            {
                var connectionStringBuilder = factory.CreateConnectionStringBuilder();
                connectionStringBuilder.ConnectionString = cfg.ConnectionString;
                connectionStringBuilder["Database"] = "master";

                var state = conn.State;
                if (state != ConnectionState.Open)
                    conn.Open();

                var serverVersion = conn.ServerVersion;
                if (state != ConnectionState.Open)
                    conn.Close();

                var version = int.Parse(serverVersion.Substring(0, 2));
                if (version < 9)
                    InitMsSql2000(cfg);

            }
        }

    }
}
