using Branding.DynamicComponents.ResolveByContract;
using Branding.DynamicComponents.ResolveByName;
using Catalog.Razor.ResolveByContractProviders;
using Catalog.Razor.ResolveByNameProviders;
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

            builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<DynamicComponentFactory>();
            builder.Services.AddScoped<IProvideDynamicComponent, OrderTableHeaderDynamicComponentProvider>();
            builder.Services.AddScoped<IProvideDynamicComponent, OrderTableRowDynamicComponentProvider>();

            builder.Services.AddScoped<DynamicComponentPlacementFactory>();
            builder.Services.AddScoped<IProvideDynamicComponentPlacement, SalesOrderTableHeaderDynamicComponentContractProvider>();
            builder.Services.AddScoped<IProvideDynamicComponentPlacement, SalesOrderTableRowDynamicComponentContractProvider>();
            builder.Services.AddScoped<IProvideDynamicComponentPlacement, SalesOrderCardDynamicComponentContractProvider>();

            await builder.Build().RunAsync();
        }
    }
}