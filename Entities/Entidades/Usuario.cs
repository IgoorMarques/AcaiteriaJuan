using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entidades
{
    public class Usuario
    {
        [Key]
        [Column("ID_USUARIO")]
        public int IdUsuario { get; set; }

        [Column("USER_NOME")]
        [MaxLength(100)]
        public string NomeCompleto { get; set; }

        [Column("TAXA_ENTREGA")]
        public decimal? TaxaEntrega { get; set; }

        [Column("TELEFONE_1")]
        [MaxLength(15)]
        public string Telefone1 { get; set; }

        [Column("TELEFONE_2")]
        [MaxLength(15)]
        public string Telefone2 { get; set; }

        // Navigation properties
        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual ICollection<EnderocoEntrega> EnderecosEntrega { get; set; }
    }
}
