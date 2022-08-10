using System.Text.Json.Serialization;

namespace CSharpSKA.Service;

public partial class GetCountryCode
{
    public class CountryCodeResponse
    {
        [JsonPropertyName("countryCode")] public string CountryCode { get; set; }
    }
}