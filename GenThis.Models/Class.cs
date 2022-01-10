using System;
using System.Collections.Generic;

namespace GenThis.Models
{
    [Serializable]
    public class Class : Base
    {
        public string Name { get; set; }
        public string UIName { get; set; }
        public string UINamePlural { get; set; }
        public List<Property> Properties { get; set; } = new List<Property>();
        public List<Method> Methods { get; set; } = new List<Method>();
        public Class BaseClass { get; set; }

    }
}