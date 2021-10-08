using System;

namespace GenThis.Models
{
    [Serializable]
    public class EnumerationMember : Base
    {
        public string Name { get; set; }
        public string UIName { get; set; }

    }
}