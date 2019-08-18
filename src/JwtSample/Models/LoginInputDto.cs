using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtSample.Models
{
    public class LoginInputDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
