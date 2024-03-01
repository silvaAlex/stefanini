using Microsoft.EntityFrameworkCore;
using ProductManagement.API.Domain.Models;

namespace ProductManagement.API.Infra.Database
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Pedido>? Pedidos { get; set; }
 
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>()
                .HasMany(x => x.Pedidos)
                .WithOne()
                .HasForeignKey(x => x.PedidoId)
                .IsRequired();
        }
    }
}
