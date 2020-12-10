using System;
using System.Threading.Tasks;
using Multimidia.Api.Core.Models;

namespace Multimidia.Api.Infrastructure.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetById(Guid id);
        Task<User> GetByUserName(string username);
        Task Registrar(User user);
        Task<bool> UsernameExiste(string username);
    }
}