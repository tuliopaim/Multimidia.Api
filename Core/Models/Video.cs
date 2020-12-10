using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Multimidia.Api.Core.Models
{
    public class Video : EntidadeBase
    {
        public Video()
        {

        }
        public Video(string nome, string sinopse, string video64, string thumbnail64, string categoria)
        {
            Nome = nome;
            Sinopse = sinopse;
            Video64 = video64;
            Thumbnail64 = thumbnail64;
            Categoria = categoria;
        }

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


        public Guid IdUsuario { get; set; }
        public User Usuario { get; set; }
    }
}
