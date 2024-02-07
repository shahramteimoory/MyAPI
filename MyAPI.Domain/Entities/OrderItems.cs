namespace MyAPI.Domain.Entities
{
    public class OrderItems: BaseEntites
    {
        public Order Order { get; set; }
        public long OrderId { get; set; }
        public Product Product { get; set; }
        public long ProductId { get; set; }
        public int FCount { get; set; }
    }
}
