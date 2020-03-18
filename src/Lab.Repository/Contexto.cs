using System;
using Lab.Core.Model;
using Microsoft.EntityFrameworkCore;



namespace Lab.Repository
{
    public class Contexto : DbContext
    {
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }

        public Contexto(DbContextOptions<Contexto> options)
        : base(options)
        {
            
        }
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);
        //     modelBuilder.Entity<Produto>()
        //                 .HasOne<Categoria>(s => s.);

        // }


        //     //optionsBuilder.UseSqlServer(
        //     //    @"Server=(localdb)\mssqllocaldb;Database=Blogging;Integrated Security=True");

        // }
    }
}
