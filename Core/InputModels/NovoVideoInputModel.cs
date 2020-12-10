using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Multimidia.Api.Core.InputModels
{
    public class NovoVideoInputModel
    {
        [Required]
        [MaxLength(64)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(500)]
        public string Sinopse { get; set; }

        [Required]
        public string Video64 { get; set; }

        [Required]
        public string Thumbnail64 { get; set; }

        [Required]
        [MaxLength(64)]
        public string Categoria { get; set; }
    }
}
