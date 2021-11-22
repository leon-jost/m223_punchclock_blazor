using M223PunchclockBlazor.Poco.User;
using M223PunchclockBlazor.Services.RoleService;
using M223PunchclockBlazor.Services.UserService;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M223PunchclockBlazor.Pages
{
    public partial class ManageUsers
    {
        [Inject]
        private IUserService UserService { get; set; }
        [Inject]
        private IRoleService RoleService { get; set; }

        private List<User> _users;
        private List<Poco.Role.Role> _roles;

        private PostUser _newUser = new() { role = new() };

        protected async override Task OnInitializedAsync()
        {
            _users = await UserService.GetUsersAsync();
            _roles = await RoleService.GetRolesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            await UserService.DeleteUserAsync(user.id);
            _users = await UserService.GetUsersAsync();
        }

        public async Task AddUserAsync(PostUser user)
        {
            await UserService.AddUserAsync(user);
            _users = await UserService.GetUsersAsync();
        }
    }
}