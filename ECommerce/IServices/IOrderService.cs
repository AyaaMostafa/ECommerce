using ECommerce.DTOs;
using ECommerce.Models;

namespace ECommerce.IServices
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(OrderCreateDto dto);
        Task<OrderDetailsDto?> GetOrderDetailsAsync(int id);
        Task UpdateOrderStatusToDeliveredAsync(int id);
    }
}
