using System.Text.Json.Serialization;

namespace OpenAI.Lib.DTO.Responses;

public class CreateCompletionResponse
{
    public string Id { get; set; }
    public string Object { get; set; }
    public int CreatedAt { get; set; }
    public string Model { get; set; }
    public IList<Choice> Choices { get; set; }
}

public class Choice
{
    public string Text { get; set; }
    public int Index { get; set; }
    [JsonPropertyName("finish_reason")] public string FinishReason { get; set; }
    public LogProbsResponse LogProbs { get; set; }
}