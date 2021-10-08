using System;

namespace GenThis.Models
{
    [Serializable]
    public class Base
    {
        public Guid ID { get; set; } = Guid.NewGuid();
    }
}