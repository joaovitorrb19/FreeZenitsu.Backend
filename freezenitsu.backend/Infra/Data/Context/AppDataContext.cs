using Core.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Context
{
    public class AppDataContext : IdentityDbContext
    {

        public AppDataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Arquivo> Arquivo { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produto { get; set; }

    }
}
