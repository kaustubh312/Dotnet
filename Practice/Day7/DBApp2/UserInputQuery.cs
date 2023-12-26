using MySql.Data.MySqlClient;

MySqlConnection connection = new MySqlConnection();
connection.ConnectionString="server=192.168.10.150;port=3306;user=dac9;password=welcome;database=dac9";

Console.WriteLine("Enter Table to be seen");
string table = Console.ReadLine();
string query = "Select * from "+table;
MySqlCommand command = new MySqlCommand(query, connection);
int choice;
connection.Open();
try{
    do{
        command = new MySqlCommand(query, connection);
        MySqlDataReader reader = command.ExecuteReader();
        Console.WriteLine();
        Console.WriteLine("---------------------------");
        Console.WriteLine();
        // Console.WriteLine(query);
        while(reader.Read()){
            int id = int.Parse((reader["id"]).ToString());
            string name = reader["name"].ToString();
            int qty = int.Parse((reader["qty"]).ToString());
            Console.WriteLine(id+" "+name+" "+qty);
        }

        reader.Close();
        Console.WriteLine();
        Console.WriteLine("Enter Your Choice : ");
        Console.WriteLine("1. Insert Data/n 2.Update Data/n 3. Delete Data/n 4.Exit");
        choice = int.Parse(Console.ReadLine());
        switch(choice){
            case 1:
                Console.WriteLine("Enter the id : ");
                int id = int.Parse(Console.ReadLine().ToString());
                Console.WriteLine("Enter the name : ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the quantity : ");
                int qty = int.Parse(Console.ReadLine());
                string iquery = "insert into "+table+" values(@id, @name, @qty)";
                command = new MySqlCommand(iquery, connection);
                // command.Parameters.AddWithValue("@table1",table);
                command.Parameters.AddWithValue("@id",id);
                command.Parameters.AddWithValue("@name",name);
                command.Parameters.AddWithValue("@qty",qty);
                Console.WriteLine(iquery);
                command.ExecuteNonQuery();
                break;

            case 2:
                string uquery = "update "+table+" set name=@name , qty=@qty where id=@id";
                command = new MySqlCommand(uquery, connection);
                Console.WriteLine("Enter id to be changed : ");
                id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter new name : ");
                name = Console.ReadLine().ToString();
                Console.WriteLine("Enter new quantity : ");
                qty = int.Parse(Console.ReadLine());
                command.Parameters.AddWithValue("@id",id);
                command.Parameters.AddWithValue("@name",name);
                command.Parameters.AddWithValue("@qty",qty);
                command.ExecuteNonQuery();
                break;

            case 3:
                string dquery="delete from "+table+" where id=@id";
                command = new MySqlCommand(dquery, connection);
                Console.WriteLine("Enter id to be deleted : ");
                id = int.Parse(Console.ReadLine());
                command.Parameters.AddWithValue("@id",id);
                command.ExecuteNonQuery();
                break;

            default:
                Console.WriteLine("krupaya, nit ghala.....");
                break;
        }

    }while(choice!=4);
}
catch(Exception e){
    Console.WriteLine(e.Message);
}
finally{
    connection.Close();
}
// command.Parameters.AddWithValue("@table",table);

// try{
//     connection.Open();
//     MySqlDataReader reader = command.ExecuteReader();
//     while(reader.Read()){
//         int id = int.Parse((reader["id"]).ToString());
//         string name = reader["name"].ToString();
//         int qty = int.Parse((reader["qty"]).ToString());
//         Console.WriteLine(id+" "+name+" "+qty);
//     }
// }
// catch(Exception e){
//     Console.WriteLine(e.Message);
// }
// finally{
//     connection.Close();
// }
