namespace BOL;

public class Employee
{
    public int EmployeeId{get; set;}
    public String EmployeeName{get; set;}
    public String Email{get; set;}
    public String Password{get; set;}

    public Employee(int EmployeeId,string EmployeeName, string Email, string Password){
        // this.EmployeeId = EmployeeId;
        this.EmployeeName = EmployeeName;
        this.Email=Email;
        this.Password=Password;
        this.EmployeeId=EmployeeId;
    }

    public override string ToString(){
        return (this.EmployeeName+" "+this.Email+" "+this.Password);
    }
}
