using System.ComponentModel.DataAnnotations;

namespace MyAPI.Application.Service.Users.Command
{
    public class EditUser_Dto
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
