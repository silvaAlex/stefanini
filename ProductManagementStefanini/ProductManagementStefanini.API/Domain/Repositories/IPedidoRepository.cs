using ProductManagement.API.Domain.Models;

namespace ProductManagement.API.Domain.Repositories
{
    public interface IPedidoRepository
    {
        Pedido? GetPedidoById(int id);
        void AddPedido(Pedido pedido);
        void UpdatePedido(Pedido pedido);
        void DeletePedido(int id);
    }
}
