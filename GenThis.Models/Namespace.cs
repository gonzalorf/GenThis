using System;
using System.Collections.Generic;

namespace GenThis.Models
{
    [Serializable]
    public class Namespace : Base
    {
        public string Name { get; set; }
        public List<Class> Classes { get; set; } = new List<Class>();
        public List<Enumeration> Enumerations { get; set; } = new List<Enumeration>();
    }
}