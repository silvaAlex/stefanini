using ProductManagement.API.Domain.Models;

namespace ProductManagement.API.Domain.Repositories
{
    public interface IProdutoRepository
    {
        Produto GetProdutoById(int id);
        void AddProduto(Produto produto);
    }
}
