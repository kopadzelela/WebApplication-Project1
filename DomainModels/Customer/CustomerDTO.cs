using System.ComponentModel.DataAnnotations;

namespace WebApplication_Project1.DomainModels.Customer
{
    public class CustomerDTO
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters.")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters.")]
        public string LastName { get; set; } = null!;
        public int GenderId { get; set; }
        public string PersonalNumber { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; } = null!;
        public string? StartCustomer { get; set; }
        public string? EndCustomer { get; set; }
    }
}
