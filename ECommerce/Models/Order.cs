using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "CustomerId is required")]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer? Customer { get; set; }

        [Required(ErrorMessage = "OrderDate is required")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [StringLength(20, ErrorMessage = "Status cannot exceed 20 characters")]
        public string Status { get; set; } = "Pending";

        [Required(ErrorMessage = "TotalPrice is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "TotalPrice must be greater than 0")]
        public double TotalPrice { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
