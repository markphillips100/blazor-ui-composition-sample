using Branding.DynamicComponents.ResolveByName;
using Branding.DynamicComponents.ResolveByPlacementContract;
using Catalog.Razor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace WebApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<DynamicComponentFactory>();
            builder.Services.AddScoped<IProvideDynamicComponent, OrderProductInfoDynamicComponentProvider>();

            builder.Services.AddScoped<DynamicComponentPlacementFactory>();
            builder.Services.AddScoped<IProvideDynamicComponentPlacement, SalesOrderProductTableHeaderDynamicComponentContractResolver>();
            builder.Services.AddScoped<IProvideDynamicComponentPlacement, SalesOrderProductTableRowDynamicComponentContractResolver>();

            await builder.Build().RunAsync();
        }
    }
}