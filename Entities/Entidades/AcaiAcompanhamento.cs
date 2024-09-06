using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entidades
{
    public class AcaiAcompanhamento
    {
        [Column("ID_ACAI")]
        public int IdAcai { get; set; }

        [Column("ID_ACOMPANHAMENTO")]
        public int IdAcompanhamento { get; set; }

        // Navigation properties
        public virtual Acai Acai { get; set; }
        public virtual Acompanhamento Acompanhamento { get; set; }
    }
}
