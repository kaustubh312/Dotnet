using BoL;

public static class Service
{
    public static List<User> GetAll()
    {
        List<User> all = DBmanager.GetUsers();
        return all;
    }

}