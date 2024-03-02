using ProductManagement.API.Domain.Models;

namespace ProductManagement.API.Domain.Services
{
    public interface IPedidoService
    {
        Task<Pedido?> GetPedidoById(int id);
        Task<bool> AddPedido(Pedido pedido);
        Task<bool> UpdatePedido(Pedido pedido);
        Task<bool> DeletePedido(int id);
    }
}
