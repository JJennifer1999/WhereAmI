using System.Text.Json.Serialization;

namespace CSharpSKA.Service;

public partial class GetIP
{
    public class IpResponse
    {
        [JsonPropertyName("ip")] public string Ip { get; set; }
    }
}