namespace Refit.Named.Client;

[Headers("Content-Type: application/json", "X-RD-Feature: TestNamedClient")]
public interface IAmazonClient
{
    [Get("/details")]
    Task<HttpResponseMessage> Get();
}
