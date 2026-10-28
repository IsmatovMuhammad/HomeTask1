using System.Data;
using System.Data.Common;
using Npgsql;

namespace Infrastructure.Data;

public static class AppData
{
    private static string connectionString = "Host=localhost;Port=5432;DataBase=MiniShop;Username=postgres;Password=1234";
    public static IDbConnection Connection() => new NpgsqlConnection(connectionString);
}
