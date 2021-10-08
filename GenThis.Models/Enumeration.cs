using System;
using System.Collections.Generic;

namespace GenThis.Models
{
    [Serializable]
    public class Enumeration : Base
    {
        public string Name { get; set; }
        public string UIName { get; set; }
        public string UINamePlural { get; set; }
        public List<string> Members { get; set; } = new List<string>();
    }
}