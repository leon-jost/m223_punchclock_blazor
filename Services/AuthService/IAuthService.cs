using M223PunchclockBlazor.Poco.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M223PunchclockBlazor.Services.AuthService
{
    interface IAuthService
    {
        public Task<string> Login(LoginRequest userForAuthentication);
        public Task Logout();
        public Task<string> Register(LoginRequest userToRegister);
    }
}
