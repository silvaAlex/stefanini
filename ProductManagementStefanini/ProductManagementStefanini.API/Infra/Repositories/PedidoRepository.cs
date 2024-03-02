using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
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

        public async Task<bool> AddPedido(Pedido pedido)
        {
            if(pedido is null)
                throw new ArgumentNullException(nameof(pedido));

            if(_context.Pedidos is not null)
            {
                await _context.Pedidos.AddAsync(pedido);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeletePedido(Pedido pedido)
        {
            if (pedido is null)
                throw new ArgumentNullException(nameof(pedido));

            if(_context.Pedidos is not null)
            {
                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;     
        }

        public async Task<Pedido?> GetPedidoById(int id)
        {
            if(_context.Pedidos is not null)
            {
                var pedido = await _context.Pedidos
                    .AsNoTracking()
                    .SingleOrDefaultAsync(s => s.Id == id);

                if(pedido is not null)
                {
                    pedido.Pedidos = GetItemPedido(pedido);
                }
                return pedido;
            }

            return null;
        }

        private List<ItemPedido>? GetItemPedido(Pedido pedido)
        {
            return  _context?.Items?
                .AsNoTracking()
                .Where(s => s.PedidoId == pedido.Id)
                .Include(s => s.Produto)
                .ToList();
        }

        public async Task<bool> UpdatePedido(Pedido pedido)
        {
            if (pedido is null)
                throw new ArgumentNullException(nameof(pedido));

            if (_context.Pedidos is not null)
            {
                _context.Pedidos.Update(pedido);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
