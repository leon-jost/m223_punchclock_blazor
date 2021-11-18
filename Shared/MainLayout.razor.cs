using M223PunchclockBlazor.Services.AuthService;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M223PunchclockBlazor.Shared
{
    public partial class MainLayout
    {
        [Inject]
        private IAuthService AuthService { get; set; }

        [Inject]
        private NavigationManager NavManager { get; set; }

        bool _drawerOpen = true;

        void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }

        public async Task Logout()
        {
            await AuthService.Logout();
            NavManager.NavigateTo("/auth");
        }
    }
}
