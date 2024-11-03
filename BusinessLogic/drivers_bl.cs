using Formula1Api.Models;
using Formula1Api.DataAccess;

namespace Formula1Api.BusinessLogic;

public class DriversBL {

    private DriversDA _driversDA;

    public DriversBL(IConfiguration configuration)
    {
        _driversDA = new DriversDA(configuration);
    }

    public List<Driver> getAllDrivers() {
        return _driversDA.getAllDrivers();
    }

    public List<Driver> getDriversByTeam(string nameTeam) {
        return _driversDA.getDriversByTeam(nameTeam);
    }

}