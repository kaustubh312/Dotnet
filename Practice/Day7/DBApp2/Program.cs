using MySql.Data.MySqlClient;

MySqlConnection connection = new MySqlConnection();
connection.ConnectionString="server=192.168.10.150;port=3306;user=dac9;password=welcome;database=dac9";

Console.WriteLine("Enter the id of product to be deleted:");
int userInputId = int.Parse(Console.ReadLine());

string query = "delete from books1 where id = @id";
MySqlCommand command = new MySqlCommand(query, connection);

command.Parameters.AddWithValue("@id",userInputId);


try{
    connection.Open();

    command.ExecuteNonQuery();
}catch(Exception e){
    Console.WriteLine(e.Message);
}
finally{
    connection.Close();
}



