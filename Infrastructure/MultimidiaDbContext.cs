using Microsoft.EntityFrameworkCore;
using Multimidia.Api.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multimidia.Api.Infrastructure
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
