using ECommerce.Models;

namespace ECommerce.IRepositories
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        Task<Customer?> GetByEmailAsync(string email);
    }
}
