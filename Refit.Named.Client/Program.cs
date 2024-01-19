using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Refit.Named.Client;

internal class Program
{
    static async Task Main(string[] args)
    {
        var apiSettings = new Dictionary<string, string>()
        {
            {
                "IN","https://www.amazon.co.in"
            },
             {
                "UK","https://www.amazon.co.uk"
            }
        };
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

        foreach (var pair in apiSettings)
        {
            builder.Services.AddRefitClient<IAmazonClient>(null, pair.Key)
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(pair.Value));
        }

        builder.Services.AddHostedService<HostedService>();

        using IHost host = builder.Build();

        await host.RunAsync();

        var client = host.Services.GetRequiredService<IAmazonClient>();
    }
}
