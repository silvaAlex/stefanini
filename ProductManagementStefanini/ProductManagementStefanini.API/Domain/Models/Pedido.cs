﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.API.Domain.Models
{
    [Table("Pedido")]
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome do cliente é obrigatorio")]
        [StringLength(60)]
        public string? NomeCliente { get; set; }

        [Required(ErrorMessage = "Email do cliente é obrigatorio")]
        [StringLength(60)]
        public string? EmailCliente { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public bool Pago { get; set; } = false;
        public ICollection<ItemPedido>? Pedidos { get; set; }
    }
}
