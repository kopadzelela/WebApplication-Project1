using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication_Project1.DataAccess
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Code { get; set; } = null!;
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [InverseProperty(nameof(Product.ProductCategories))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
