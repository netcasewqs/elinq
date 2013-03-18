using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Threading;

namespace NLite.Data
{

    /// <summary>
    /// 工作单元门面类
    /// </summary>
    public static class UnitOfWork
    {
        static string DbConfigurationName { get; set; }

        /// <summary>
        /// 得到当前工作单元对象
        /// </summary>
        public static IUnitOfWork Current
        {
            get
            {
                if (string.IsNullOrEmpty(UnitOfWork.DbConfigurationName))
                {
                    var cfg = DbConfiguration.DefaultDbConfiguration;
                    if (cfg == null)
                        cfg = DbConfiguration.Configure();
                    UnitOfWork.DbConfigurationName = cfg.Name;
                }

                return Get(UnitOfWork.DbConfigurationName);
            }
        }

        /// <summary>
        /// 得到工作单元对象
        /// </summary>
        /// <param name="dbConfigurationName"></param>
        /// <returns></returns>
        public static IUnitOfWork Get(string dbConfigurationName)
        {
            Guard.NotNullOrEmpty(dbConfigurationName, "dbConfigurationName");


            var key = string.Concat("__", dbConfigurationName, "__");
            var ctx = NLite.Threading.Local.Get(key) as IUnitOfWork;
            if (ctx == null)
            {
                var cfg = DbConfiguration.Get(dbConfigurationName);
                ctx = cfg.CreateDbContext() as IUnitOfWork;
                NLite.Threading.Local.Set(key, ctx);
            }

            return ctx;
        }
        /// <summary>
        /// 释放工作单元资源
        /// </summary>
        public static void Dispose()
        {
            foreach (var name in DbConfiguration.Items.Keys)
            {
                var key = string.Concat("__", name, "__");
                var ctx = Local.Get(key) as IDbContext;
                if (ctx != null)
                {
                    Local.Remove(key);
                    ctx.Dispose();
                }
            }
        }
    }

}
