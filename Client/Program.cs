using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

string enderecoDoServidorWebApi = "https://localhost:7121";

builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri(enderecoDoServidorWebApi) 
});

await builder.Build().RunAsync();
