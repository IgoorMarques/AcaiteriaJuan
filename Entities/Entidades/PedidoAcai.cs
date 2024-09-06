using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entidades
{
    public class PedidoAcai
    {
        [Column("ID_PEDIDO")]
        public int IdPedido { get; set; }

        [Column("ID_ACAI")]
        public int IdAcai { get; set; }

        [Column("QTD")]
        public int Qtd { get; set; }

        [Column("VALOR_UNITARIO")]
        public decimal ValorUnitario { get; set; }

        [Column("VALOR_TOTAL")]
        public decimal ValorTotal { get; set; }

        // Navigation properties
        public virtual Pedido Pedido { get; set; }
        public virtual Acai Acai { get; set; }
    }
}
