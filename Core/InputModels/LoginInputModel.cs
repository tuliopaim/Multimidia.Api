using System.ComponentModel.DataAnnotations;

namespace Multimidia.Api.Core.InputModels
{
    public class LoginInputModel
    {
        [Required]
        [MaxLength(24)]
        public string Username { get; set; }

        [Required]
        [MaxLength(16)]
        public string Password { get; set; }
    }
}