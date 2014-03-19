using System;
using NLite.Data.Common;

namespace NLite.Data
{
    /// <summary>
    /// 并发操作异常
    /// </summary>
    [Serializable]
    public class ConcurrencyException : DatabaseException
    {
        public OperationType Oparation { get; private set; }
        public object Instance { get; private set; }

        public ConcurrencyException(Object instance, OperationType type)
            : base("Concurrency Exception")
        {
            Instance = instance;
            Oparation = type;
        }
    }

}
