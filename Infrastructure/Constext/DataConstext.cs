using Npgsql;
using Dapper;
using System.Data;
namespace Infrastructure.Constext;

public class DataConstext
{
    const string connectionString = @"Host=localhost;
                                      Port=5433;
                                      DataBase=examend;
                                      UserName = hacker;
                                      Password = 200606";

    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(connectionString);
    }  
}
