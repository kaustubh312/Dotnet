namespace BoL;

public class User
{
    public int id { get; set; }
    public string fname { get; set; }
    public string lname { get; set; }
    public string email { get; set; }

    public User()
    {
        id = 0;
        fname = null;
        lname = null;
        email = null;
    }

    public User(int id, string fname, string lname, string email)
    {
        this.id = id;
        this.fname = fname;
        this.lname = lname;
        this.email = email;
    }

}
