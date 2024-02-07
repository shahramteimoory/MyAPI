namespace MyAPI.Domain.Entities
{
    public class User : BaseEntites
    {
        public string Email { get; set; }=string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
