using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OpenAI.Lib;
using OpenAI.Lib.Abstractions;

namespace OpenAIApi;

public static class Bootstrapper
{
    public static IServiceCollection AddOpenAI(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<OpenAISettings>(configuration.GetRequiredSection("OpenAISettings"));
        services.AddHttpClient("OpenAiClient", (provider, client) =>
            {
                var settings = provider.GetRequiredService<IOptions<OpenAISettings>>().Value;
                client.BaseAddress = new Uri(settings.BaseUrl);
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {settings.ApiKey}");
            })
            .AddTypedClient<ICompletionClient, CompletionClient>();
        return services;
    }
}