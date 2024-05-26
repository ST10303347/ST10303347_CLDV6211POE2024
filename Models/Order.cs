using Microsoft.AspNetCore.Identity;
using ST10303347_CLDV6211POE2024.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST10303347_CLDV6211POE2024.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public double totalPrice { get; set; }
        public orderStatus status { get; set; } 
        public int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
      

        [Required]
        public string? IdentityUserId { get; set; }
        [ForeignKey("IdentityUserId")]
        public IdentityUser? User { get; set; }
    }
}
