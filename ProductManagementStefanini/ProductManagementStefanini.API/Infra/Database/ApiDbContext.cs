using Microsoft.EntityFrameworkCore;
using ProductManagement.API.Domain.Models;
using System.Transactions;

namespace ProductManagement.API.Infra.Database
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Pedido>? Pedidos { get; set; }
        public DbSet<ItemPedido>? Items { get; set; }
        public DbSet<Produto>? Produtos { get; set; }


        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
        }
    }
}
