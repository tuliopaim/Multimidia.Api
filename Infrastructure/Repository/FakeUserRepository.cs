using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Multimidia.Api.Core.Models;

namespace Multimidia.Api.Infrastructure.Repository
{
    public class FakeUserRepository : IUserRepository
    {
        public List<User> Users { get; set; }
        public FakeUserRepository()
        {
            Users = new List<User>();
        }
        public async Task<User> Get(string username)
        {
            return Users
               .Where(x => x.Username.ToLower() == username.ToLower())
                .FirstOrDefault();
        }

        public async Task Registrar(User user)
        {
            Users.Add(user);
        }

        public async Task<bool> UsuarioExiste(string username)
        {
            return Users.Any(user => user.Username == username);
        }
    }
}