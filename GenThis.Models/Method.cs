using System;
using System.Collections.Generic;

namespace GenThis.Models
{
    [Serializable]
    public class Method : Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsVirtual { get; set; }
        public bool IsStatic { get; set; }
        public Accessibility Accessibility { get; set; }
        public TypeKind ReturnTypeKind { get; set; }
        public Class ReferenceReturnType { get; set; }
        public BuiltInType BuiltInReturnType { get; set; }
        public Enumeration EnumReturnType { get; set; }
        public bool IsRetunTypeList { get; set; }
        public IList<Parameter> Parameters { get; set; } = new List<Parameter>();

        public void Validate()
        {
            switch (ReturnTypeKind)
            {
                case TypeKind.BuiltIn:
                    break;
                case TypeKind.Reference:
                    if (ReferenceReturnType == null) throw new ApplicationException("Reference Type not set.");
                    break;
                case TypeKind.Enumeration:
                    if (EnumReturnType == null) throw new ApplicationException("Enumeration Type not set.");
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

            switch (ReturnTypeKind)
            {
                case TypeKind.BuiltIn:
                    type = BuiltInReturnType.ToString();
                    break;
                case TypeKind.Reference:
                    type = ReferenceReturnType.Name;
                    break;
                case TypeKind.Enumeration:
                    type = EnumReturnType.Name;
                    break;
            }

            string isList = IsRetunTypeList ? "List of " : " ";
            return string.Format("{0}{1} {2} {3} {4}()", Accessibility, IsStatic ? " Static" : "", isList, type, Name);
        }
        public string GetTypeName()
        {
            string type = string.Empty;

            switch (ReturnTypeKind)
            {
                case TypeKind.BuiltIn:
                    if (BuiltInReturnType == BuiltInType.DateTime) type = BuiltInReturnType.ToString();
                    else type = BuiltInReturnType.ToString().ToLower();
                    break;
                case TypeKind.Reference:
                    type = ReferenceReturnType.Name;
                    break;
                case TypeKind.Enumeration:
                    type = EnumReturnType.Name;
                    break;
            }

            var format = "{0}";
            return string.Format(format, type);
        }
    }
}