using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NLite.Reflection;

namespace NLite.Data
{
    /// <summary>
    /// 活动记录
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ActiveRecord<T>
        where T : ActiveRecord<T>
    {

        static string DbConfigurationName;
        static bool hasInited;

        static void Init()
        {
            var attr = typeof(T).GetAttribute<DbContextAttribute>(true);
            if (attr != null)
                DbConfigurationName = attr.DbConfigurationName;
            else
            {
                var cfg = DbConfiguration.DefaultDbConfiguration;
                if (cfg == null)
                    throw new InvalidOperationException("Not set DefaultUnitOfWorkName or no set default DbConfiguration ");
                DbConfigurationName = cfg.Name;
            }
            hasInited = true;
        }

        static IRepository<T> InnerRepository
        {
            get
            {
                if (!hasInited)
                    Init();
                return Repository.Get<T>(DbConfigurationName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static IOrderedQueryable<T> Queryable
        {
            get
            {
                return InnerRepository;
            }
        }

        /// <summary>
        /// 通过实体Id获取对应的实体，id可以是单Id也可以是联合Id，如果是联合Id那么以数组的形式作为参数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T Get(object id)
        {
            Guard.NotNull(InnerRepository, "Repository");
            return InnerRepository.Get(id);
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="instance">支持PO、POCO、IDictionary、IDictionaryOfKV, NameValueCollection 类型</param>
        /// <returns></returns>
        public static int Save(object instance)
        {
            Guard.NotNull(InnerRepository, "Repository");
            return InnerRepository.Insert(instance);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="instance">支持PO、POCO、IDictionary、IDictionaryOfKV, NameValueCollection 类型</param>
        /// <returns></returns>
        public static int Update(object instance)
        {
            return InnerRepository.Update(instance);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static int Delete(object instance)
        {
            return InnerRepository.Delete(instance);
        }

        /// <summary>
        /// 插入并根据Lambda表达式返回特定信息
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="instance"></param>
        /// <param name="resultSelector"></param>
        /// <returns></returns>
        public static S Save<S>(object instance, Expression<Func<T, S>> resultSelector)
        {
            return InnerRepository.Insert<S>(instance, resultSelector);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="instance">支持PO、POCO、IDictionary、IDictionaryOfKV, NameValueCollection 类型</param>
        /// <param name="updateCheck">除了id条件之外的附加条件</param>
        /// <returns></returns>
        public static int Update(object instance, Expression<Func<T, bool>> updateCheck)
        {
            return InnerRepository.Update(instance, updateCheck);
        }

        /// <summary>
        /// 更新并根据Lambda表达式返回特定信息
        /// </summary>
        /// <param name="instance">支持PO、POCO、IDictionary、IDictionaryOfKV, NameValueCollection 类型</param>
        /// <param name="updateCheck">除了id条件之外的附加条件</param>
        /// <param name="resultSelector"></param>
        /// <returns></returns>
        public static S Update<S>(object instance, Expression<Func<T, bool>> updateCheck, Expression<Func<T, S>> resultSelector)
        {
            return InnerRepository.Update<S>(instance, updateCheck, resultSelector);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="deleteCheck">除了id条件之外的附加条件</param>
        /// <returns></returns>
        public static int Delete(object instance, Expression<Func<T, bool>> deleteCheck)
        {
            return InnerRepository.Delete(instance, deleteCheck);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static int Delete(Expression<Func<T, bool>> predicate)
        {
            return InnerRepository.Delete(predicate);
        }


        /// <summary>
        /// 根据Lambda表达式对实体集合进行批量操作
        /// </summary>
        /// <param name="instances"></param>
        /// <param name="fnOperation"></param>
        /// <returns></returns>
        public static IEnumerable<int> Batch<M>(IEnumerable<M> instances, Expression<Func<IRepository<T>, M, int>> fnOperation)
        {
            return InnerRepository.Batch<M>(instances, fnOperation);
        }
    }
}
