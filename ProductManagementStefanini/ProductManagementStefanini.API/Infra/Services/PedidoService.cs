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

        public void AddPedido(Pedido pedido) => _pedidoRepository.AddPedido(pedido);
        
        public void DeletePedido(int id) => _pedidoRepository.DeletePedido(id);

        public Pedido? GetPedidoById(int id) => _pedidoRepository.GetPedidoById(id);
       
        public void UpdatePedido(Pedido pedido) => _pedidoRepository.UpdatePedido(pedido);
       
    }
}
