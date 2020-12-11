using Microsoft.EntityFrameworkCore;
using Multimidia.Api.Core.Models;
using Multimidia.Api.Core.ViewModels;
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
                .FirstOrDefaultAsync(v => v.UsuarioId == idUsuario && v.Id == id);
        }
        public async Task<IEnumerable<VideoPartialViewModel>> Listar(Guid idUsuario)
        {
            return await _context.Videos
                .AsNoTracking()
                .Where(v => v.UsuarioId == idUsuario)
                .Select(v => new VideoPartialViewModel 
                {   
                    Id = v.Id,
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
              .Where(v => v.UsuarioId == idUsuario && v.Categoria == categoria)
              .Select(v => new VideoPartialViewModel
              {
                  Id = v.Id,
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

        public async Task Atualizar(Video video)
        {
            _context.Update(video);

            await _context.SaveChangesAsync();
        }

        public async Task Deletar(Guid id)
        {
            var video = await _context.Videos.FindAsync(id);

            _context.Videos.Remove(video);

            await _context.SaveChangesAsync();
        }
    }
}
