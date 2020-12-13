using System;
using System.Threading.Tasks;
using Multimidia.Api.Core.Models;
using Multimidia.Api.Infrastructure.Repository.Interfaces;

namespace Multimidia.Api.Core.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Autenticar(string username, string password)
        {
            // Recupera o usuário
            var user = await RecuperarUsuario(username);

            //Verificar senha
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            user.isLoggedIn = true;
            return user;
        }

        public async Task<bool> UsuarioEstaLogado(string username)
        {
            var user = await RecuperarUsuario(username);
            return user.isLoggedIn ? true : false;
        }

        private async Task<User> RecuperarUsuario(string username)
        {
            var user = await _userRepository.GetByUserName(username);
            if (user == null)
                return null;
            return user;
        }

        //public async Task<User> DeslogarUsuario(string username)
        //{
        //    var user = await RecuperarUsuario(username);
        //    _userRepository.
        //}

        public async Task<User> Criar(User user, string password)
        {
            if (await _userRepository.UsernameExiste(user.Username))
                throw new Exception("Usuario de mesmo username já cadastrado!");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _userRepository.Registrar(user);

            return user;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}