 using MySql.Data.MySqlClient;

Console.WriteLine("welcome");

MySqlConnection connection=new MySqlConnection();
connection.ConnectionString="server=192.168.10.150;port=3306;user=dac9;password=welcome;database=dac9";

//  string q="select * from books1";
string query = "insert into books1 values(4,'oops',45)";

 MySqlCommand command=new MySqlCommand(query,connection);


 try{
    connection.Open();//for opening the connection
    //for ddl commands use this
    // MySqlDataReader reader=command.ExecuteReader();
    // while(reader.Read()){
    //     int id=int.Parse(reader["id"].ToString());
    //     string bname=reader["name"].ToString();
    //     int qty=int.Parse(reader["qty"].ToString());
    //     Console.WriteLine(id+" "+bname+" "+qty);

    command.ExecuteNonQuery(); //for dml commands use this
    }
    // reader.Close();
//  }
 catch(Exception e){
    Console.WriteLine(e.Message);

 }
 finally{
    c.Close();//for closing the connection
 }