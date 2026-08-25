using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ReforaTec;
using ReforaTec.Services; // <-- Agrega este using

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configuración del HttpClient
builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri("http://reforatec-api.onrender.com") 
});

// Registro del servicio API
builder.Services.AddScoped<IReforaTecApiService, ReforaTecApiService>(); // <-- Agrega esta línea

await builder.Build().RunAsync();