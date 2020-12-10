using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Multimidia.Api.Core.Models;
using Multimidia.Api.Infrastructure.Repository.Interfaces;

namespace Multimidia.Api.Infrastructure.Repository
{
    public class FakeUserRepository : IUserRepository
    {
        public List<User> Users { get; set; }
        public FakeUserRepository()
        {
            Users = new List<User>();
        }

        public async Task Registrar(User user)
        {
            Users.Add(user);
        }

        public async Task<bool> UsernameExiste(string username)
        {
            return Users.Any(user => user.Username == username);
        }

        public async Task<User> GetById(Guid id)
        {
            return Users
               .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public async Task<User> GetByUserName(string username)
        {
            return Users
               .Where(x => x.Username.ToLower() == username.ToLower())
                .FirstOrDefault();
        }
    }
}