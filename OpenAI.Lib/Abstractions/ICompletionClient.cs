using OpenAI.Lib.DTO.Requests;
using OpenAI.Lib.DTO.Responses;

namespace OpenAI.Lib.Abstractions;

public interface ICompletionClient
{
    Task<CreateCompletionResponse> CreateCompletion(CreateCompletionRequest request,
        CancellationToken cancellationToken);
}