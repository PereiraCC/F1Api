using Microsoft.Extensions.Configuration;

namespace Formula1Api.DataAccess;

public class Connection {

    private readonly IConfiguration _configuration;

    public Connection(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string connectionString() {

        // Acceder a la variable de entorno
        string? envServer = _configuration["SERVER"];
        string? envDB = _configuration["BD"];
        string? envUser = _configuration["USERBD"];
        string? envPassword = _configuration["PASSWORD"];

        if (envServer != null && envDB != null && envUser != null && envPassword != null)
        {
            return "Server=" + envServer + ";Database="+ envDB + ";User Id=" + envUser + ";Password="+ envPassword + ";TrustServerCertificate=true;";
        }
        else
        {
            Console.WriteLine("Las variables de entorno no estan definidas.");
            return null;
        }

    }

}