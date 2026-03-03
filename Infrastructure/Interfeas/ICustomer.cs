using Domain.Models;
namespace Infrastructure.Interfeas;

public interface ICustomer
{
    Task<int> AddCustomer(Customer customer);
    public Task<List<Customer>> GetAllCustomer();
    public Task<Customer?> GetCustomerById(int Id);
    public Task UpdateCustomer(Customer customer);
    public Task DeleteCustomer(int Id);
}
