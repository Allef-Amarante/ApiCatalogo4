using ApiCatalogo4.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo4.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> op) :base(op)
        {

        }

        public DbSet<Categoria>? Categorias { get; set; }

        public DbSet<Produto>? Produtos { get; set; }

    }
}
