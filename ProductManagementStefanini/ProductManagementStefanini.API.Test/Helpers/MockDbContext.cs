using Microsoft.EntityFrameworkCore;
using ProductManagement.API.Infra.Database;

namespace ProductManagementStefanini.API.Test.Helpers
{
    public class MockDbContext : IDbContextFactory<ApiDbContext>
    {
        public ApiDbContext CreateDbContext()
        {
           var options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase($"PedidoDb-{DateTime.Now.ToFileTimeUtc()}")
                .Options;

           return new ApiDbContext(options);    
        }
    }
}
