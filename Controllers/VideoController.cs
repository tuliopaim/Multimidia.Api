using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multimidia.Api.Core.InputModels;
using Multimidia.Api.Core.Models;
using Multimidia.Api.Core.Services;
using Multimidia.Api.Core.ViewModels;
using Multimidia.Api.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multimidia.Api.Controllers
{
    [Authorize]
    [Route("v1/[Controller]")]
    public class VideoController : Controller
    {
        private readonly IVideoRepository _videoRepository;
        private readonly FileService _fileService;

        public VideoController(IVideoRepository videoRepository, FileService fileService )
        {
            _videoRepository = videoRepository;
            _fileService = fileService;
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

                var videoViewModel = await _fileService.FormFileToFileViewModel(videoInput.FormFileVideo);

                var imageViewModel = await _fileService.FormFileToFileViewModel(videoInput.FormFileImagem);

                var video = new Video(
                    videoInput.Nome,
                    videoInput.Sinopse,
                    videoInput.Categoria,
                    videoViewModel.Base64,
                    videoViewModel.ContentType,
                    imageViewModel.Base64,
                    imageViewModel.ContentType);

                await _videoRepository.CadastrarVideo(video);

                return Ok(new { Mensagem = "Video cadastrado com sucesso!" });
            }
            catch(Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult> Editar([FromBody] Video model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

                await _videoRepository.Atualizar(model);

                return Ok(new { Mensagem = "Video atualizado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Deletar([FromBody] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

                await _videoRepository.Deletar(id);

                return Ok(new { Mensagem = "Video deletado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }
    }
}
