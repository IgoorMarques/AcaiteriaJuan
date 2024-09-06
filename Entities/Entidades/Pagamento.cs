using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entidades
{
    public class Pagamento
    {
        [Key]
        [Column("ID_PAGAMENTO")]
        public int IdPagamento { get; set; }

        [Column("VALOR")]
        public decimal Valor { get; set; }

        [Column("STATUS")]
        [MaxLength(20)]
        public string Status { get; set; }

        [Column("DESCRICAO")]
        [MaxLength(255)]
        public string Descricao { get; set; }

        [Column("ID_PEDIDO_FK")]
        public int IdPedido_FK { get; set; }

        // Navigation property
        public virtual Pedido Pedido { get; set; }
    }
}
