using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication_Project1.DataAccess
{
    public partial class PhoneType
    {
        public PhoneType()
        {
            CustomersPhoneNumbers = new HashSet<CustomersPhoneNumber>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [InverseProperty(nameof(CustomersPhoneNumber.PhoneType))]
        public virtual ICollection<CustomersPhoneNumber> CustomersPhoneNumbers { get; set; }
    }
}
