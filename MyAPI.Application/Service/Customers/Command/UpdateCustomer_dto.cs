namespace MyAPI.Application.Service.Customer.Command
{
    public class UpdateCustomer_dto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Ostan { get; set; }
        public string ZipCode { get; set; }
    }
}
