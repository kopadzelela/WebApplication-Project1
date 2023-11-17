using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication_Project1.DataAccess
{
    public partial class CustomersPhoneNumber
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("PhoneTypeID")]
        public int PhoneTypeId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string PhoneNumber { get; set; } = null!;
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [StringLength(10)]
        public string IsMain { get; set; } = null!;

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("CustomersPhoneNumbers")]
        public virtual Customer Customer { get; set; } = null!;
        [ForeignKey(nameof(PhoneTypeId))]
        [InverseProperty("CustomersPhoneNumbers")]
        public virtual PhoneType PhoneType { get; set; } = null!;
    }
}
