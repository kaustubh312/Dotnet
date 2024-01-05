namespace BLL;
using BOL;
using MySql.Data.MySqlClient;
using DAL;
public class BusinessLayer
{
    static MySqlConnection conn = Connect.getConnection();

    public static void InsertData(int EmployeeId,string EmployeeName, string Email, string Password){
        string query = "insert into RegisterEmployee values (@EmployeeId,@EmployeeName,@Email, @Password)";
        conn.Open();
        MySqlCommand command = new MySqlCommand(query,conn);
        command.Parameters.AddWithValue("@EmployeeId",EmployeeId);
        command.Parameters.AddWithValue("@EmployeeName",EmployeeName);
        command.Parameters.AddWithValue("@Email",Email);
        command.Parameters.AddWithValue("@Password",Password);
        command.ExecuteNonQuery();
        conn.Close();
    }

    public static Employee Login(string Email, string Password){
        string query = "select * from RegisterEmployee where Email= @Email and Password = @Password";
        conn.Open();
        MySqlCommand command = new MySqlCommand(query, conn);
        command.Parameters.AddWithValue("@Email",Email);
        command.Parameters.AddWithValue("@Password",Password);
        MySqlDataReader reader = command.ExecuteReader();
        Employee e=null;
        bool flag = false;
        while(reader.Read()){
            e = new Employee(int.Parse(reader["EmployeeId"].ToString()),reader["EmployeeName"].ToString(),reader["Email"].ToString(),reader["Password"].ToString());
            flag = true;
        }
        if(flag){
            conn.Close();
            return e;
        }
        conn.Close();
        return e; 
    }

    public static List<Employee> ViewAllEmployee(){
        conn.Open();
        List<Employee> emp = new List<Employee>();
        string query = "Select * from RegisterEmployee";
        MySqlCommand command = new MySqlCommand(query,conn);
        MySqlDataReader reader = command.ExecuteReader();
        while(reader.Read()){
            Employee e = new Employee(int.Parse(reader["EmployeeId"].ToString()),reader["EmployeeName"].ToString(),reader["Email"].ToString(),reader["Password"].ToString());
            emp.Add(e);
        }
        conn.Close();
        return emp;
    }

    public static void EditEmployee(int EmployeeId, string EmployeeName, string Email, string Password){
        conn.Open();
        string query = "update RegisterEmployee set EmployeeName = @EName , Email = @Email, Password=@Password where EmployeeId = @EId";
        MySqlCommand command = new MySqlCommand(query,conn);
        command.Parameters.AddWithValue("@EId",EmployeeId);
        command.Parameters.AddWithValue("@EName",EmployeeName);
        command.Parameters.AddWithValue("@Email",Email);
        command.Parameters.AddWithValue("@Password",Password);
        command.ExecuteNonQuery();
        conn.Close();
    }

    public static void DeleteEmployee(Employee emp){
        conn.Open();
        string query = "delete from RegisterEmployee where EmployeeId = @Eid";
        MySqlCommand command = new MySqlCommand(query, conn);
        command.Parameters.AddWithValue("@Eid", emp.EmployeeId);
        command.ExecuteNonQuery();
        conn.Close();
    }
}
