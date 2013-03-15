using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Collections;
using NLite.Data.Dialect;
using NLite.Reflection;
using NLite.Data.Linq.Internal;
using NLite.Collections;
using NLite.Linq;
using System.Diagnostics;

namespace NLite.Data.Mapping
{
    [DebuggerDisplay("TableName:{tableName},EntityType:{entityType.Name}")]
    class EntityMapping : IEntityMapping
    {
        internal Type entityType;
        internal Dictionary<string, MemberMapping> mappingMembers;
        internal MemberMapping[] innerMappingMembers;
        internal IMemberMapping[] primairyKeys;

        // internal Func<Type, EntityModel> getEntity;
        internal string serverName;
        internal string databaseName;
        internal string tableName;
        internal bool @readonly;
        internal string schema;
        internal MemberMapping version;

        public IMemberMapping Version { get { return version; } }

        public string ServerName { get { return serverName; } }
        public string DatabaseName { get { return databaseName; } }
        public string Schema { get { return schema; } }
        public string TableName
        {
            get { return tableName; }
        }

        public Type EntityType
        {
            get { return this.entityType; }
        }

        public IMemberMapping[] Members
        {
            get
            {
                return innerMappingMembers;
            }
        }

        internal MemberMapping GetMappingMember(string name)
        {
            MemberMapping mm = null;
            if (!this.mappingMembers.TryGetValue(name, out mm))
                mm = mappingMembers.FirstOrDefault(p => string.Equals(p.Key, name, StringComparison.CurrentCultureIgnoreCase)).Value;
            return mm;
        }



        public IMemberMapping Get(MemberInfo member)
        {
            return GetMappingMember(member.Name);
        }

        public IMemberMapping[] PrimaryKeys
        {
            get { return primairyKeys; }
        }



        public bool IsRelationship(MemberInfo member)
        {
            var mm = GetMappingMember(member.Name);
            return mm != null && mm.isRelationship;
        }
    }
}
