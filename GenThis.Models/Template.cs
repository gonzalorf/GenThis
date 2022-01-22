using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenThis.Models
{
    [Serializable]
    public class Template : Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public TemplateTarget Target { get; set; }
        public User Creator { get; set; }
        public bool Public { get; set; }
    }

    public enum TemplateTarget
    {
        Class
        , Property
        , Method
        , Parameter
        , Enumeration
        , Project
    }
}
