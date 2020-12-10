using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Multimidia.Api.Core.ViewModels
{
    public class RegisterViewModel
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
    }
}
