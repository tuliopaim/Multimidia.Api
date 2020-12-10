using System.Threading.Tasks;
using Multimidia.Api.Core.Models;

namespace Multimidia.Api.Infrastructure.Repository
{
    public interface IUserRepository
    {
        Task<User> Get(string username);
        Task Registrar(User user);
        Task<bool> UsuarioExiste(string username);
    }
}