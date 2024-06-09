using Blazored.LocalStorage;
using Library.Frontend;
using Library.Frontend.Models.Account;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Blazored LocalStorage xizmatini qo'shish
builder.Services.AddBlazoredLocalStorage();

// AuthService xizmatini qo'shish
builder.Services.AddScoped<AuthenticationStateProvider, AuthService>();

// Authentication va Authorization xizmatlarini qo'shish
builder.Services.AddAuthorizationCore();

// Mudblazor xizmatini qo'shish
builder.Services.AddMudServices();

await builder.Build().RunAsync();
