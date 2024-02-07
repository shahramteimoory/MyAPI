namespace MyAPI.Domain.Entities
{
    public class Order: BaseEntites
    {
        public DateTime DateTime { get; set; }
        public float Total { get; set; }
        public string Status { get; set; }
        public virtual Customer Customer { get; set; }
        public long CustomerId { get; set; }
        public virtual SalePerson SalePerson { get; set; }
        public long SalePersonId { get; set; }
    }
}
