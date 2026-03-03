using Dapper;
using Domain.Models;
using Infrastructure.Interfeas;
using Infrastructure.Constext;
namespace Infrastructure.Services;

public class CustomersServices : ICustomer
{
    private DataConstext _dataConstext=new();
    public async Task<int> AddCustomer(Customer Customer)
    {
        try
        {
            using var conn = _dataConstext.CreateConnection();
            conn.Open();
            var cmd = """
            INSERT INTO Customers (fullname)
            VALUES (@fullname)
            """;
            var i = await conn.ExecuteAsync(cmd, Customer);
            return i;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error AddCustomer: {ex.Message}");
            throw;
        }
    }


    public async Task<List<Customer>> GetAllCustomer()
    {
        try
        {
            using var conn = _dataConstext.CreateConnection();
            conn.Open();
            var cmd = """
            SELECT * FROM Customers
            """;
            var i = await conn.QueryAsync<Customer>(cmd);
            return i.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error GetAllCustomer: {ex.Message}");
            throw;
        }
    }

    public async Task<Customer?> GetCustomerById(int id)
    {
        try
        {
            using var conn = _dataConstext.CreateConnection();
            conn.Open();
            var cmd = """
            SELECT * FROM Customers
            WHERE  id=@id;
            """;
            var i = await conn.QueryFirstOrDefaultAsync<Customer>(cmd, new {id});
            return i;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error GetCustomerById: {ex.Message}");
            throw;
        }
    }

    public async Task UpdateCustomer(Customer Customer)
    {
        try
        {
            using var conn = _dataConstext.CreateConnection();
            conn.Open();
            var cmd = """
            UPDATE Customers
            set fullname=@fullname
            WHERE id=@id;
            """;
            await conn.ExecuteAsync(cmd, Customer);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error UpdateCustomer: {ex.Message}");
            throw;
        }
    }
    public async Task DeleteCustomer(int id)
    {
        try
        {
            using var conn = _dataConstext.CreateConnection();
            conn.Open();
            var cmd = """
            DELETE FROM Customers
            WHERE id=@id;
            """;
            await conn.ExecuteAsync(cmd, new {id});
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error DeleteCustomer: {ex.Message}");
            throw;
        }
    }
}
