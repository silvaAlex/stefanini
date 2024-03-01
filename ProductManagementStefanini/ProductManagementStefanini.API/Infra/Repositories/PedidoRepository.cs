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
            _context.Pedidos?.Add(pedido);
            _context.SaveChanges();
        }

        public void DeletePedido(int id)
        {
            Pedido? pedido = _context.Pedidos?.Where(x => x.Id == id).FirstOrDefault();

            if (pedido is not null)
            {
                _context.Pedidos?.Remove(pedido);
                _context.SaveChanges();
            }
        }

        public Pedido? GetPedidoById(int id)
        {
            Pedido? pedido = _context.Pedidos?.Where(x => x.Id == id)?.FirstOrDefault();
            return pedido;
        }

        public void UpdatePedido(Pedido pedido)
        {
            if (pedido is not null)
            {
                _context.Update(pedido);
                _context.SaveChanges();
            }
        }
    }
}
