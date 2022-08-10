namespace CSharpSKA.Service;

public interface IGetIP
{
    Task<string> GetMyIP();
}