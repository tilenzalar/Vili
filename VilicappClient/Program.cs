using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using VilicappAPI;
using Microsoft.AspNetCore.Components.Authorization;
using VilicappClient.BusinessLogic;
using MudBlazor.Services;
using System.Globalization;
using System.Threading;

namespace VilicappClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("sl-SI");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("sl-SI");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("sl-SI");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("sl-SI");

            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddBlazoredSessionStorage();
            builder.Services.AddScoped<AppState>();
            builder.Services.AddMudServices();
            builder.Services.AddOptions();
            builder.Services.AddAuthenticationCore();
            builder.Services.AddAuthorizationCore();
        

            var appstate = builder.Services.BuildServiceProvider().GetService<AppState>();
            builder.Services.AddSingleton(appstate);

            var apiURL = builder.Configuration["urlAPI"];
            builder.Services.AddSingleton(service =>
            {
                var x = new UsersClient(apiURL, new HttpClient());
                x.SetAppState(appstate);
                return x;
            });

            builder.Services.AddSingleton(service =>
            {
                var x = new WorkOrderClient(apiURL, new HttpClient());
                x.SetAppState(appstate);
                return x;
            });

            builder.Services.AddSingleton(service =>
            {
                var x = new ForkLiftClient(apiURL, new HttpClient());
                x.SetAppState(appstate);
                return x;
            });

            await builder.Build().RunAsync();
        }
    }
}
