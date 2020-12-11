using Multimidia.Api.Core.Models;
using Multimidia.Api.Core.ViewModels;
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

        Task<IEnumerable<VideoPartialViewModel>> Listar(Guid idUsuario);

        Task<IEnumerable<VideoPartialViewModel>> FiltrarPorCategoria(Guid idUsuario, string categoria);

        Task Atualizar(Video model);

        Task Deletar(Guid id);
    }
}
