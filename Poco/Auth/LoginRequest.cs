using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace M223PunchclockBlazor.Poco.Auth
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Email is required.")]
        public string username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string password { get; set; }
    }
}
