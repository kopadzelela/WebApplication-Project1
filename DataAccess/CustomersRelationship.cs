using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication_Project1.DataAccess
{
    public partial class CustomersRelationship
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("RelationshipTypeID")]
        public int RelationshipTypeId { get; set; }
        [Column("StartCustomerID")]
        public int StartCustomerId { get; set; }
        [Column("EndCustomerID")]
        public int EndCustomerId { get; set; }
        [StringLength(1000)]
        public string Comment { get; set; } = null!;

        [ForeignKey(nameof(EndCustomerId))]
        [InverseProperty(nameof(Customer.CustomersRelationshipEndCustomers))]
        public virtual Customer EndCustomer { get; set; } = null!;
        [ForeignKey(nameof(RelationshipTypeId))]
        [InverseProperty("CustomersRelationships")]
        public virtual RelationshipType RelationshipType { get; set; } = null!;
        [ForeignKey(nameof(StartCustomerId))]
        [InverseProperty(nameof(Customer.CustomersRelationshipStartCustomers))]
        public virtual Customer StartCustomer { get; set; } = null!;
    }
}
