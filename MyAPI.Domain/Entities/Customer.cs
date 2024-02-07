﻿namespace MyAPI.Domain.Entities
{
    public class Customer: BaseEntites
    {
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
