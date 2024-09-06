using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entidades
{
    public class EnderocoEntrega
    {
        [Key]
        [Column("END_ENTREGA_PK")]
        public int EndEntrega_PK { get; set; }

        [Column("ENDERECO_ENTREGA")]
        [MaxLength(255)]
        public string EnderecoEntrega { get; set; }

        [Column("ID_USUARIO_FK")]
        public int IdUsuario_FK { get; set; }

        // Navigation property
        public virtual Usuario Usuario { get; set; }
    }
}
