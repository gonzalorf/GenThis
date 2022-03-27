using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace GenThis.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

#if DEBUG
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44341/") });
#else
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://genthisapi-f1.azurewebsites.net/") });
#endif
            builder.Services.AddBlazoredLocalStorage();

            await builder.Build().RunAsync();
        }
    }
}
