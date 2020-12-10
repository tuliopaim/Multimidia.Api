using Microsoft.EntityFrameworkCore;
using Multimidia.Api.Core.Models;
using Multimidia.Api.Core.ViewModel;
using Multimidia.Api.Data.Infrastructure;
using Multimidia.Api.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multimidia.Api.Infrastructure.Repository
{
    public class VideoRepository : IVideoRepository
    {
        private readonly MultimidiaDbContext _context;

        public VideoRepository(MultimidiaDbContext context)
        {
            _context = context;
        }
        public async Task<Video> Obter(Guid idUsuario, Guid id)
        {
            return await _context.Videos
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.IdUsuario == idUsuario && v.Id == id);
        }
        public async Task<IEnumerable<VideoPartialViewModel>> Listar(Guid idUsuario)
        {
            return await _context.Videos
                .AsNoTracking()
                .Where(v => v.IdUsuario == idUsuario)
                .Select(v => new VideoPartialViewModel 
                {   
                    Nome = v.Nome, 
                    Sinopse = v.Categoria,
                    Descricao = v.Sinopse
                })
                .ToListAsync();
        }
        public async Task<IEnumerable<VideoPartialViewModel>> FiltrarPorCategoria(Guid idUsuario, string categoria)
        {
            return await _context.Videos
              .AsNoTracking()
              .Where(v => v.IdUsuario == idUsuario && v.Categoria == categoria)
              .Select(v => new VideoPartialViewModel
              {
                  Nome = v.Nome,
                  Sinopse = v.Categoria,
                  Descricao = v.Sinopse
              })
              .ToListAsync();
        }

        public async Task CadastrarVideo(Video video)
        {
            _context.Videos.Add(video);

            await _context.SaveChangesAsync();
        }
    }
}
