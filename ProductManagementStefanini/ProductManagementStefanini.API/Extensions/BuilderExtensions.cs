using Microsoft.EntityFrameworkCore;
using ProductManagement.API.Domain.Repositories;
using ProductManagement.API.Domain.Services;
using ProductManagement.API.Infra.Database;
using ProductManagement.API.Infra.Repositories;
using ProductManagement.API.Infra.Services;

namespace ProductManagementStefanini.API.Extensions
{
    public static class BuilderExtensions
    {
        public static void AddRegiterServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddDbContext<ApiDbContext>(opts => opts.UseSqlServer(connectionString));
            services.AddScoped<IPedidoRepository, PedidoRepository>();
        }

        public static void UseMigrations(this WebApplication app)
        {
            using var serviceScope = app.Services.CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<ApiDbContext>();
            context?.Database.EnsureCreated();
        }
    }
}
