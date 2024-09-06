using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entidades
{
    public class Pedido
    {
        [Key]
        [Column("ID_PEDIDO")]
        public int IdPedido { get; set; }

        [Column("STATUS")]
        [MaxLength(20)]
        public string Status { get; set; }

        [Column("DATA_PEDIDO")]
        public DateTime DataPedido { get; set; }

        [Column("FORMA_PAGAMENTO")]
        [MaxLength(20)]
        public string FormaPagamento { get; set; }

        [Column("ID_USUARIO_FK")]
        public int IdUsuario_FK { get; set; }

        // Navigation property
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<PedidoAcai> PedidoAçais { get; set; }
        public virtual Pagamento Pagamento { get; set; }
    }
}
