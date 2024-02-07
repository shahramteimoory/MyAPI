using System.ComponentModel.DataAnnotations;

namespace MyAPI.Application.Service.Customer.Command
{
    public class AddCustomer_Dto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Ostan { get; set; }
        public string ZipCode { get; set; }
    }
}
