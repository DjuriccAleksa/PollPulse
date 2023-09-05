using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PollPulse.Web;
using PollPulse.Web.Authentication;
using PollPulse.Web.OptionsSetup.ApplicationOptions;
using PollPulse.Web.Services.Contracts;
using PollPulse.Web.Services.Implementations;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

builder.Services.ConfigureOptions<ApplicationConfigSetup>();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetSection("AppParameteres")["apiUrl"])});

await builder.Build().RunAsync();
