using M223PunchclockBlazor.Poco.Auth;
using M223PunchclockBlazor.Services.AuthService;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M223PunchclockBlazor.Pages
{
    public partial class Login
    {
        [Inject]
        private IAuthService AuthService { get; set; }

        [Inject]
        private NavigationManager NavManager { get; set; }

        private LoginRequest model = new();

        private bool showAuthenticationError = false;
        private string authenticationErrorText = "";

        private async Task ExecuteLogin()
        {
            showAuthenticationError = false;

            string result = await AuthService.Login(model);

            if (result is not null)
            {
                NavManager.NavigateTo("/");
            }
            else
            {
                authenticationErrorText = "There was an error when trying to log in.";
                showAuthenticationError = true;
            }
        }

        private async Task Register()
        {
            showAuthenticationError = false;

            string result = await AuthService.Register(model);

            if (result is not null)
            {
                NavManager.NavigateTo("/");
            }
            else
            {
                authenticationErrorText = "There was an error when trying to sign up.";
                showAuthenticationError = true;
            }
        }
    }
}
