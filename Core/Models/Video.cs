using Multimidia.Api.Core.ViewModels;
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

        public Video(string nome, string sinopse, string categoria, string video64, string videoContentType, string thumbnail64, string thumbnailContentType)
        {
            Nome = nome;
            Sinopse = sinopse;
            Video64 = video64;
            VideoContentType = videoContentType;
            Thumbnail64 = thumbnail64;
            ThumbnailContentType = thumbnailContentType;
            Categoria = categoria;
        }

        [Required]
        [MaxLength(64)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(500)]
        public string Sinopse { get; set; }

        public string Video64 { get; set; }

        public string VideoContentType { get; set; }

        public string Thumbnail64 { get; set; }

        public string ThumbnailContentType { get; set; }

        [Required]
        [MaxLength(64)]
        public string Categoria { get; set; }


        public Guid IdUsuario { get; set; }
        public User Usuario { get; set; }
    }
}
