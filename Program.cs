using M223PunchclockBlazor.Services.EntryService;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MudBlazor.Services;
using M223PunchclockBlazor.Services.AuthService;
using Blazored.LocalStorage;
using M223PunchclockBlazor.Services.UserService;
using M223PunchclockBlazor.Services.ProjectService;
using M223PunchclockBlazor.Services.CategoryService;
using M223PunchclockBlazor.Services.RoleService;

namespace M223PunchclockBlazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddMudServices();
            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddScoped<IEntryService, EntryService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IProjectService, ProjectService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IRoleService, RoleService>();

            await builder.Build().RunAsync();
        }
    }
}
