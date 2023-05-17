using System.ComponentModel.DataAnnotations;

namespace FPTBook_by_NguyenMinhTan.Models.ViewModels
{
    public class LoginModel
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}
