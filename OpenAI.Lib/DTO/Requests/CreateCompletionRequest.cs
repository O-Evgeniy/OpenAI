using System.Text.Json.Serialization;

namespace OpenAI.Lib.DTO.Requests;

public class CreateCompletionRequest
{
    [JsonPropertyName("model")] public string Model { get; set; } = string.Empty;

    [JsonPropertyName("prompt")] public string? Prompt { get; set; }

    //public string? Suffix { get; set; } = null;
    [JsonPropertyName("temperature")] public double Temperature { get; set; } = 1;
    [JsonPropertyName("n")] public int N { get; set; } = 1;
    [JsonPropertyName("stop")] public string? Stop { get; set; } = null;
    [JsonPropertyName("stream")] public bool? Stream { get; set; }
    [JsonPropertyName("logprobs")] public int? LogProbs { get; set; }

    [JsonPropertyName("echo")] public bool Echo { get; set; } = false;
    // [JsonIgnore]
    // [JsonPropertyName("stop")]
    // public IReadOnlyCollection<string>? StopCollection { get; set; } = null!;

    [JsonPropertyName("top_p")] public double TopP { get; set; } = 1;
    [JsonPropertyName("max_tokens")] public int MaxTokens { get; set; } = 1;

    // [JsonIgnore]
    // [JsonPropertyName("prompt")]
    // public IReadOnlyCollection<string>? PromtCollection { get; set; }
}