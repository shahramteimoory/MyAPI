namespace MyAPI.Application.Service.Products.Command
{
    public class EditProduct_Dto
    {
        public long Id {  get; set; }
        public string ProductName { get; set; }
        public int Size { get; set; }
        public string Nooeh { get; set; }
        public float Price { get; set; }
        public string Status { get; set; }
    }
}
