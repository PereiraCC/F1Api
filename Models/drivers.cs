
namespace Formula1Api.Models;

public class Driver {

    private int IdDriver;

    private string fullname;

    private string number;

    private string? team;

    public Driver( int IDDriver, string fullname, string number ) {
        this.IdDriver = IDDriver;
        this.fullname = fullname;
        this.number = number;
    }

    public Driver( int IDDriver, string fullname, string number, string team ) {
        this.IdDriver = IDDriver;
        this.fullname = fullname;
        this.number = number;
        this.team = team;
    }

    public int IDDriver
    {
        get { return IdDriver; } 
        set { IdDriver = value; }
    }

    public string FullName
    {
        get { return fullname; } 
        set { fullname = value; }
    }

    public string Number
    {
        get { return number; }
        set { number = value; }
    }

    public string Team
    {
        get { return team; }
        set { team = value; }
    }

}