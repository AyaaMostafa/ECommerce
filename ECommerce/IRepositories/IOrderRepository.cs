using ECommerce.Models;

namespace ECommerce.IRepositories
{
    public interface IOrderRepository: IRepositoryBase<Order>
    {
        Task<Order?> GetOrderWithDetailsAsync(int id);
    }
}
