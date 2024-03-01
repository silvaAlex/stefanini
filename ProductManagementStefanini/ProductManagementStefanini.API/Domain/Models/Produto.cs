using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ProductManagement.API.Domain.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int Id { get; private set; }
        [Required(ErrorMessage = "Nome Produto é obrigatorio")]
        [StringLength(20)]
        public string? NomeProduto { get; set; }

        [Required(ErrorMessage = "Preço é obrigatorio")]
        [Precision(10, 2)]
        public decimal? Preco { get; set; }
    }
}
