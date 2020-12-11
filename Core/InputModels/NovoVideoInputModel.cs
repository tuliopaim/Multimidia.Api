using Microsoft.AspNetCore.Http;
using Multimidia.Api.Core.Models;
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

        public IFormFile FormFileVideo { get; set; }

        public IFormFile FormFileImagem { get; set; }

        [Required]
        [MaxLength(64)]
        public string Categoria { get; set; }

    }
}
