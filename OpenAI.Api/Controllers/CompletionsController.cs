using Microsoft.AspNetCore.Mvc;
using OpenAI.Lib.Abstractions;
using OpenAI.Lib.DTO.Requests;
using OpenAI.Lib.DTO.Responses;

namespace OpenAIApi.Controllers;

[Produces("application/json")]
[Route("[controller]")]
[ApiController]
public class CompletionsController : ControllerBase
{
   private readonly ICompletionClient _client;

   public CompletionsController(ICompletionClient client)
   {
      _client = client;
   }

   [HttpPost]
   public async Task<CreateCompletionResponse> CreateCompletion(CreateCompletionRequest request)
   {
      return await _client.CreateCompletion(request, HttpContext.RequestAborted);
   }
}