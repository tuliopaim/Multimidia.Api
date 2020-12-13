using System.ComponentModel.DataAnnotations;

namespace Multimidia.Api.Core.Models
{
    public class User : EntidadeBase
    {
        [Required]
        [MaxLength(24)]
        public string Username { get; set; }

        [Required]
        [MaxLength(16)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [MaxLength(24)]
        public string Role { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}