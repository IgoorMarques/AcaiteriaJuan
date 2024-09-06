using Microsoft.EntityFrameworkCore;
using Entities.Entidades;

namespace Entities.Context
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<EnderocoEntrega> EnderecosEntrega { get; set; }
        public DbSet<Acai> Acais { get; set; }
        public DbSet<Acompanhamento> Acompanhamentos { get; set; }
        public DbSet<AcaiAcompanhamento> AcaiAcompanhamentos { get; set; }
        public DbSet<PedidoAcai> PedidoAçais { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
            }
        }

        private string ObterStringConexao()
        {
            return "Data Source=DESKTOP-4LE6SQB;Initial Catalog=Acaiteria;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurando chaves compostas
            modelBuilder.Entity<AcaiAcompanhamento>()
                .HasKey(aa => new { aa.IdAcai, aa.IdAcompanhamento });

            modelBuilder.Entity<PedidoAcai>()
                .HasKey(pa => new { pa.IdPedido, pa.IdAcai });

            // Configurar o tipo de coluna decimal e precisão para as propriedades relacionadas a valores
            modelBuilder.Entity<Acai>()
                .Property(a => a.Valor)
                .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<Acompanhamento>()
                .Property(a => a.Valor)
                .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<Pagamento>()
                .Property(p => p.Valor)
                .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<PedidoAcai>()
                .Property(pa => pa.ValorUnitario)
                .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<PedidoAcai>()
                .Property(pa => pa.ValorTotal)
                .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<Usuario>()
                .Property(u => u.TaxaEntrega)
                .HasColumnType("decimal(18,4)");

            // Relacionamento entre Usuario e Pedido
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Pedidos)
                .HasForeignKey(p => p.IdUsuario_FK);

            // Relacionamento entre Usuario e EndEntrega
            modelBuilder.Entity<EnderocoEntrega>()
                .HasOne(e => e.Usuario)
                .WithMany(u => u.EnderecosEntrega)
                .HasForeignKey(e => e.IdUsuario_FK);

            // Relacionamento entre Pedido e Pagamento
            modelBuilder.Entity<Pagamento>()
                .HasOne(pg => pg.Pedido)
                .WithOne(p => p.Pagamento)
                .HasForeignKey<Pagamento>(pg => pg.IdPedido_FK);

            // Relacionamento entre Pedido e PedidoAcai
            modelBuilder.Entity<PedidoAcai>()
                .HasOne(pa => pa.Pedido)
                .WithMany(p => p.PedidoAçais)
                .HasForeignKey(pa => pa.IdPedido);

            // Relacionamento entre Açai e PedidoAcai
            modelBuilder.Entity<PedidoAcai>()
                .HasOne(pa => pa.Acai)
                .WithMany(a => a.PedidoAçais)
                .HasForeignKey(pa => pa.IdAcai);

            // Relacionamento entre Açai e AcaiAcompanhamento
            modelBuilder.Entity<AcaiAcompanhamento>()
                .HasOne(aa => aa.Acai)
                .WithMany(a => a.AcaiAcompanhamentos)
                .HasForeignKey(aa => aa.IdAcai);

            // Relacionamento entre Acompanhamento e AcaiAcompanhamento
            modelBuilder.Entity<AcaiAcompanhamento>()
                .HasOne(aa => aa.Acompanhamento)
                .WithMany(a => a.AcaiAcompanhamentos)
                .HasForeignKey(aa => aa.IdAcompanhamento);
        }

    }
}
