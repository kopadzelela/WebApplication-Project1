using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication_Project1.DataAccess
{
    public partial class Country
    {
        public Country()
        {
            Customers = new HashSet<Customer>();
            Suppliers = new HashSet<Supplier>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [InverseProperty(nameof(Customer.Country))]
        public virtual ICollection<Customer> Customers { get; set; }
        [InverseProperty(nameof(Supplier.Country))]
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
