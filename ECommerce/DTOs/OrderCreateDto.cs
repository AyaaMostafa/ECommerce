namespace ECommerce.DTOs
{
    public class OrderCreateDto
    {
        public int CustomerId { get; set; }
        public List<int> ProductIds { get; set; } = new List<int>();
    }
}
