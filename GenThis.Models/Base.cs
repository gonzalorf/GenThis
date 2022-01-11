using Newtonsoft.Json;
using System;

namespace GenThis.Models
{
    [Serializable]
    public class Base
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}