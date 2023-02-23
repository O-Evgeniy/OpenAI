using Microsoft.Extensions.Options;

namespace OpenAI.Lib.Abstractions;

public interface IEndpointProvider
{
    string CreateCompletionEndpoint();
}

public class EndpointProvider : IEndpointProvider
{
    private readonly string _apiVersion;

    public EndpointProvider(IOptions<OpenAISettings> options)
    {
        _apiVersion = options.Value.ApiVersion;
    }

    public string CreateCompletionEndpoint() => $"/{_apiVersion}/completions";
}