using ProductManagement.API.Domain.Models;

namespace ProductManagementStefanini.API.Infra.Response
{
    public class PedidoResponse
    {
        public int Id { get; private set; }
        public string? NomeCliente { get; private set; }
        public string? EmailClient { get; private set; }
        public bool? Pago { get; set; }
        public decimal ValorTotal { get; private set; } = 0;
        public List<ItemPedidoResponse>? ItensPedido { get; private set; }

        public class ItemPedidoResponse
        {
            public int Id { get; set; }
            public int IdProduto { get; set; }
            public string? NomeProduto { get; set; }
            public decimal? ValorUnitario { get; set; }
            public int Quantidade { get; set; }
        }

        public PedidoResponse GetPedidoResponse(Pedido pedido)
        {
            var itemPedidos = new List<ItemPedidoResponse>();

            if (pedido.Pedidos is not null)
            {
                foreach (ItemPedido item in pedido.Pedidos)
                {
                    itemPedidos.Add(new ItemPedidoResponse()
                    {
                        Id = item.Id,
                        IdProduto = item.ProdutoId,
                        NomeProduto = item.Produto?.NomeProduto,
                        ValorUnitario = item.Produto?.Preco,
                        Quantidade = item.Quantidade,
                    });
                }
            }

            PedidoResponse response = new()
            {
                Id = pedido.Id,
                NomeCliente = pedido.NomeCliente,
                EmailClient = pedido.EmailCliente,
                ValorTotal = CalcularSomaItemPedido(itemPedidos),
                ItensPedido = itemPedidos,
            };

            return response;
        }

        public decimal CalcularSomaItemPedido(List<ItemPedidoResponse> pedidos)
        {
            return pedidos.Sum(x => x.Quantidade * x.ValorUnitario) ?? 0;
        }
    }
}
