using M223PunchclockBlazor.Poco.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M223PunchclockBlazor.Services.UserService
{
    interface IUserService
    {
        public Task<bool> AddUserAsync(PostUser user);
        public Task<List<User>> GetUsersAsync();
        public Task<User> GetUserAsync(int id);
        public Task<bool> UpdateUserAsync(User user);
        public Task<bool> DeleteUserAsync(int id);
    }
}
