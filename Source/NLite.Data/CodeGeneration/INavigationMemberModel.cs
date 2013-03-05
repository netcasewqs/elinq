using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data.Schema;

namespace NLite.Data.CodeGeneration
{
    public interface INavigationMemberModel
    {
        bool IsManyToOne { get; }
        string DeclareTypeName { get; }
        string MemberName { get;}
        string OtherKeyMemberName { get; }
        IRelationSchema Relation { get; }
    }
}
