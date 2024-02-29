using ProductManagement.API.Domain.Models;
using ProductManagement.API.Domain.Repositories;
using ProductManagement.API.Infra.Database;

namespace ProductManagement.API.Infra.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApiDbContext _context;

        public PedidoRepository(ApiDbContext dbContext)
        {
            _context = dbContext;
        }

        public void AddPedido(Pedido pedido)
        {
            _context.Add(pedido);
            _context.SaveChanges();
        }

        public void DeletePedido(int id)
        {
            _context.Remove(id);
            _context.SaveChanges();
        }

        public Pedido? GetPedidoById(int id)
        {
            Pedido? pedido = _context.Find<Pedido>(id);
            return pedido;
        }

        public void UpdatePedido(Pedido pedido)
        {
            _context.Update(pedido);
            _context.SaveChanges();
        }
    }
}
