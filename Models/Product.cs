﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ST10303347_CLDV6211POE2024.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST10303347_CLDV6211POE2024.Models
{
    public class Product
    {
        [Key]
        public int productId { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }

        public ProductCategory Category { get; set; }

        public string Availability { get; set; }

        public string Description { get; set; }
        public string ImagePath { get; set; }
        [Required]
        public string? IdentityUserId { get; set; }
        [ForeignKey("IdentityUserId")]
        public IdentityUser? User { get; set; }




    }
}
