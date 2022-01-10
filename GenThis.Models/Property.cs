using System;

namespace GenThis.Models
{
    [Serializable]
    public class Property : Base
    {
        public string Name { get; set; }
        public string UIName { get; set; }
        public TypeKind TypeKind { get; set; }
        public RelationshipKind RelationshipKind { get; set; }
        public Class ReferenceType { get; set; }
        public BuiltInType BuiltInType { get; set; }
        public Enumeration EnumerationType { get; set; }
        public bool IsNullable { get; set; } = true;
        public bool IsList { get; set; }
        public bool PreventLazyLoad { get; set; }
        public bool IsUnique { get; set; }

        public void Validate()
        {
            switch (TypeKind)
            {
                case TypeKind.BuiltIn:
                    break;
                case TypeKind.Reference:
                    if (ReferenceType == null) throw new ApplicationException("Reference Type not set.");
                    break;
                case TypeKind.Enumeration:
                    if (EnumerationType == null) throw new ApplicationException("Enumeration Type not set.");
                    break;
                case TypeKind.Void:
                    break;
                default:
                    break;
            }
        }

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
                case TypeKind.Enumeration:
                    type = EnumerationType.Name;
                    break;
            }

            string nullable = IsNullable ? "(nullable)" : "";
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
                case TypeKind.Enumeration:
                    type = EnumerationType.Name;
                    break;
            }

            var format = IsList ? "List<{0}>" : "{0}";
            return string.Format(format, type);
        }
    }
}