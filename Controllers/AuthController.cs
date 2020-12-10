using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Multimidia.Api.Core.Models;
using Multimidia.Api.Core.ViewModels;
using Multimidia.Api.Infrastructure.Repository;
using Multimidia.Api.Services;

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
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] LoginViewModel model)
        {
            try
            {
                var user = await _authService.Autenticar(model.Username, model.Password);

                if (user == null)
                    return new { mensagem = "Usuário ou senha inválidos!" };

                // Gera o Token
                var token = _tokenService.GenerateToken(user);

                // Retorna os dados
                return new
                {
                    username = user.Username,
                    role = user.Role,
                    token = token
                };

            }
            catch (Exception ex)
            {
                return new { mensagem = ex.Message };
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Registrar([FromBody] RegisterViewModel model)
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