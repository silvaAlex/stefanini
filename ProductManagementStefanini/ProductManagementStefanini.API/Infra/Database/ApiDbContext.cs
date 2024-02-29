using Microsoft.EntityFrameworkCore;
using ProductManagement.API.Domain.Models;

namespace ProductManagement.API.Infra.Database
{
    public class ApiDbContext : DbContext
    {
        public Pedido? Pedido { get; set; }
        public Produto? Produto { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }

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
