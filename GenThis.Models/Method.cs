using System;
using System.Collections.Generic;

namespace GenThis.Models
{
    [Serializable]
    public class Method : Base
    {
        public string Name { get; set; }
        public bool IsVirtual { get; set; }
        public bool IsStatic { get; set; }
        public Accessibility Accessibility { get; set; }
        public TypeKind ReturnTypeKind { get; set; }
        public Class ReferenceReturnType { get; set; }
        public BuiltInType BuiltInReturnType { get; set; }
        public Enumeration EnumReturnType { get; set; }
        public List<Parameter> Parameters { get; set; } = new List<Parameter>();

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

            return string.Format("{0}{1} {2} {3}()", Accessibility, IsStatic ? " Static" : "", type, Name);
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