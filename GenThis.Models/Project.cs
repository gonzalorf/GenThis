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
        public User Owner { get; set; }
        public bool IsPublic { get; set; }

        public Namespace GetClassNamespace(string id)
        {
            foreach (var ns in Namespaces)
            {
                foreach (var c in ns.Classes)
                {
                    if (c.Id.ToString() == id) return ns;
                }
            }

            return null;
        }

        public Class GetClass(Guid id)
        {
            foreach (var ns in Namespaces)
            {
                foreach (var c in ns.Classes)
                {
                    if (c.Id == id) return c;
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

        public Enumeration GetEnumeration(Guid id)
        {
            foreach (var ns in Namespaces)
            {
                foreach (var e in ns.Enumerations)
                {
                    if (e.Id == id) return e;
                }
            }

            return null;
        }

        public List<Enumeration> GetEnumerations()
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