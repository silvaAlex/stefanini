using ProductManagement.API.Domain.Models;
using ProductManagement.API.Domain.Repositories;
using ProductManagement.API.Domain.Services;

namespace ProductManagement.API.Infra.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public Task<bool> AddPedido(Pedido pedido)
        {
            return _pedidoRepository.AddPedido(pedido);
        }

        public async Task<bool> DeletePedido(int id)
        {
            var pedido = await _pedidoRepository.GetPedidoById(id);

            if(pedido is null)
                return false;
            var result = await _pedidoRepository.DeletePedido(pedido);

            return result;
        }

        public async Task<Pedido?> GetPedidoById(int id)
        {
            return await _pedidoRepository.GetPedidoById(id);
        }

        public async Task<bool> UpdatePedido(Pedido pedido)
        {
            if (pedido is null)
                return false;

            var result = await _pedidoRepository.UpdatePedido(pedido);

            return result;
        }
    }
}
