using Formula1Api.Models;
using Formula1Api.DataAccess;

namespace Formula1Api.BusinessLogic;

public class TeamsBL {

    private TeamsDA _teamsDA;

    public TeamsBL(IConfiguration configuration)
    {
        _teamsDA = new TeamsDA(configuration);
    }

    public List<Team> getAllTeams() {
        return _teamsDA.getAllTeams();
    }

    public Team getOneTeam(string nameTeam) {
        return _teamsDA.getOneTeam(nameTeam);
    }

}