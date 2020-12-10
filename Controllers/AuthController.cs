using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Multimidia.Api.Core.Models;
using Multimidia.Api.Core.InputModels;
using Multimidia.Api.Infrastructure.Repository;
using Multimidia.Api.Core.Services;
using Multimidia.Api.Core.ViewModel;

namespace Multimidia.Api.Controllers
{
    [Route("v1/[Controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly TokenService _tokenService;

        public AuthController(AuthService authService, TokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] LoginInputModel model)
        {
            try
            {
                var user = await _authService.Autenticar(model.Username, model.Password);

                if (user == null)
                    return BadRequest(new { mensagem = "Usuário ou senha inválidos!" });

                // Gera o Token
                var token = _tokenService.GenerateToken(user);

                // Retorna os dados
                return Ok(new UsuarioViewModel
                {
                    Username = user.Username,
                    Role = user.Role,
                    Token = token 
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Registrar([FromBody] RegisterInputModel model)
        {
            try
            {
                var userModel = new User
                {
                    Username = model.Username,
                    Password = model.Password,
                    Role = model.Role
                };

                var user = await _authService.Criar(userModel, model.Password);

                return Ok(new { mensagem = "Usuário registrado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}