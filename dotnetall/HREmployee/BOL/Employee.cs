namespace BOL;

public class Employee
{
    public int Employeeid{get; set;}
    public String Employeename{get; set;}
    public String Email{get;set;}
    public String Password{get; set;}

    public Employee(int Employeeid, String Employeename, String Email, String Password){
        this.Employeeid = Employeeid;
        this.Employeename = Employeename;
        this.Email = Email;
        this.Password = Password;
    }

    public String ToString(){
        return this.Employeeid+" "+this.Employeename;
    }
}