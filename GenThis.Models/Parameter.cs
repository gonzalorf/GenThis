using System;

namespace GenThis.Models
{
    [Serializable]
    public class Parameter:Base
    {
        public string Name { get; set; }
        public TypeKind ReturnTypeKind { get; set; }
        public Class ReferenceReturnType { get; set; }
        public BuiltInType BuiltInReturnType { get; set; }
        public Enumeration EnumReturnType { get; set; }
    }
}