using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entidades
{
    public class Acompanhamento
    {
        [Key]
        [Column("ID_ACOMPANHAMENTO")]
        public int IdAcompanhamento { get; set; }

        [Column("VALOR")]
        public decimal Valor { get; set; }

        [Column("TIPO")]
        [MaxLength(50)]
        public string Tipo { get; set; }

        [Column("NOME")]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Column("DESCRICAO")]
        [MaxLength(255)]
        public string Descricao { get; set; }

        // Navigation property
        public virtual ICollection<AcaiAcompanhamento> AcaiAcompanhamentos { get; set; }
    }
}
