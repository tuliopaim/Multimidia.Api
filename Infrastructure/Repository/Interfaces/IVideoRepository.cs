using Multimidia.Api.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multimidia.Api.Infrastructure.Repository.Interfaces
{
    public interface IVideoRepository
    {
        Task CadastrarVideo(Video video);

        Task<Video> Obter(Guid idUsuario, Guid id);

        Task<IEnumerable<Video>> Listar(Guid idUsuario);

        Task<IEnumerable<Video>> FiltrarPorCategoria(Guid idUsuario, string categoria);
    }
}
