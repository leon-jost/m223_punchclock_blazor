using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M223PunchclockBlazor.Poco.Auth
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public string Username { get; set; }
    }
}
