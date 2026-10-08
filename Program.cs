using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ReforaTec;
using ReforaTec.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// 1. Registrar TokenService
builder.Services.AddScoped<TokenService>();

// 2. Registrar el Handler de autenticación
builder.Services.AddTransient<AuthMessageHandler>();

// 3. Registrar HttpClient con nombre + Handler
builder.Services.AddHttpClient("ReforaTecApi", client =>
{
    client.BaseAddress = new Uri("http://reforatec-api.onrender.com");
})
.AddHttpMessageHandler<AuthMessageHandler>();

// 4. Registrar el servicio API
builder.Services.AddScoped<IReforaTecApiService, ReforaTecApiService>();

await builder.Build().RunAsync();