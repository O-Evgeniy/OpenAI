using System.Text.Json.Serialization;

namespace OpenAI.Lib.DTO.Responses;

public record LogProbsResponse
{
    public IReadOnlyCollection<string> Tokens { get; set; }

    [JsonPropertyName("token_logprobs")] public IReadOnlyCollection<double> TokenLogProbs { get; set; }

    [JsonPropertyName("top_logprobs")]
    public IReadOnlyCollection<Dictionary<string, double>> TopLogProbsRaw { get; set; }


    [JsonPropertyName("text_offset")] public IReadOnlyCollection<int> TextOffset { get; set; }
}