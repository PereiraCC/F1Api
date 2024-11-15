using Microsoft.Extensions.Configuration;
using Formula1Api.Models;
using Formula1Api.DataAccess;
using Microsoft.Data.SqlClient;

namespace Formula1Api.DataAccess;

public class DriversDA {

    private Connection _connetion;
    private string connectionString; 

    public DriversDA(IConfiguration configuration)
    {
        _connetion = new Connection(configuration);
        connectionString = _connetion.connectionString();
    }

    public List<Driver> getAllDrivers() {

        List<Driver> drivers = new List<Driver>();

        if( connectionString == null ) return drivers;

        using (var connection = new SqlConnection(connectionString))
        {
            try
                {
                    connection.Open();

                    // Crear un comando SQL
                    string query = "SELECT D.IDDriver, D.fullname, D.number, D.srcImage, T.fullname FROM dbo.Driver D INNER JOIN dbo.Team T ON T.IDTeam = D.IDTeam;";
                    SqlCommand command = new SqlCommand(query, connection);

                    // Ejecutar el comando y leer los datos
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Leer los datos
                            int id = reader.GetInt32(0);
                            string fullname = reader.GetString(1);
                            string number = reader.GetString(2);
                            string srcImage = reader.GetString(3);
                            string team = reader.GetString(4);

                            Driver driver = new Driver(id, fullname, number, srcImage, team);
                            drivers.Add(driver);
                        }
                    }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error en la conexión o en la consulta: {ex.Message}");
            }
        }

        return drivers;

    }

    public List<Driver> getDriversByTeam(string nameTeam ) {

        List<Driver> drivers = new List<Driver>();

        if( connectionString == null ) return drivers;

        using (var connection = new SqlConnection(connectionString))
        {
            try
                {
                    connection.Open();

                    // Crear un comando SQL
                    string query = "SELECT D.IDDriver, D.fullname, D.number, D.srcImage, T.fullname FROM dbo.Driver D INNER JOIN dbo.Team T ON T.IDTeam = D.IDTeam WHERE T.[Name] = '" + nameTeam + "'";
                    SqlCommand command = new SqlCommand(query, connection);

                    // Ejecutar el comando y leer los datos
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Leer los datos
                            int id = reader.GetInt32(0);
                            string fullname = reader.GetString(1);
                            string number = reader.GetString(2);
                            string srcImage = reader.GetString(3);
                            string team = reader.GetString(4);

                            Driver driver = new Driver(id, fullname, number, srcImage, team);
                            drivers.Add(driver);
                        }
                    }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error en la conexión o en la consulta: {ex.Message}");
            }
        }

        return drivers;

    }

}