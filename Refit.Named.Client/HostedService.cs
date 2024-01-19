using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;

namespace Refit.Named.Client;
public class HostedService : IHostedService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HostedService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var client = _httpClientFactory.CreateClient("IN");

        var amazonClient = RestService.For<IAmazonClient>("IN");

        var response = amazonClient.Get();

        await Task.Delay(1000);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(1000);
    }
}
