using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Formula1Api.DataAccess;

namespace Formula1Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamsController : ControllerBase
{
    private readonly ILogger<TeamsController> _logger;
    private readonly IConfiguration _configuration;

    public TeamsController(ILogger<TeamsController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    [HttpGet("GetAllTeams")]
    public IEnumerable<string> GetAllTeams()
    {
        Connection connection = new Connection(_configuration);
        Console.WriteLine(connection.connectionString());
        return new List<string>() {
            "Ferrari", "RedBull", "Mercedes"
        };
    }
}
