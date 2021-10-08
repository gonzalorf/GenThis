using System;

namespace GenThis.Models
{
    [Serializable]
    public class Property : Base
    {
        public string Name { get; set; }
        public string UIName { get; set; }
        public string UINamePlural { get; set; }
        public TypeKind TypeKind { get; set; }
        public RelationshipKind RelationshipKind { get; set; }
        public Class ReferenceType { get; set; }
        public BuiltInType BuiltInType { get; set; }
        public Enumeration EnumType { get; set; }
        public bool Nullable { get; set; } = true;
        public bool IsList { get; set; }
        public bool PreventLazyLoad { get; set; }
        public bool IsUnique { get; set; }

        public override string ToString()
        {
            string type = string.Empty;

            switch (TypeKind)
            {
                case TypeKind.BuiltIn:
                    type = BuiltInType.ToString();
                    break;
                case TypeKind.Reference:
                    type = ReferenceType.Name;                    
                    break;
                case TypeKind.Enum:
                    type = EnumType.Name;
                    break;
            }

            string nullable = Nullable ? "(nullable)" : "";
            string list = IsList ? "List of " : " ";
            return string.Format("{0}: {1}{2} {3}", Name, list, type, nullable);
        }

        public string GetTypeName()
        {
            string type = string.Empty;

            switch (TypeKind)
            {
                case TypeKind.BuiltIn:
                    if (BuiltInType == BuiltInType.DateTime) type = BuiltInType.ToString();
                    else type = BuiltInType.ToString().ToLower();
                    break;
                case TypeKind.Reference:
                    type = ReferenceType.Name;
                    break;
                case TypeKind.Enum:
                    type = EnumType.Name;
                    break;
            }

            var format = IsList ? "List<{0}>" : "{0}";
            return string.Format(format, type);
        }
    }

    public enum TypeKind
    {
        BuiltIn,
        Reference,
        Enum,
        Void
    }

    public enum BuiltInType
    {
        String
        , Int
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