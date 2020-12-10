using Microsoft.EntityFrameworkCore;
using Multimidia.Api.Core.Models;

namespace Multimidia.Api.Data.Infrastructure
{
    public class MultimidiaDbContext : DbContext
    {
        public MultimidiaDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Usuarios { get; set; }
        public DbSet<Video> Videos { get; set; }

    }
}
