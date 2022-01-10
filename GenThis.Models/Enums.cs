using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenThis.Models
{
    public enum TypeKind
    {
        BuiltIn,
        Reference,
        Enumeration,
        Void
    }

    public enum BuiltInType
    {
        String
        , Integer
        , Float
        , Long
        , Double
        , Decimal
        , Bool
        , DateTime
    }

    public enum RelationshipKind
    {
        Association,
        Aggregation,
        Composition
    }

    public enum Accessibility
    {
        Public
        , Protected
        , Internal
        , Private
    }
}
