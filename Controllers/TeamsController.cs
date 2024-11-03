using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Formula1Api.BusinessLogic;
using Formula1Api.Models;

namespace Formula1Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamsController : ControllerBase
{
    private readonly ILogger<TeamsController> _logger;
    private readonly IConfiguration _configuration;

    private TeamsBL _teamsBL;

    public TeamsController(ILogger<TeamsController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
        _teamsBL = new TeamsBL(configuration);
    }

    [HttpGet("GetAllTeams")]
    public List<Team> GetAllTeams()
    {
        return _teamsBL.getAllTeams();
    }
    
    [HttpGet("GetOneTeam")]
    public Team GetOneTeam([FromBody] string nameTeam)
    {
        return _teamsBL.getOneTeam(nameTeam);
    }
}
