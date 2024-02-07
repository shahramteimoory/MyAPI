using System.ComponentModel.DataAnnotations;

namespace MyAPI.Application.Service.Users.Command
{
    public class CreateUser_Dto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; }= string.Empty;
        [Required]
        [Compare(nameof(Password))]
        public string RePassword { get; set; }=string.Empty;
    }
}
