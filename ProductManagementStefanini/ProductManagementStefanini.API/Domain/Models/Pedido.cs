using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.API.Domain.Models
{
    [Table("Pedido")]
    public class Pedido
    {
        [Key]
        public int Id { get; private set; }

        [Required(ErrorMessage = "Nome do cliente é obrigatorio")]
        public string? NomeCliente { get; set; }

        [Required(ErrorMessage = "Email do cliente é obrigatorio")]
        public string? EmailCliente { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public bool? Pago { get; set; }
        public ICollection<ItemPedido> Pedidos { get; set; } = new List<ItemPedido>();
    }
}
