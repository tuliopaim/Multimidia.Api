using Microsoft.AspNetCore.Http;
using Multimidia.Api.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
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

        public string ContentTypeVideo { get; set; }

        public string ContentTypeImagem { get; set; }

        public Dictionary<string, IFormFile> Video { get; set; }
        public Dictionary<string, IFormFile> Imagem { get; set; }

        [Required]
        [MaxLength(64)]
        public string Categoria { get; set; }

    }
}
