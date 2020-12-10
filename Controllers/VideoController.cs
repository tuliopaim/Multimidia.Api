using Microsoft.AspNetCore.Mvc;
using Multimidia.Api.Core.Models;
using Multimidia.Api.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multimidia.Api.Controllers
{
    [Route("v1/[Controller]")]
    public class VideoController : Controller
    {
        private readonly IVideoRepository _videoRepository;

        public VideoController(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        [HttpGet]
        public async Task<Video> Obter(Guid id)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

            return await _videoRepository.Obter(new Guid(user), id);
        }

        [HttpGet("listar")]
        public async Task<IEnumerable<Video>> Listar()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

            return await _videoRepository.Listar(new Guid(user));
        }

        [HttpGet("filtrar-por-categoria")]
        public async Task<IEnumerable<Video>> FiltrarPorCategoria(string categoria)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

            return await _videoRepository.FiltrarPorCategoria(new Guid(user), categoria);
        }

        [HttpPost]
        public async Task Cadastrar(Video video)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

            video.IdUsuario = new Guid(user);

            await _videoRepository.CadastrarVideo(video);
        }
    }
}
