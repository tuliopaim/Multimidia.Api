using Microsoft.EntityFrameworkCore;
using Multimidia.Api.Core.Models;
using Multimidia.Api.Data.Infrastructure;
using Multimidia.Api.Infrastructure.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace Multimidia.Api.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MultimidiaDbContext _context;

        public UserRepository(MultimidiaDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetById(Guid id)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetByUserName(string username)
        {
           return await _context.Usuarios
                .FirstOrDefaultAsync(x => x.Username.ToLower() == username.ToLower());
        }

        public async Task Registrar(User user)
        {
            _context.Usuarios.Add(user);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> UsernameExiste(string username)
        {
            return await _context.Usuarios.AnyAsync(user => user.Username == username);
        }
    }
}
