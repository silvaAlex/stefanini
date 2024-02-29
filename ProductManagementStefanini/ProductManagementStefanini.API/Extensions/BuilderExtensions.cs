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
            services.AddScoped<IPedidoService, PedidoServices>();
            services.AddScoped<ApiDbContext>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
        }
    }
}
