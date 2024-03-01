using ProductManagement.API.Domain.Models;
using ProductManagement.API.Domain.Repositories;
using ProductManagement.API.Infra.Database;
using ProductManagement.API.Infra.Repositories;
using ProductManagementStefanini.API.Infra.Response;
using ProductManagementStefanini.API.Test.Helpers;

namespace ProductManagementStefanini.API.Test
{
    public class PedidosTests
    {
        private readonly ApiDbContext _context = new MockDbContext().CreateDbContext();

        private readonly IPedidoRepository _pedidoRepository;

        public PedidosTests()
        {
            List<ItemPedido> pedidos = new();

            string nomeCliente = "Stefanini";
            ItemPedido smartwatch = new()
            {
                PedidoId = 1,
                ProdutoId = 1,
                Produto = new()
                {
                    NomeProduto = "Smartwatch",
                    Preco = (decimal?)299.99
                },
                Quantidade = 2,
            };

            pedidos.Add(smartwatch);

            Pedido pedido = new()
            {
                NomeCliente = nomeCliente,
                EmailCliente = "stefanini@stefanini.com",
                Pedidos = pedidos,
                Pago = false
            };

            _pedidoRepository = new PedidoRepository(_context);
            _pedidoRepository.AddPedido(pedido);
        }

        [Fact]
        public void CriarPedidoNoBancoDeDados()
        {
            string nomeCliente = "Stefanini";
            //Act 
            var result = _pedidoRepository.GetPedidoById(1);

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Pedidos);
            Assert.NotNull(_context?.Pedidos);
            Assert.Collection(_context.Pedidos, p =>
            {
                Assert.Equal(nomeCliente, p.NomeCliente);
                Assert.Equal(1, p.Id);
                Assert.True(p.Pedidos.Any());
            });
        }

        [Fact]
        public void CalculaValorTotalDoPedido()
        {
            var result = _pedidoRepository.GetPedidoById(1);

            //Assert
            Assert.NotNull(result);
            PedidoResponse response = new PedidoResponse().GetPedidoResponse(result);
            Assert.True(response.ValorTotal > 0);
            Assert.Equal((decimal)(2 * 299.99), response.ValorTotal);
        }
    }
}