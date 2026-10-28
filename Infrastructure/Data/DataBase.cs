using Npgsql;

namespace Infrastructure.Data;

public static class DataBase
{
    private static string connectionString = "Host=localhost;Port=5432;Database=booknest;Username=postgres;Password=1234";
    public static NpgsqlConnection Connection() => new NpgsqlConnection(connectionString);
}
