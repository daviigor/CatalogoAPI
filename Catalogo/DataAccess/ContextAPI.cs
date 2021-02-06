using Catalogo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogo.DataAccess
{
    public class ContextAPI : DbContext
    {
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produto { get; set; }

        public ContextAPI(DbContextOptions<ContextAPI> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure  

            // Map entities to tables  
            modelBuilder.Entity<Categoria>().ToTable("categoria");
            modelBuilder.Entity<Produto>().ToTable("produto");

            // Configure Primary Keys  
            modelBuilder.Entity<Categoria>().HasKey(ug => ug.IdCategoria).HasName("PRIMARY");
            modelBuilder.Entity<Produto>().HasKey(u => u.IdProduto).HasName("PRIMARY");

            // Configure indexes  
            /*
            modelBuilder.Entity<Categoria>().HasIndex(p => p.Nome).IsUnique().HasDatabaseName("Idx_Nome");
            modelBuilder.Entity<Produto>().HasIndex(u => u.Nome).HasDatabaseName("Idx_Nome");*/

            // Configure columns  
            modelBuilder.Entity<Categoria>().Property(ug => ug.IdCategoria).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Categoria>().Property(ug => ug.Nome).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Categoria>().Property(ug => ug.IdCategoriaPai).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Categoria>().Property(ug => ug.Ativo).HasColumnType("bit").IsRequired();

            modelBuilder.Entity<Produto>().Property(u => u.IdProduto).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Produto>().Property(u => u.Nome).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Produto>().Property(u => u.Descricao).HasColumnType("nvarchar(3000)").IsRequired(false);
            modelBuilder.Entity<Produto>().Property(u => u.IdCategoria).HasColumnType("int");
            modelBuilder.Entity<Produto>().Property(u => u.Ativo).HasColumnType("bit").IsRequired();
            modelBuilder.Entity<Produto>().Property(u => u.Estoque).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Produto>().Property(u => u.Preco).HasColumnType("decimal").HasPrecision(18,2).IsRequired();
            modelBuilder.Entity<Produto>().Property(u => u.ImagemURL).HasColumnType("nvarchar(500)").IsRequired(false);

            // Configure relationships  
            modelBuilder.Entity<Produto>().HasOne<Categoria>().WithMany().
                HasPrincipalKey(ug => ug.IdCategoria).HasForeignKey(u => u.IdCategoria).
                OnDelete(DeleteBehavior.SetNull).HasConstraintName("fk_produto_categoria");
        }
    }
}
