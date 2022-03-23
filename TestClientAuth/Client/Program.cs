using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using TestClientAuth.Client;
using TestClientAuth.Client.Classes;
using TestClientAuth.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var DefaultApi = builder.Configuration.GetValue<string>("ApiUrl:DefaultApi");

// TODO: Fix HttpClient init
// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7120/") });

if (builder.HostEnvironment.IsDevelopment())
{
    builder.Services.AddHttpClient("TestClientAuth.Server", client => client.BaseAddress = new Uri("https://localhost:7120/"));
}
else
{
    // To Do: Fix for deployment
    builder.Services.AddHttpClient("TestClientAuth.Server", client => client.BaseAddress = new Uri("https://softasinsoftwareapi.azurewebsites.net/"));
}

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();

await builder.Build().RunAsync();
