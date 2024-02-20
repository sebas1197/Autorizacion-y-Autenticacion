using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFGE.Models
{
    public class Login
    {
        public required string log_username { get; set; }
        
        public required string log_password { get; set; }
    }
}