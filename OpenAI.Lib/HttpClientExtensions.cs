using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenAI.Lib;

public static class HttpClientExtensions
{
    public static async Task<TResponse> PostAndProcessAsync<TResponse, TRequest>(this HttpClient client, string uri,
        TRequest request,
        CancellationToken cancellationToken)
    {
        // var httpRequest = new StringContent(JsonSerializer.Serialize(request), Encoding.Default, "application/json");
        var response = await client.PostAsJsonAsync(uri, request, new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
            PropertyNameCaseInsensitive = true
        }, cancellationToken);
        
        return await response.Content.ReadFromJsonAsync<TResponse>(cancellationToken: cancellationToken) ??
               throw new InvalidOperationException();
    }
}