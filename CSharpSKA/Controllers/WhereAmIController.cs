using CSharpSKA.Service;
using Microsoft.AspNetCore.Mvc;

namespace CSharpSKA.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WhereAmIController : ControllerBase
{
    private readonly ILogger<WhereAmIController> _logger;
    private readonly IGetCountryCode _getCountryCode;
    private readonly IGetIP _getIp;

    public WhereAmIController(ILogger<WhereAmIController> logger, IGetCountryCode getCountryCode, IGetIP getIp)
    {
        _logger = logger;
        _getCountryCode = getCountryCode;
        _getIp = getIp;
    }

    [HttpGet]
    public async Task<WhereAmIViewModel> Get()
    {
        var ip = await _getIp.GetMyIP();
        var countryCode = await _getCountryCode.GetMyCountryCode(ip);
        return new WhereAmIViewModel
        {
            Ip = ip,
            CountryCode = countryCode
        };
    }
}