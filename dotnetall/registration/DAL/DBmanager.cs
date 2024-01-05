using System.Data;
using BoL;
using MySql.Data.MySqlClient;

public static class DBmanager
{

    public static string coString = "server=Localhost;port=3306;user=root; password=system;database=dac_practise";
    public static void Insert(User u)
    {
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = coString;
        string query = "insert into registration values(@id,@fname,@lname,@email);";
        MySqlCommand cmd = new MySqlCommand(query, con);

        cmd.Parameters.AddWithValue("@id", u.id);
        cmd.Parameters.AddWithValue("@fname", u.fname);
        cmd.Parameters.AddWithValue("@lname", u.lname);
        cmd.Parameters.AddWithValue("@email", u.email);

        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
        }
        catch (System.Exception)
        {

            throw;
        }
        finally
        {
            con.Close();
        }
    }

    public static List<User> GetUsers()
    {
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = coString;
        string query = "select * from Registration;";
        MySqlCommand cmd = new MySqlCommand(query, con);
        List<User> users = new List<User>();
        try
        {
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int pid = int.Parse(reader["id"].ToString());
                string firstname = reader["fname"].ToString();
                string lastname = reader["lname"].ToString();
                string email1 = reader["email"].ToString();

                User u1 = new User
                {
                    id = pid,
                    fname = firstname,
                    lname = lastname,
                    email = email1,

                };
                users.Add(u1);

            }

        }
        catch (System.Exception)
        {

            throw;
        }
        finally
        {
            con.Close();
        }


        return users;
    }
    public static void Edit(User u)
    {
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = coString;
        string query = "update registration set id=@id,fname=@fname,lname=@lname,email=@email where id=@id";
        MySqlCommand cmd = new MySqlCommand(query, con);

        cmd.Parameters.AddWithValue("@id", u.id);
        cmd.Parameters.AddWithValue("@fname", u.fname);
        cmd.Parameters.AddWithValue("@lname", u.lname);
        cmd.Parameters.AddWithValue("@email", u.email);

        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
        }
        catch (System.Exception)
        {

            throw;
        }
        finally
        {
            con.Close();
        }

    }
    public static void Delete(int id)
    {
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = coString;
        string query = "delete from registration where id=@id;";
        MySqlCommand cmd = new MySqlCommand(query, con);

        cmd.Parameters.AddWithValue("@id", id);
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
        }
        catch (System.Exception)
        {

            throw;
        }
        finally
        {
            con.Close();
        }

    }

}