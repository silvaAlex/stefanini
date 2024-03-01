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
        public static void AddRegiterServices(this IServiceCollection services)
        {
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddDbContext<ApiDbContext>(opts =>
                opts.UseSqlServer(new ConfigurationManager().GetConnectionString("DefaultConnection"))
            );
            services.AddScoped<IPedidoRepository, PedidoRepository>();
        }
    }
}
