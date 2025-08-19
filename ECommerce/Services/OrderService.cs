using ECommerce.DTOs;
using ECommerce.IRepositories;
using ECommerce.IServices;
using ECommerce.Models;

namespace ECommerce.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public async Task<Order> CreateOrderAsync(OrderCreateDto dto)
        {
            var customer = await _customerRepository.GetByIdAsync(dto.CustomerId);
            if (customer == null)
            {
                throw new KeyNotFoundException("Customer not found");
            }

            var products = new List<Product>();
            double totalPrice = 0;

            foreach (var productId in dto.ProductIds.Distinct())
            {
                var product = await _productRepository.GetByIdAsync(productId);
                if (product == null)
                {
                    throw new KeyNotFoundException($"Product {productId} not found");
                }
                products.Add(product);
                totalPrice += product.Price;
            }

            var order = new Order
            {
                CustomerId = dto.CustomerId,
                OrderDate = DateTime.UtcNow,
                Status = "Pending",
                TotalPrice = totalPrice,
                Products = products
            };

            await _orderRepository.AddAsync(order);
            return order;
        }

        public async Task<OrderDetailsDto?> GetOrderDetailsAsync(int id)
        {
            var order = await _orderRepository.GetOrderWithDetailsAsync(id);
            if (order == null) return null;

            return new OrderDetailsDto
            {
                Id = order.Id,
                CustomerName = order.Customer?.Name ?? string.Empty,
                Status = order.Status,
                ProductCount = order.Products.Count
            };
        }

        public async Task UpdateOrderStatusToDeliveredAsync(int id)
        {
            var order = await _orderRepository.GetOrderWithDetailsAsync(id);
            if (order == null)
            {
                throw new KeyNotFoundException("Order not found");
            }

            if (order.Status == "Delivered")
            {
                throw new InvalidOperationException("Order already delivered");
            }

            order.Status = "Delivered";

            foreach (var product in order.Products)
            {
                product.Stock -= 1;
                await _productRepository.UpdateAsync(product);
            }

            await _orderRepository.UpdateAsync(order);
        }
    }
}
