using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Api.Models
{
    public class BibliotecaDbContext : DbContext
    {
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) 
            : base(options)
        {
            
        }
        public DbSet<Obra> Obras { get; set; }
        public DbSet<Ator> Atores { get; set; }

    }    
}