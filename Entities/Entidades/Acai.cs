using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entidades
{
    public class Acai
    {
        [Key]
        [Column("ID_ACAI")]
        public int IdAcai { get; set; }

        [Column("NOME")]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Column("DESCRICAO")]
        [MaxLength(255)]
        public string Descricao { get; set; }

        [Column("MAX_ACOMP_GRATUITO")]
        public int MaxAcompahamentoGratuito { get; set; }

        [Column("VALOR")]
        public decimal Valor { get; set; }

        [Column("MAX_ADICIONAL")]
        public int MaxAdicional { get; set; }

        // Navigation property
        public virtual ICollection<AcaiAcompanhamento> AcaiAcompanhamentos { get; set; }
        public virtual ICollection<PedidoAcai> PedidoAçais { get; set; }
    }
}
