
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenThis.Models
{
    public class APIResult<T>
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public T ReturnData { get; set; }
    }
}
