using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace CSharpSKA.Service;

public partial class GetCountryCode : IGetCountryCode
{
    private const string Uri = "http://ip-api.com/batch";
    private readonly ILogger<GetCountryCode> _logger;
    private readonly HttpClient _httpClient = new HttpClient();

    public GetCountryCode(ILogger<GetCountryCode> logger)
    {
        _logger = logger;
    }

    public async Task<string> GetMyCountryCode(string ip)
    {
        var request = new List<CountryCodeRequest>()
        {
            new CountryCodeRequest { Query = ip, Fields = "countryCode", Language = "en" }
        };
        var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(Uri, content);
        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("status code:{statusCode},request{request}", response.StatusCode,
                JsonSerializer.Serialize(request));
        }

        var responseStr = await response.Content.ReadAsStringAsync();
        var countryCodeResponse = JsonSerializer.Deserialize<List<CountryCodeResponse>>(responseStr);
        if (countryCodeResponse == null || !countryCodeResponse.Any())
            _logger.LogError(" parse response error, returned empty array.");
        return countryCodeResponse.First().CountryCode;
    }
}