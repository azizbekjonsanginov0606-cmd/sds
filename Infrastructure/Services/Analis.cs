using Dapper;
using Domain.Models;
using Infrastructure.Interfeas;
using Infrastructure.Constext;
namespace Infrastructure.Services;

public class Analis
{
    private DataConstext _dataConstext=new();
    public async Task getJoin()
    {
        using var conn = _dataConstext.CreateConnection();
            conn.Open();
            var cmd = """
            Select c.*,o.*
            
            """;
            await conn.ExecuteAsync(cmd, Customer);
    }
}
