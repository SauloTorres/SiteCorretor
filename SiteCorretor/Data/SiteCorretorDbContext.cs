using Microsoft.EntityFrameworkCore;
using SiteCorretor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCorretor.Data
{
    public class SiteCorretorDbContext : DbContext
    {
        public SiteCorretorDbContext(DbContextOptions<SiteCorretorDbContext> options)
            : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Residencia> Residencias { get; set; }


    }
}
