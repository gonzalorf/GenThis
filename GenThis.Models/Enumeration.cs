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
        public IList<string> Members { get; set; } = new List<string>();
    }
}