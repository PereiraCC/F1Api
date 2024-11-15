
namespace Formula1Api.Models;

public class Driver {

    private int IdDriver;

    private string fullname;

    private string number;

    private string? team;

    private string srcImage;

    public Driver( int IDDriver, string fullname, string number, string srcImage ) {
        this.IdDriver = IDDriver;
        this.fullname = fullname;
        this.number = number;
        this.srcImage = srcImage;
    }

    public Driver( int IDDriver, string fullname, string number, string srcImage, string team ) {
        this.IdDriver = IDDriver;
        this.fullname = fullname;
        this.number = number;
        this.srcImage = srcImage;
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

    public string SrcImage
    {
        get { return srcImage; }
        set { srcImage = value; }
    }

    public string Team
    {
        get { return team; }
        set { team = value; }
    }

}