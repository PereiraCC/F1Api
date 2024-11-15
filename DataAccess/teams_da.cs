using Microsoft.Extensions.Configuration;
using Formula1Api.Models;
using Formula1Api.DataAccess;
using Microsoft.Data.SqlClient;

namespace Formula1Api.DataAccess;

public class TeamsDA {

    private Connection _connetion;
    private string connectionString; 

    public TeamsDA(IConfiguration configuration)
    {
        _connetion = new Connection(configuration);
        connectionString = _connetion.connectionString();
    }

    public List<Team> getAllTeams() {

        List<Team> teams = new List<Team>();

        if( connectionString == null ) return teams;

        using (var connection = new SqlConnection(connectionString))
        {
            try
                {
                    connection.Open();

                    // Crear un comando SQL
                    string query = "SELECT * FROM Team";
                    SqlCommand command = new SqlCommand(query, connection);

                    // Ejecutar el comando y leer los datos
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Leer los datos
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string fullname = reader.GetString(2);
                            string chasis = reader.GetString(3);
                            string motor = reader.GetString(4);
                            string srcImage = reader.GetString(5);

                            // List<Driver> drivers = getDrivers(id);

                            Team team = new Team(id, name, fullname, chasis, motor, srcImage);
                            teams.Add(team);
                        }
                    }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error en la conexión o en la consulta: {ex.Message}");
            }
        }

        return teams;

    }

    public Team getOneTeam(string nameTeam ) {

        Team team = new Team();

        if( connectionString == null ) return team;

        using (var connection = new SqlConnection(connectionString))
        {
            try
                {
                    connection.Open();

                    // Crear un comando SQL
                    string query = "SELECT * FROM Team WHERE name = '" + nameTeam + "'";
                    SqlCommand command = new SqlCommand(query, connection);

                    // Ejecutar el comando y leer los datos
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Leer los datos
                            team.IDTeam = reader.GetInt32(0);
                            team.Name = reader.GetString(1);
                            team.FullName = reader.GetString(2);
                            team.Chasis = reader.GetString(3);
                            team.Motor = reader.GetString(4);
                            team.SrcImage = reader.GetString(5);
                        }
                    }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error en la conexión o en la consulta: {ex.Message}");
            }
        }

        return team;

    }

}