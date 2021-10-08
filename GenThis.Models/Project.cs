using System;
using System.Collections.Generic;
using System.Linq;

namespace GenThis.Models
{
    [Serializable]
    public class Project : Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Namespace> Namespaces { get; set; } = new List<Namespace>();

        public Namespace GetClassNamespace(string id)
        {
            foreach (var ns in Namespaces)
            {
                foreach (var c in ns.Classes)
                {
                    if (c.ID.ToString() == id) return ns;
                }
            }

            return null;
        }

        public Class GetClass(string id)
        {
            foreach (var ns in Namespaces)
            {
                foreach (var c in ns.Classes)
                {
                    if (c.ID.ToString() == id) return c;
                }
            }

            return null;
        }

        public List<Class> GetClasses()
        {
            var classes = new List<Class>();

            foreach (var ns in Namespaces)
            {
                foreach (var c in ns.Classes)
                {
                    classes.Add(c);
                }
            }

            return classes;
        }

        public Enumeration GetEnum(string id)
        {
            foreach (var ns in Namespaces)
            {
                foreach (var e in ns.Enumerations)
                {
                    if (e.ID.ToString() == id) return e;
                }
            }

            return null;
        }

        public List<Enumeration> GetEnums()
        {
            var enums = new List<Enumeration>();

            foreach (var ns in Namespaces)
            {
                foreach (var e in ns.Enumerations)
                {
                    enums.Add(e);
                }
            }

            return enums;
        }

        public List<BuiltInType> GetBuiltInTypes()
        {
            var types = new List<BuiltInType>();

            var values = Enum.GetValues(typeof(BuiltInType)).Cast<BuiltInType>();

            foreach (var t in values)
            {
                types.Add(t);
            }

            return types;
        }        
    }
}