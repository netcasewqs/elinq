using System;
using NLite.Data.Common;

namespace NLite.Data
{
    /// <summary>
    /// 并发操作异常
    /// </summary>
    [Serializable]
    public class ConcurrencyException : PersistenceException
    {
        public readonly OperationType Oparation;
        public readonly object Instance;
        public ConcurrencyException(Object instance, OperationType type)
            : base("Concurrency Exception")
        {
            Instance = instance;
            Oparation = type;
        }
    }

}
