using System.Text.Json.Serialization;

namespace CSharpSKA.Service;

public partial class GetCountryCode
{
    public class CountryCodeRequest
    {
        [JsonPropertyName("query")] public string Query { get; set; }

        [JsonPropertyName("fields")] public string Fields { get; set; }

        [JsonPropertyName("lang")] public string Language { get; set; }
    }
}