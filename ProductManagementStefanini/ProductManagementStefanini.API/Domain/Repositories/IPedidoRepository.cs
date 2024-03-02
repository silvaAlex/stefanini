using ProductManagement.API.Domain.Models;

namespace ProductManagement.API.Domain.Repositories
{
    public interface IPedidoRepository
    {
        Task<Pedido?> GetPedidoById(int id);
        Task<bool> AddPedido(Pedido pedido);
        Task<bool> UpdatePedido(Pedido pedido);
        Task<bool> DeletePedido(Pedido pedido);
    }
}
