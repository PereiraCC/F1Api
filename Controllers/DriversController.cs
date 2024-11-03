using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Formula1Api.BusinessLogic;
using Formula1Api.Models;

namespace Formula1Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DriversController : ControllerBase
{
    private readonly ILogger<DriversController> _logger;
    private readonly IConfiguration _configuration;

    private DriversBL _driversBL;

    public DriversController(ILogger<DriversController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
        _driversBL = new DriversBL(configuration);
    }

    [HttpGet("GetAllDrivers")]
    public List<Driver> GetAllDrivers()
    {
        return _driversBL.getAllDrivers();
    }
    
    [HttpGet("GetDriversByTeam")]
    public List<Driver> GetDriversByTeam([FromBody] string nameTeam)
    {
        return _driversBL.getDriversByTeam(nameTeam);
    }
}
