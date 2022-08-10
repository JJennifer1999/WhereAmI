namespace CSharpSKA.Service;

public interface IGetCountryCode
{
    Task<string> GetMyCountryCode(string ip);
}