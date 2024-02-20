using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFGE.Models
{
    public class DefaultResponse<T>
    {
        public required string Message { get; set; }
        public required T Data { get; set; }
        public required bool Success { get; set; }
        public required int StatusCode { get; set; }
        public required string MessageType { get; set;}
    }
}