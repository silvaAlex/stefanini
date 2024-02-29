using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProductManagement.API.Domain.Models
{
    [Table("ItemPedido")]
    public class ItemPedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProdutoId { get; set; }

        public int PedidoId { get; set; }

        [Required(ErrorMessage = "Quantidade é obrigatorio")]
        public int Quantidade { get; set; }

        public Produto? Produto { get; set; }
    }
}
