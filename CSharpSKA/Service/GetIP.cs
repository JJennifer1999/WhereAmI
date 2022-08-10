using System.Text.Json;

namespace CSharpSKA.Service;

public partial class GetIP : IGetIP
{
    private const string Uri = "https://api.ipify.org?format=json";

    private readonly HttpClient _httpClient = new HttpClient();

    public async Task<string> GetMyIP()
    {
        var responseStr = await _httpClient.GetStringAsync(Uri);
        var ipResponse = JsonSerializer.Deserialize<IpResponse>(responseStr);
        return ipResponse.Ip;
    }
}