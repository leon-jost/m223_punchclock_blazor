using M223PunchclockBlazor.Poco.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M223PunchclockBlazor.Services.RoleService
{
    interface IRoleService
    {
        public Task<List<Role>> GetRolesAsync();
    }
}
