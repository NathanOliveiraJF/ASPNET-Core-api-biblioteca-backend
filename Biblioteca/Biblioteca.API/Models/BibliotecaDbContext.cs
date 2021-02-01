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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Obra>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Obra>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
        }

    }    
}