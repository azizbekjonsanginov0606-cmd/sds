using Dapper;
using Domain.Models;
using Infrastructure.Interfeas;
using Infrastructure.Constext;
namespace Infrastructure.Services;



public class OrdersSrvices : IOrder
{
    private DataConstext _dataConstext=new();
    public async Task<int> AddOrder(Order order)
    {
        try
        {
            using var conn = _dataConstext.CreateConnection();
            conn.Open();
            var cmd = """
            INSERT INTO Orders(customeriId,amount,CreatedAt)
            VALUES (@customeriId,@amount,@CreatedAt)
            """;
            var i = await conn.ExecuteAsync(cmd, order);
            return i;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error AddOrder: {ex.Message}");
            throw;
        }
    }


    public async Task<List<Order>> GetAllOrder()
    {
        try
        {
            using var conn = _dataConstext.CreateConnection();
            conn.Open();
            var cmd = """
            SELECT * FROM orders
            """;
            var i = await conn.QueryAsync<Order>(cmd);
            return i.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error GetAllOrder: {ex.Message}");
            throw;
        }
    }

    public async Task<Order?> GetOrderById(int id)
    {
        try
        {
            using var conn = _dataConstext.CreateConnection();
            conn.Open();
            var cmd = """
            SELECT * FROM orders
            WHERE  id=@id;
            """;
            var i = await conn.QueryFirstOrDefaultAsync<Order>(cmd, new {id});
            return i;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error GetOrderById: {ex.Message}");
            throw;
        }
    }

    public async Task UpdateOrder(Order order)
    {
        try
        {
            using var conn = _dataConstext.CreateConnection();
            conn.Open();
            var cmd = """
            UPDATE * FROM orders
            set customeriId=@customeriId,
            amount=@amount,
            CreatedAt=@CreatedAt;
            WHERE id=@id;
            """;
            await conn.ExecuteAsync(cmd, order);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error UpdateOrder: {ex.Message}");
            throw;
        }
    }
    public async Task DeleteOrder(int id)
    {
        try
        {
            using var conn = _dataConstext.CreateConnection();
            conn.Open();
            var cmd = """
            DELETE FROM orders
            WHERE id=@id;
            """;
            await conn.ExecuteAsync(cmd, new {id});
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error DeleteOrder: {ex.Message}");
            throw;
        }
    }
}
