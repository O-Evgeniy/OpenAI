using OpenAI.Lib;
using OpenAI.Lib.Abstractions;
using OpenAI.Lib.DTO.Requests;
using OpenAI.Lib.DTO.Responses;

namespace OpenAIApi;

public class CompletionClient : ICompletionClient
{
    private readonly HttpClient _client;
    private readonly IEndpointProvider _endpointProvider;

    public CompletionClient(HttpClient client, IEndpointProvider endpointProvider)
    {
        _client = client;
        _endpointProvider = endpointProvider;
    }

    public async Task<CreateCompletionResponse> CreateCompletion(CreateCompletionRequest request,
        CancellationToken cancellationToken)
    {
        return await _client.PostAndProcessAsync<CreateCompletionResponse, CreateCompletionRequest>(
            _endpointProvider.CreateCompletionEndpoint(), request,
            cancellationToken);
    }
}