namespace ECommerce.DTOs
{
    public class OrderDetailsDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int ProductCount { get; set; }
    }
}
