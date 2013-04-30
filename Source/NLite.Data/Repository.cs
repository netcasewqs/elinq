
namespace NLite.Data
{
    /// <summary>
    /// 仓储
    /// </summary>
    public static class Repository
    {
        /// <summary>
        /// 得到仓储
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbConfigurationName"></param>
        /// <returns></returns>
        public static IRepository<T> Get<T>(string dbConfigurationName)
        {
            Guard.NotNullOrEmpty(dbConfigurationName, "dbConfigurationName");
            return UnitOfWork.Get(dbConfigurationName).CreateRepository<T>();
        }

        /// <summary>
        /// 得到仓储
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IRepository<T> Get<T>()
        {
            return UnitOfWork.Current.CreateRepository<T>();
        }
    }


}
