using Microsoft.AspNetCore.Mvc;
using Multimidia.Api.Core.InputModels;
using Multimidia.Api.Core.Models;
using Multimidia.Api.Core.ViewModel;
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
        public async Task<ActionResult<Video>> Obter(Guid id)
        {
            try
            {
                var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

                return Ok(await _videoRepository.Obter(new Guid(user), id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<VideoPartialViewModel>>> Listar()
        {
            try
            {
                var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

                return Ok(await _videoRepository.Listar(new Guid(user)));
            }
            catch(Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }

        }

        [HttpGet("filtrar-por-categoria")]
        public async Task<ActionResult<IEnumerable<VideoPartialViewModel>>> FiltrarPorCategoria(string categoria)
        {
            try
            {
                var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

                return Ok(await _videoRepository.FiltrarPorCategoria(new Guid(user), categoria));
            }
            catch(Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }            
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar(NovoVideoInputModel videoInput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

                var video = videoInput.ToVideo();

                video.IdUsuario = new Guid(user);

                await _videoRepository.CadastrarVideo(video);

                return Ok(new { Mensagem = "Video cadastrado com sucesso!" });
            }
            catch(Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }
    }
}
