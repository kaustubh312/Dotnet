namespace DAL;
using MySql.Data.MySqlClient;

public class Connect
{
    private static MySqlConnection conn = null;
    
    public static MySqlConnection getConnection(){
        if(conn==null){
            // conn = new MySqlConnection();
            String connstr= "server=localhost;port=3306;user=root;password=system;database=dac_practise";
            conn = new MySqlConnection(connstr);
        }
        return conn;
        
    }
}
